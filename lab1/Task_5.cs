﻿using System;
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
            Random rnd = new Random();
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

        /// <summary>
        /// Быстрая сортировка с рандомным выбором опорного элемента
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<T> QuickSortWithRnd<T>(List<T> list) where T : IComparable<T>
        {
            if (!list.Any())
            {
                return new List<T>();
            }
            Random rnd = new Random();
            int index = rnd.Next(0, list.Count());
            var pivot = list.ElementAt(index);
            list.RemoveAt(index);
            var smaller = QuickSortWithRnd(list.Where(item => item.CompareTo(pivot) <= 0).ToList());
            var larger = QuickSortWithRnd(list.Where(item => item.CompareTo(pivot) > 0).ToList());

            return smaller.Concat(new[] { pivot }).Concat(larger).ToList();
        }
    }
    
    public static List<T> QuickSortWithRnd<T>(List<T> list, int index) where T : IComparable<T>
    {
        if (!list.Any())
            {
                return new List<T>();
            }
            var pivot = list.ElementAt(index);
            list.RemoveAt(index);
            var smaller = QuickSortWithRnd(list.Where(item => item.CompareTo(pivot) <= 0).ToList());
            var larger = QuickSortWithRnd(list.Where(item => item.CompareTo(pivot) > 0).ToList());

            return smaller.Concat(new[] { pivot }).Concat(larger).ToList();
    }
}
