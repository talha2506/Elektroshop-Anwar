﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektroshop {
    public class Mitarbeiter : Person {
        private int mitarbeiterNr;
        private double gehalt;
        private string position;

        public Mitarbeiter(double gehalt, string position, string vorname, string nachname, string adresse) : base(vorname, nachname, adresse) {
            MitarbeiterNr = ++Person.mitarbeiterID;
            Gehalt = gehalt;
            Position = position;
        }
        public int MitarbeiterNr {
            get {
                return mitarbeiterNr;
            }
            set {
                if (value <= 0) throw new ElektroshopException("Mitarbeiter Nummer muss größer 0 sein!");
                mitarbeiterNr = value;
            }
        }

        public double Gehalt {
            get {
                return gehalt;
            }
            set {
                if (value <= 0D) throw new ElektroshopException("Gehalt kann nicht 0 oder negativ sein!");
                gehalt = value;
            }
        }

        public string Position {
            get {
                return position;
            }
            set {
                if (String.IsNullOrWhiteSpace(value)) throw new ElektroshopException("Position darf nicht leer sein!");
                position = value;
            }
        }

        public override string ToString() {
            return base.ToString() + "\nMitarbeiter-Nummer: " + MitarbeiterNr + "\nGehalt: " + Gehalt + "\nPosition: " + Position + "\n";
        }

        public override bool Equals(object m1) {
            if (!(m1 is Mitarbeiter)) return false;
            return this.MitarbeiterNr.Equals(((Mitarbeiter)m1).MitarbeiterNr);
        }

        public override int GetHashCode() {
            unchecked {
                int hash = (int)2166136261;
                hash *= 16777619 ^ MitarbeiterNr.GetHashCode();
                return hash;
            }
        }
    }
}