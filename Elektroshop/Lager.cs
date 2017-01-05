using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektroshop
{
    class Lager
    {
        private List<Produkte> lager = new List<Produkte>();

        public void Add(Produkte p)
        {
            lager.Add(p);
        }
    }
}
