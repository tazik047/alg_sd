using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static void PrintMas<T>(IEnumerable<T> mas)
        {
            Console.WriteLine();
            foreach (var i in mas)
                Console.Write("{0}, ", i);
            Console.WriteLine();
        }
    }
}
