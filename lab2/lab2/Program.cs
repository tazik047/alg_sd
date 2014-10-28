using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var t = new RecursList<int>();
            var rnd = new Random();
            for (int i = 1; i <= 9; i++)
            {
                t.Add(i);
            }
            //FirstTask(t);
            //t.Print();
            //SecondTask(t).Print();
            //Console.WriteLine(ThirdTask("({})[]"));
            ForthTask(t, 4).Print();
            //FifthTask(t);
            //SeventhTask(t).Print();
            
        }

    }
}
