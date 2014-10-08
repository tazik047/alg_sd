using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    static class Task_1
    {
        /// <summary>
        /// На каждом шаге алгоритма мы выбираем один из элементов входных данных
        /// и вставляем его на нужную позицию в уже отсортированном списке, до тех пор,
        /// пока набор входных данных не будет исчерпан.
        /// 
        /// O(n^2)
        /// 
        /// 
        /// 1) 5 6 3 1 8 7 2 4 выбранный элемент 5.
        /// 2) 5 6 3 1 8 7 2 4 выбранный элемент 6.
        /// 3) 5 6 3 1 8 7 2 4 выбранный элемент 3. Нужно менять ->
        /// 4) 3 5 6 1 8 7 2 4 выбранный элемент 1. Нужно менять ->
        /// 5) 1 3 5 6 8 7 2 4 выбранный элемент 8.
        /// 5) 1 3 5 6 8 7 2 4 выбранный элемент 7. Нужно менять ->
        /// 6) 1 3 5 6 7 8 2 4 выбранный элемент 2. Нужно менять ->
        /// 7) 1 2 3 5 6 7 8 4 выбранный элемент 4. Нужно менять ->
        /// 8) 1 2 3 4 5 6 7 8 Конец.
        /// 
        /// </summary>
        /// <param name="mas">Входной массив</param>
        public static void sortSimple(List<int> mas)
        {
            for (int i = 1; i < mas.Count; i++)
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

        /// <summary>
        /// Обычный бинарный поиск.
        /// </summary>
        /// <param name="mas">Сам массив</param>
        /// <param name="el">элемент для поиска</param>
        /// <param name="r">правая граница</param>
        /// <param name="l">левая граница</param>
        /// <returns></returns>
        public static int binSearch(List<int> mas, int el, int r, int l = 0)
        {
            int index = (l + r) / 2;
            if (l > r)
                return l;
            else if (el == mas[index])
                return index;
            else if (el > mas[index])
                return binSearch(mas, el, r, index + 1);
            else
                return binSearch(mas, el, index - 1, l);
        }

        /// <summary>
        /// Вставками, использую бинарную сортировку.
        /// по идеи O(n*log n) 
        /// </summary>
        /// <param name="mas">Сам массив</param>
        public static void sortWithBinSearch(List<int> mas)
        {
            for (int i = 1; i < mas.Count; i++)
            {
                if (mas[i - 1] > mas[i])
                {
                    int temp = mas[i];
                    int ind = binSearch(mas, temp, i - 1);
                    mas.RemoveAt(i);
                    mas.Insert(ind, temp);
                }
            }
        }

        /// <summary>
        /// Все тоже, но теперь с рекурсеей.
        /// </summary>
        /// <param name="mas">Сам массив</param>
        /// <param name="i">Начало неотсортированной части</param>
        public static void sortWithBinAndReqursion(List<int> mas, int i = 1)
        {
            if (i >= mas.Count)
                return;
            if (mas[i - 1] > mas[i])
            {
                int temp = mas[i];
                int ind = binSearch(mas, temp, i - 1);
                mas.RemoveAt(i);
                mas.Insert(ind, temp);
            }
            sortWithBinAndReqursion(mas, ++i);
        }
    }
}
