using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Elektroshop {
    public abstract class Produkte {
        private string bezeichnung;
        private float preis;
        internal string kennzeichnung;
        internal static int id = 1;

        public Produkte(string bezeichnung, float preis) {
            Bezeichnung = bezeichnung;
            Preis = preis;
        }

        public string Kennzeichnung {
            get {
                return kennzeichnung;
            }
            set {
                if (String.IsNullOrWhiteSpace(value)) throw new ElektroshopException("Kennzeichnung darf nicht leer sein!");
                kennzeichnung = value;
            }
        }

        public string Bezeichnung {
            get {
                return bezeichnung;
            }
            set {
                if (String.IsNullOrWhiteSpace(value)) throw new ElektroshopException("Bezeichnung darf nicht leer sein!");
                bezeichnung = value;
            }
        }

        public float Preis {
            get {
                return preis;
            }
            set {
                if (value <= 0) throw new ElektroshopException("Preis darf nicht 0 oder negativ sein!");
                preis = value;
            }
        }

        public override string ToString() {
            return "Bezeichnung: " + Bezeichnung + "\nKennzeichnung: " + Kennzeichnung + "\nPreis: " + Preis;
        }

        public override bool Equals(object obj) {
            return Bezeichnung+""+Preis == ((Produkte)obj).Bezeichnung+""+Preis;
        }
        public override int GetHashCode() {
            unchecked {
                int hash = (int)2166136261;
                hash *= 16777619 ^ Bezeichnung.GetHashCode();
                hash *= 16777619 ^ Preis.GetHashCode();
                return hash;
            }
        }
    }
}
