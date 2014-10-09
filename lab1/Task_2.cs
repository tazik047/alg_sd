using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    static class Task_2
    {
        /// <summary>
        /// Метод разбития массивом на подмассивы
        /// </summary>
        /// <param name="list"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static List<int> SortWithInsertion(List<int> list, int k)
        {
            double test = Math.Log((double)k, 2);
            double t2 = Math.Round(test);
            if (test - t2 != 0)
            {
                Console.WriteLine("Число k должно быть степенью двойки.");
                return list;
            }

            if (list.Count < k) // ??
            {
                Console.WriteLine("Число k слишком большое."); // ??
                return list;
            }

            if (list.Count == k || list.Count == k + 1 || list.Count == k - 1) // Сортировка вставками.
            {
                Task_4.InsertSearch(list);
                return list;
            }

            List<int> left = list.GetRange(0, list.Count / 2);
            List<int> right = list.GetRange(left.Count, list.Count - left.Count);
            return Merge(SortWithInsertion(left, k), SortWithInsertion(right, k));
        }
        /// <summary>
        /// Слияние подмассивов
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();
            while (left.Count > 0 && right.Count > 0)
            {
                if (left[0] <= right[0])
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
            }
            result.AddRange(left);
            result.AddRange(right);
            return result;
        }
    }
}
