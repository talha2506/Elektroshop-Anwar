using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                AddKennzeichnung(p);
                lager.Add(p, 1);
                AddToXml(p);
            }
        }

        public void AddToXml(Produkte p) {
            if (p is Geraete) {
                Geraete g = (Geraete)p;
                var xlm = new XElement("Produkte",
                from x in lager
                select new XElement("Geraete",
                    new XAttribute("Anzahl", 
                    new XElement("Kennzeichnung", x.Key.Kennzeichnung),
                    new XElement("Bezeichnung", g.Bezeichnung),
                    new XElement("Preis", g.Preis),
                    new XElement("Marke", g.Marke),
                    new XElement("Typ", g.Typ)
                ));
                xlm.Save("../../initProdukt.xml");

            } else if (p is Services) {
                Services s = (Services)p;
            } else {
                Zubehoer z = (Zubehoer)p;
            }
        }

        private void AddKennzeichnung(Produkte p) {
            if (p is Geraete) {
                p.Kennzeichnung = "G";
            } else if (p is Services) {
                p.Kennzeichnung = "S";
            } else {
                p.Kennzeichnung = "Z";
            }
            if (Produkte.id.ToString().Length == 1) {
                p.Kennzeichnung += "00";
            } else if (Produkte.id.ToString().Length == 2) {
                p.Kennzeichnung += "0";
            }
            p.kennzeichnung += Produkte.id++;
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
