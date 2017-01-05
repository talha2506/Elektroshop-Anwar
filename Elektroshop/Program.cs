using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elektroshop;

namespace Elektroshop
{
    class Program
    {
        static void Main(string[] args)
        {
            Produkte p = new Geraete("Apple", "Handy" ,"iPhone 6s 64GB",12F,"G001");
            Lager l = new Lager();
            l.Add(p);
            l.print();
            Console.WriteLine("test");
        }
    }
}
