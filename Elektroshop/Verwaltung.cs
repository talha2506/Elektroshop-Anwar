using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektroshop {
    public class Verwaltung {
        public List<Person> personen;
        public Verwaltung() {
            personen = new List<Person>();
        }
        public void Add(Person p) {
            if (p == null) throw new ElektroshopException("Person darf nicht null sein!");
            if (personen.Contains(p)) throw new ElektroshopException("Person ist schon vorhanden!");
            personen.Add(p);
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
    }
}
