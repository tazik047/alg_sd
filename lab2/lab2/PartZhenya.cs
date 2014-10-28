using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    partial class Program
    {
        public static RecursList<int> SeventhTask(RecursList<int> t)
        {
            t.Reverse();
            return t;
          
        }

        public static RecursList<int> ForthTask(RecursList<int> t,int b)
        {
            var res = new RecursList<int>();
            for (int i = 0; i < t.Length; i++)
                if (t[i] < b )
                    res.Add(t[i]);
            for (int i = 0; i < t.Length; i++)
                if (t[i] == b)
                    res.Add(t[i]);
            for (int i = 0; i < t.Length; i++)
                if (t[i] > b )
                    res.Add(t[i]);
            return res;

        }

        public static void FifthTask(RecursList<int>t)
        {
            Console.WriteLine("Начальный список:");
            t.Print();
            int max = 0;
            int min = 0;
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] > t[max])
                    max = t[i];
            }
            Console.WriteLine("Max index = {0}",max);
                    
             for (int i = 0; i < t.Length; i++)
             {
                if (t[i] < t[min])
                    min = t[i];
             }
            Console.WriteLine("Min index = {0}",min);
            Console.WriteLine();
            t.SwapRef(min,max);
            t.Print();


        }
    }
}
