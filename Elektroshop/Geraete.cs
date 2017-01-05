using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektroshop
{
    class Geraete : Produkte
    {
        private string marke;
        private string typ;

        public Geraete(string marke, string typ, string bezeichnung, float preis, string kennzeichnung) : base(bezeichnung, preis, kennzeichnung)
        {
            Marke = marke;
            Typ = typ;
        }

        public string Marke
        {
            get
            {
                return marke;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value)) throw new ElektroshopException("Marke darf nicht leer sein!");
            }
        }

        public string Typ
        {
            get
            {
                return typ;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value)) throw new ElektroshopException("Typ darf nicht leer sein!");
            }
        }
    }
}
