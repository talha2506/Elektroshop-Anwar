using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Elektroshop {
    public class Verwaltung {
        public List<Person> personen;
        XElement root = XElement.Load("../../personen.xml");
        
        public Verwaltung() {
            personen = new List<Person>();
        }
        public bool AddPerson(Person p) {
            if (p == null) return false;
            personen.Add(p);
            return true;
        }

        public bool Remove(Person p) {
            if (p == null) throw new ElektroshopException("Person darf nicht null sein!");
            if (!personen.Contains(p)) throw new ElektroshopException("Person ist nicht vorhanden!");
            return personen.Remove(p);
        }
        public void PrintPersonen() {
            foreach (Person p in personen) {
                Console.WriteLine(p.ToString());
                Console.WriteLine("--------------------------");
            }
        }

        public void PrintK_ID() {
            foreach (Person p in personen) {
                if (!(p is Kunden)) continue;
                Console.WriteLine(((Kunden)p).KundenNr);
            }
        }

        public void PrintM_ID() {
            foreach (Person p in personen) {
                if (!(p is Mitarbeiter)) continue;
                Console.WriteLine(((Mitarbeiter)p).MitarbeiterNr);
            }
        }

        public void PrintEinkaufe(int id) {
            foreach (Person p in personen) {
                if (p is Kunden && (p.Equals(GetFromKundenNr(id)))) {
                    ((Kunden)p).PrintEinkauf();
                }
            }
        }

        public Person GetFromKundenNr(int id) {
            return personen.Find(x => ((Kunden)x).KundenNr == id);
        }

        public void FillXml() {
            XDocument d = XDocument.Parse("<root></root>");
            d.Save("../../personen.xml");

            foreach (Person p in personen) {
                AddToXml(p);
            }
        }

        public void AddToXml(Person p) {

            if (p is Mitarbeiter) {
                Mitarbeiter m = (Mitarbeiter)p;
                AddMitarbeiter(m);
            } else {
                Kunden k = (Kunden)p;
                AddKunde(k);
            }
        }
        public void AddMitarbeiter(Mitarbeiter m) {
            XElement element = null;
            if (root.Descendants("Mitarbeiter").ToList().Count <= 0) {
                root.Add(new XElement("Mitarbeiter"));
            }
            element = root.Descendants("Mitarbeiter").ToList()[0];
            XElement container = new XElement("Arbeiter",
            new XAttribute("M_ID", m.MitarbeiterNr));
            container.Add(new XElement("Vorname", m.Vorname));
            container.Add(new XElement("Nachname", m.Nachname));
            container.Add(new XElement("Adresse", m.Adresse));
            container.Add(new XElement("Position", m.Position));
            container.Add(new XElement("Gehalt", m.Gehalt));
            element.Add(container);
            root.Save("../../personen.xml");
        }

        public void AddKunde(Kunden k) {
            XElement element = null;
            if (root.Descendants("Kunden").ToList().Count <= 0) {
                root.Add(new XElement("Kunde"));
            }
            element = root.Descendants("Kunde").ToList()[0];
            string newsletter = "";
            if (k.Newsletter) {
                newsletter = "Ja";
            } else {
                newsletter = "Nein";
            }
            XElement container = new XElement("Kennzeichnung",
            new XAttribute("K_ID", k.KundenNr));
            List<Produkte> einkauf = k.Einkaufsliste;
            List<Geraete> geraete = new List<Geraete>();
            List<Services> services = new List<Services>();
            List<Zubehoer> zubehoer = new List<Zubehoer>();
            foreach (var item in einkauf) {
                if (item is Geraete) {
                    geraete.Add((Geraete)item);
                } else if (item is Services) {
                    services.Add((Services)item);
                } else {
                    zubehoer.Add((Zubehoer)item);
                }
            }

            container.Add(new XElement("Vorname", k.Vorname));
            container.Add(new XElement("Nachname", k.Nachname));
            container.Add(new XElement("Adresse", k.Adresse));
            container.Add(new XElement("Mail", k.Mail));
            container.Add(new XElement("Treuepunkte", k.TreuePunkte));
            container.Add(new XElement("Newsletter", newsletter));
            var einkaufslist = new XElement("Einkaufsliste",
                from geraet in geraete
                select new XElement("Geraete",
                    new XAttribute("ID", geraet.kennzeichnung),
                    new XElement("Bezeichnung", geraet.Bezeichnung),
                    new XElement("Preis", geraet.Preis),
                    new XElement("Marke", geraet.Marke),
                    new XElement("Typ", geraet.Typ)),
                from service in services
                select new XElement("Services",
                    new XAttribute("ID", service.Kennzeichnung),
                    new XElement("Bezeichnung", service.Bezeichnung),
                    new XElement("Preis", service.Preis),
                    new XElement("Art", service.Bezeichnung)),
                from zubehor in zubehoer
                select new XElement("Zubehoer",
                    new XAttribute("ID", zubehor.Kennzeichnung),
                    new XElement("Bezeichnung", zubehor.Bezeichnung),
                    new XElement("Preis", zubehor.Preis),
                    new XElement("Verwendung", zubehor.Verwendung)));

            container.Add(new XElement("Einkaufslisten", einkaufslist));
            element.Add(container);
            root.Save("../../personen.xml");
        }
    }
}
