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
            List<int> mas = new List<int>() { 12, 454, 67, 3435, 6, 87, 8, 4235, 570, 456, 2, 1, 9, 56, 5000 };
            PrintMas(Task_5.QuickSortWithRnd(mas));
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
