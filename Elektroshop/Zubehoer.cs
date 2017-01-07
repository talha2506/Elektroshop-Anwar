using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektroshop
{
    class Zubehoer : Produkte
    {
        private string verwendung;

        public Zubehoer(string verwendung, string bezeichnung, float preis, string kennzeichnung) : base(bezeichnung, preis, kennzeichnung)
        {
            Verwendung = verwendung;
        }

        public string Verwendung
        {
            get
            {
                return verwendung;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value)) throw new ElektroshopException("Verwendung darf nicht leer sein!");
                verwendung = value;
            }
        }
    }
}