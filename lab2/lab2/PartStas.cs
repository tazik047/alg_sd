using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    partial class Program
    {
        public static void FirstTask(RecursList<int> t)
        {
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] % 2 == 0)
                    t.Del(i);
            }
        }

        public static RecursList<int> SecondTask(RecursList<int> t)
        {
            var res = new RecursList<int>();
            for (int i = 0; i < t.Length; i++)
                if (t[i] % 2 == 0)
                    res.Add(t[i]);
            for (int i = 0; i < t.Length; i++)
                if (t[i] % 2 != 0)
                    res.Add(t[i]);
            return res;
        }

        public static bool ThirdTask(string text)
        {
            int f = 0, s = 0, t = 0;
            foreach (var i in text)
            {
                switch (i)
                {
                    case '{':
                        f++;
                        break;
                    case '[':
                        s++;
                        break;
                    case '(':
                        t++;
                        break;
                    case '}':
                        if (f == 0)
                            return false;
                        f--;
                        break;
                    case ']':
                        if (s == 0)
                            return false;
                        s--;
                        break;
                    case ')':
                        if (t == 0)
                            return false;
                        t--;
                        break;
                }
            }
            return f == 0 && s == 0 && t == 0;
        }



        public static int SixthTask(int n, int m)
        {
            bool[] mas = new bool[n];
            m--;
            for (int i = 0; i < n; i++)
                mas[i] = true;
            int count = n, startPos = 0;
            while (count != 1)
            {
                int missed = 0;
                while (missed != m)
                    if (mas[(startPos++)%n])
                        missed++;
                while (!mas[(startPos) % n]) startPos++;
                mas[(startPos++) % n] = false;
                count--;
            }
            return Array.FindIndex(mas,x=>x==true) + 1;
        }

        public static void TenTask(RecursList<int> a)
        {
            if (a.Length <= 1)
                return;
            if (a.Length == 2)
            {
                if (a[0] > a[1])
                {
                    int temp = a[0];
                    a[0] = a[1];
                    a[1] = temp;
                }
                return;
            }
            int ind = part_sort(a);
            if (ind == 0)
            {
                var a2 = new RecursList<int>();
                for (int i = ind + 1; i < a.Length; i++)
                    a2.Add(a[i]);
                TenTask(a2);
                for (int i = ind + 1; i < a.Length; i++)
                    a[i] = a2[i - ind - 1];
            }
            else
            {
                var a1 = new RecursList<int>();
                for (int i = 0; i < ind; i++)
                    a1.Add(a[i]);
                var a2 = new RecursList<int>();
                for (int i = ind + 1; i < a.Length; i++)
                    a2.Add(a[i]);
                TenTask(a1);
                TenTask(a2);
                for (int i = ind + 1; i < a.Length; i++)
                    a[i] = a2[i - ind - 1];
                for (int i = 0; i < ind; i++)
                    a[i] = a1[i];
            }
        }

        static int part_sort(RecursList<int> a)
        {
            int s = 1, e = a.Length - 1;
            while (s <= e)
            {
                while (s != a.Length && a[s] < a[0])
                    s++;
                while (e != 0 && a[e] > a[0])
                    e--;
                if (s <= e)
                {
                    int temp = a[s];
                    a[s] = a[e];
                    a[e] = temp;
                    s += 1;
                    e -= 1;
                }
            }
            int temp1 = a[0];
            a[0] = a[e];
            a[e] = temp1;
            return e;
        }
    }
}
