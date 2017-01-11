using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Elektroshop {
    abstract class Produkte {
        private string bezeichnung;
        private float preis;
        private string kennzeichnung;

        public Produkte(string bezeichnung, float preis, string kennzeichnung) {
            Bezeichnung = bezeichnung;
            Preis = preis;
            Kennzeichnung = kennzeichnung;
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

        public string Kennzeichnung {
            get {
                return kennzeichnung;
            }
            set {
                if (String.IsNullOrWhiteSpace(value)) throw new ElektroshopException("Kennzeichnung darf nicht leer sein!");
                kennzeichnung = value;
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
            return Kennzeichnung == ((Produkte)obj).Kennzeichnung;
        }
        public override int GetHashCode() {
            unchecked {
                int hash = (int)2166136261;
                hash *= 16777619 ^ Kennzeichnung.GetHashCode();
                return hash;
            }
        }
    }
}
