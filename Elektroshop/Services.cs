using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektroshop {
    class Services : Produkte {
        private string art;

        public Services(string art, string bezeichnung, float preis, string kennzeichnung) : base(bezeichnung, preis, kennzeichnung) {
            Art = art;
        }

        public string Art {
            get {
                return art;
            }
            set {
                if (String.IsNullOrWhiteSpace(value)) throw new ElektroshopException("Art darf nicht leer sein!");
                art = value;
            }
        }
        public override string ToString() {
            return base.ToString() + "\nArt: " + Art;
        }
    }
}