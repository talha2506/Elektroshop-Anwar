using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektroshop {
    public class Services : Produkte {
        private string art;
        

        public Services(string art, string bezeichnung, float preis) : base(bezeichnung, preis) {
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
            return base.ToString() + "\nArt: " + Art + "\n";
        }
    }
}