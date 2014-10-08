using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    static class Task_4
    {
        public static void InsertSearch(List<int> mas)
        {
            if (mas.Count == 0)
                return;
            insertSearch(mas, mas.Count - 1);
        }

        private static void insertSearch(List<int> mas, int end)
        {
            if (end == 0)
                return;
            else
            {
                insertSearch(mas, end - 1);
                int index = Task_1.binSearch(mas, mas[end], end - 1);
                int temp = mas[end];
                mas.RemoveAt(end);
                mas.Insert(index, temp);
            }
        }
    }
}
