using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektroshop {
    public class Kunden : Person {
        private int kundenNr;
        private int treuePunkte;
        private string mail;
        private bool newsletter;
        private List<Produkte> einkaufsliste = new List<Produkte>();

        public Kunden(int treuePunkte, string mail, bool newsletter, string vorname, string nachname, string adresse) : base(vorname, nachname, adresse) {
            KundenNr = ++Person.kundenID;
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
                if (string.IsNullOrWhiteSpace(value)) throw new ElektroshopException("Mail darf nicht leer sein!");
                mail = value;
            }
        }

        public void Add(Produkte p) {
            if (p == null) throw new ElektroshopException("Produkt darf nicht null sein!");
            einkaufsliste.Add(p);
        }

        public bool Newsletter {
            get {
                return newsletter;
            }
            set {
                newsletter = value;
            }
        }

        public override bool Equals(object k1) {
            if (!(k1 is Kunden)) return false;
            return this.KundenNr.Equals(((Kunden)k1).kundenNr);
        }

        public override int GetHashCode() {
            unchecked {
                int hash = (int)2166136261;
                hash *= 16777619 ^ KundenNr.GetHashCode();
                return hash;
            }
        }

        public void PrintEinkauf() {
            foreach (Produkte p in einkaufsliste) {
                Console.WriteLine(p.ToString());
            }
        }

        public List<Produkte> Einkaufsliste {
            get {
                return einkaufsliste;
            }
            set {
                einkaufsliste = value;
            }
        }

        public override string ToString() {
            string x = base.ToString() + "\nKunden-Nummer: " + KundenNr + "\nTreuepunkte: " + TreuePunkte + "\nMail: " + Mail + "\nNewsletter: " + Newsletter;
            x += "\nEinkaufsliste:\n";
            einkaufsliste.ForEach(y => x += y.ToString() + "\n");
            return x;
        }

    }
}
