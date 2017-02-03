using System;
using System.Runtime.Serialization;

namespace Elektroshop {
    [Serializable]
    public class ElektroshopException : Exception {
        public ElektroshopException() {
        }

        public ElektroshopException(string message) : base(message) {
        }

        public ElektroshopException(string message, Exception innerException) : base(message, innerException) {
        }

        protected ElektroshopException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}