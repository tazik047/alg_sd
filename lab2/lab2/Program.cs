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
            for (int i = 1; i <= 10; i++)
            {
                t.Add(i);
            }
            //FirstTask(t);
            //t.Print();
            //SecondTask(t).Print();
            //Console.WriteLine(ThirdTask("({})[]"));
            // for task 4
            RecursList<int> rl = new RecursList<int>();
            for (int i = 0; i < 10; i++)
            {
                rl.Add(rnd.Next(100));
            }
            var c = new CountTimeAndExport2EXCEL.CountTime(sort);
            CountTimeAndExport2EXCEL.FunWithExcel.Save(c.StartCount(), @"E:\ALG\lab2.1.xlsx");
            /*rl.Print();
            sort(rl);
            rl.Print();*/
            //ForthTask(rl, 3).Print();
            //FifthTask(t);
            //SeventhTask(t).Print();

            
            //t.Print();
            //sortSimple(rl);
            //rl.Print();
            //Console.WriteLine();
            //Console.WriteLine(EightTask(t, rl));
        }

        static void sort(RecursList<int> t)
        {
            for (int i = 0; i < t.Length; i++)
            {
                for (int j = t.Length - 1; j > i; j--)
                {
                    if (t[j] < t[j - 1])
                        t.Swap(j, j - 1);
                }
            }
        }
    }
}
