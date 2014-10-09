using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    static class Task_3
    {
        /// <summary>
        /// Рекурсивный вариант сортировки слиянием
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<int> RecMergeSort(List<int> list)
        {
            if (list.Count <= 1) return list;

            List<int> left = list.GetRange(0, list.Count / 2);
            List<int> right = list.GetRange(left.Count, list.Count - left.Count);
            return Task_2.Merge(RecMergeSort(left), RecMergeSort(right));
        }

        public static void NotRecMergeSort(List<int> list)
        {
            int k = 1;
            while (k < list.Count)
            {
                for (int i = 0; i < list.Count; i += k * 2)
                {
                    merge(list, i, k);
                }
                k *= 2;
            }
        }
        /// <summary>
        /// Сливает подмассивы по заданным индексам в один массив
        /// </summary>
        /// <param name="list"></param>
        /// <param name="f"></param>
        /// <param name="flen"></param>
        private static void merge(List<int> list, int f, int flen)
        {
            int index = f;
            int slen = flen;
            if (f + flen * 2 > list.Count)
                slen = slen - ((f + 2 * flen) - list.Count);
            if (slen < 0)
            {
                flen += slen;
                slen = 0;
            }
            var left = list.GetRange(f, flen);
            var right = list.GetRange(f + flen, slen);
            while (left.Count > 0 && right.Count > 0)
            {
                if (left[0] <= right[0])
                {
                    list[index++] = left[0];
                    left.RemoveAt(0);
                }
                else
                {
                    list[index++] = right[0];
                    right.RemoveAt(0);
                }
            }
            for (int i = 0; i < left.Count; i++)
                list[index++] = left[i];
            for (int i = 0; i < right.Count; i++)
                list[index++] = right[i];
        }
    }
}