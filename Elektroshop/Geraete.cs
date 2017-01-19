using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektroshop {
    public class Geraete : Produkte {
        private string marke;
        private string typ;

        public Geraete(string marke, string typ, string bezeichnung, float preis) : base(bezeichnung, preis) {
            Marke = marke;
            Typ = typ;
        }

        public string Marke {
            get {
                return marke;
            }
            set {
                if (String.IsNullOrWhiteSpace(value)) throw new ElektroshopException("Marke darf nicht leer sein!");
                marke = value;
            }
        }

        public string Typ {
            get {
                return typ;
            }
            set {
                if (String.IsNullOrWhiteSpace(value)) throw new ElektroshopException("Typ darf nicht leer sein!");
                typ = value;
            }
        }

        public override string ToString() {
            return base.ToString() + "\nMarke: " + Marke + "\nTyp: " + Typ;
        }
    }
}
