using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektroshop {
    class Kunden : Person {
        private int kundenNr;
        private int treuePunkte;
        private string mail;
        private bool newsletter;

        public Kunden(int kundenNr, int treuePunkte, string mail, bool newsletter, string vorname, string nachname, string adresse) : base(vorname, nachname, adresse) {
            KundenNr = kundenNr;
            TreuePunkte = treuePunkte;
            Mail = mail;
            Newsletter = newsletter;
        }

        public int KundenNr {
            get {
                return kundenNr;
            }
            set {
                if (value <= 0) throw new ElektroshopException("Kunden Nummer muss größer 0 sein!");
                kundenNr = value;
            }
        }

        public int TreuePunkte {
            get {
                return treuePunkte;
            }
            set {
                if (value <= 0) throw new ElektroshopException("Treuepunkte können nicht negativ sein!");
                treuePunkte = value;
            }
        }

        public string Mail {
            get {
                return mail;
            }
            set {
                if (String.IsNullOrWhiteSpace(value)) throw new ElektroshopException("Mail darf nicht leer sein!");
                mail = value;
            }
        }
        public bool Newsletter {
            get {
                return newsletter;
            }
            set {
                newsletter = value;
            }
        }
        public override string ToString() {
            return base.ToString() + "\nKunden-Nummer: " + KundenNr + "\nTreuepunkte: " + TreuePunkte + "\nMail: " + Mail + "\nNewsletter: " + Newsletter;
        }
    }
}
