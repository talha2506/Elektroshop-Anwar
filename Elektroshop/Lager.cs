using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektroshop {
    class Lager {
        private Dictionary<Produkte, int> lager;

        public Lager() {
            lager = new Dictionary<Produkte, int>();
        }

        public void Add(Produkte p) {
            if (p == null) throw new ElektroshopException("Produkt darf nicht null sein!");
            if (lager.ContainsKey(p)) {
                lager[p]++;
            } else {
                lager.Add(p, 1);
            }
        }

        public bool Remove(Produkte p) {
            if (p == null) throw new ElektroshopException("Produkt darf nicht null sein!");
            if (!lager.ContainsKey(p)) throw new ElektroshopException("Produkt ist nicht vorhanden!");
            return lager.Remove(p);
        }

        public void PrintLagerbestand() {
            foreach (Produkte p in lager.Keys) {
                Console.WriteLine(lager[p] + " Mal " + p.ToString());
                Console.WriteLine("-----------------------------------");
            }
        }
    }
}
