using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    static class Task_3
    {
        public static List<int> Sort(List<int> list)
        {
            if (list.Count <= 1) return list;

            List<int> left = list.GetRange(0, list.Count / 2);
            List<int> right = list.GetRange(left.Count, list.Count - left.Count);
            return Task_2.Merge(Sort(left), Sort(right));
        }

    }
}