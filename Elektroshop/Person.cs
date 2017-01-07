﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektroshop
{
    class Person
    {
        private string vorname;
        private string nachname;
        private string adresse;

        public Person(string vorname, string nachname, string adresse)
        {
            Vorname = vorname;
            Nachname = nachname;
            Adresse = adresse;
        }

        public string Vorname
        {
            get
            {
                return vorname;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value)) throw new ElektroshopException("Vorname darf nicht leer sein!");
                vorname = value;
            }
        }

        public string Nachname
        {
            get
            {
                return nachname;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value)) throw new ElektroshopException("Nachname darf nicht leer sein!");
                nachname = value;
            }
        }

        public string Adresse
        {
            get
            {
                return adresse;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value)) throw new ElektroshopException("Adresse darf nicht leer sein!");
                adresse = value;
            }
        }
    }
}