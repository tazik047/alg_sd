﻿using System;
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
        public void sortSimple(List<int> mas)
        {
            for (int i = 0; i < mas.Count - 1; i++)
            {

            }
        }
    }
}