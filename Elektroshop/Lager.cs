using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace Elektroshop {
    class Lager {
        private Dictionary<Produkte, int> lager;
        XElement root = XElement.Load("../../initProdukt.xml");
        public Lager() {
            lager = new Dictionary<Produkte, int>();
            root = new XElement("root");
        }

        public void Add(Produkte p) {
            if (p == null) throw new ElektroshopException("Produkt darf nicht null sein!");
            if (lager.ContainsKey(p)) {
                lager[p]++;

            } else {
                AddKennzeichnung(p);
                lager.Add(p, 1);
            }
        }

        public void FillXml() {
            foreach (Produkte p in lager.Keys) {
                AddToXml(p);
            }
        }

        public void AddToXml(Produkte p) {

            if (p is Geraete) {
                Geraete g = (Geraete)p;
                AddGeraet(g);
            } else if (p is Services) {
                Services s = (Services)p;
                AddService(s);
            } else {
                Zubehoer z = (Zubehoer)p;
                AddZubehoer(z);
            }
        }
        public void AddGeraet(Geraete g) {
            XElement element = null;
            if (root.Descendants("Geraet").ToList().Count <= 0) {
                root.Add(new XElement("Geraet"));
            }
            element = root.Descendants("Geraet").ToList()[0];
            XElement container = new XElement("Kennzeichnung",
            new XAttribute("ID", g.Kennzeichnung));
            container.Add(new XElement("Anzahl", lager[g]));
            container.Add(new XElement("Marke", g.Marke));
            container.Add(new XElement("Bezeichnung", g.Bezeichnung));
            container.Add(new XElement("Typ", g.Typ));
            container.Add(new XElement("Preis", g.Preis));
            element.Add(container);
            root.Save("../../initProdukt.xml");
        }

        public void AddService(Services s) {
            XElement element = null;
            if (root.Descendants("Service").ToList().Count <= 0) {
                root.Add(new XElement("Service"));
            }
            element = root.Descendants("Service").ToList()[0];

            XElement container = new XElement("Kennzeichnung",
            new XAttribute("ID", s.Kennzeichnung));
            container.Add(new XElement("Anzahl", lager[s]));
            container.Add(new XElement("Bezeichnung", s.Bezeichnung));
            container.Add(new XElement("Art", s.Art));
            container.Add(new XElement("Preis", s.Preis));
            element.Add(container);
            root.Save("../../initProdukt.xml");
        }

        public void AddZubehoer(Zubehoer z) {
            XElement element = null;
            if (root.Descendants("Zubehoer").ToList().Count <= 0) {
                root.Add(new XElement("Zubehoer"));
            }
            element = root.Descendants("Zubehoer").ToList()[0];

            XElement container = new XElement("Kennzeichnung",
            new XAttribute("ID", z.Kennzeichnung));
            container.Add(new XElement("Anzahl", lager[z]));
            container.Add(new XElement("Bezeichnung", z.Bezeichnung));
            container.Add(new XElement("Verwendung", z.Verwendung));
            container.Add(new XElement("Preis", z.Preis));
            element.Add(container);
            root.Save("../../initProdukt.xml");
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

        public void PrintKennzeichen() {
            lager.Keys.ToList().ForEach(x => Console.WriteLine(x.Kennzeichnung));
        }

        public Produkte RemoveFromKennzeichen(string kennzeichen) {
            Produkte p = lager.Keys.ToList().Find(x => x.Kennzeichnung == kennzeichen);
            int anzahl = lager[p] - 1;
            lager.Remove(p);
            if (anzahl > 0) {
                lager.Add(p, anzahl);
            }



            return p;
        }

        public void ChangeTreuepunkte(string kennzeichen, string k_id) {
            Produkte p = lager.Keys.ToList().Find(x => x.Kennzeichnung == kennzeichen);
            int extra = System.Convert.ToInt32(p.Preis);

            var file = XElement.Load("../../personen.xml");
            (from person in file.Descendants("Kennzeichnung")
             where person.Attribute("K_ID").Value.Equals(k_id)
             select person).ToList().ForEach(x => x.Element("Treuepunkte").SetValue(int.Parse(x.Element("Treuepunkte").Value)+extra));
            
            file.Save("../../personen.xml");
        }
    }
}
