using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    static class Task_5
    {
        public static int Partition(List<int> m, int a, int b) 
        {
            int i = a;
            for (int j = a; j <= b; j++)
            {
                if (m[j].CompareTo(m[b]) <= 0)  // если элемент m[j] не превосходит m[b],
                {
                    int t = m[i];                  // меняем местами m[j] и m[a], m[a+1], m[a+2]...
                    m[i] = m[j];
                    m[j] = t;
                    i++;                         // последний обмен: m[b] и m[i], после чего i++
                }
            }
            return i - 1;                        // в индексе i хранится <новая позиция элемента m[b]> + 1
        }

        public static void Qsort(List<int> m)
        {
            Qsort(m, 0, m.Count - 1);
        }

        private static void Qsort(List<int> m, int a, int b) // a - начало подмножества, b - конец
        {                                        // для первого вызова: a = 0, b = m.Count - 1
            if (a >= b) return;
            int c = Partition(m, a, b);
            Qsort(m, a, c - 1);
            Qsort(m, c + 1, b);
        }
    }
}
