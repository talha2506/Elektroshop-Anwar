using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Elektroshop
{
    abstract class Produkte
    {
        private string bezeichnung;
        private float preis;
        private string kennzeichnung;

        public Produkte(string bezeichnung, float preis, string kennzeichnung)
        {
            Bezeichnung = bezeichnung;
            Preis = preis;
            Kennzeichnung = kennzeichnung;
        }

        public string Bezeichnung
        {
            get
            {
                return bezeichnung;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value)) throw new ElektroshopException("Bezeichnung darf nicht leer sein!");
            }
        }

        public string Kennzeichnung
        {
            get
            {
                return kennzeichnung;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value)) throw new ElektroshopException("Kennzeichnung darf nicht leer sein!");
            }
        }

        public float Preis
        {
            get
            {
                return preis;
            }
            set
            {
                if (value <= 0) throw new ElektroshopException("Preis darf nicht 0 oder negativ sein!");
            }
        }
    }


    [Serializable]
    internal class ElektroshopException : Exception
    {
        public ElektroshopException()
        {
        }

        public ElektroshopException(string message) : base(message)
        {
        }

        public ElektroshopException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ElektroshopException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
