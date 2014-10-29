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

        public static RecursList<int> ForthTask(RecursList<int> t, int b)
        {
            var res = new RecursList<int>();
            for (int i = 0; i < t.Length; i++)
                if (t[i] < b)
                    res.Add(t[i]);
            for (int i = 0; i < t.Length; i++)
                if (t[i] == b)
                    res.Add(t[i]);
            for (int i = 0; i < t.Length; i++)
                if (t[i] > b)
                    res.Add(t[i]);
            return res;

        }

        public static void FifthTask(RecursList<int> t)
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
            Console.WriteLine("Max index = {0}", max);

            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] < t[min])
                    min = t[i];
            }
            Console.WriteLine("Min index = {0}", min);
            Console.WriteLine();
            t.SwapRef(min, max);
            t.Print();


        }

        public static int EightTask(RecursList<int> t, RecursList<int> p)
        {

            sortSimple(t);
            sortSimple(p);
            int count = 0;
            for (int i = 0; i < t.Length; i++)
            {
                for (int j = 0; j < p.Length; j++)
                {
                    if (t[i] == p[j]) count++;

                }
            }
            return count;

        }

        public static void sortSimple(RecursList<int> mas)
        {
            for (int i = 1; i < mas.Length; i++)
            {
                if (mas[i - 1] > mas[i])
                {
                    int j = i - 1;
                    int temp = mas[i];
                    while (j >= 0 && mas[j] > temp)
                        mas[j + 1] = mas[j--];
                    mas[++j] = temp;
                }
            }
        }
    }
}
