using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Stack<T>
    {
        T[] mas;
        
        public int Length { get; private set; }
        
        public Stack()
        {
            mas = new T[5];
            Length = 0;
        }

        public Stack(int l)
        {
            mas = new T[l];
            Length = 0;
        }

        public void Push(T i)
        {
            if (Length == mas.Length)
                return;
            mas[Length++] = i;
        }

        public T Pop()
        {
            if (Length == 0)
                return default(T);
            return mas[--Length];
        }

        public T See()
        {
            if (Length == 0)
                return default(T);
            return mas[Length-1];
        }

        public void Print()
        {
            for (int i = Length - 1; i >= 0; i--)
                Console.Write(string.Format("{0} ", mas[i]));
            Console.WriteLine();
        }

    }
}
