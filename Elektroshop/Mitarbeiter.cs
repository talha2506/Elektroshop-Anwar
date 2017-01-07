using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektroshop
{
    class Mitarbeiter : Person
    {
        private int mitarbeiterNr;
        private double gehalt;
        private string position;

        public Mitarbeiter(int mitarbeiterNr, double gehalt, string position, string vorname, string nachname, string adresse) : base(vorname, nachname, adresse)
        {
            MitarbeiterNr = mitarbeiterNr;
            Gehalt = gehalt;
            Position = position;
        }
        public int MitarbeiterNr
        {
            get
            {
                return mitarbeiterNr;
            }
            set
            {
                if (mitarbeiterNr <= 0) throw new ElektroshopException("Mitarbeiter Nummer muss größer 0 sein!");
                mitarbeiterNr = value;
            }
        }

        public double Gehalt
        {
            get
            {
                return gehalt;
            }
            set
            {
                if (gehalt <= 0D) throw new ElektroshopException("Gehalt kann nicht 0 oder negativ sein!");
                gehalt = value;
            }
        }

        public string Position
        {
            get
            {
                return position;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value)) throw new ElektroshopException("Position darf nicht leer sein!");
                position = value;
            }
        }
    }
}