using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Queue<T>
    {
        T[] mas;
        
        public int Length { get; private set; }

        public Queue()
        {
            mas = new T[5];
            Length = 0;
        }

        public void Push(T i)
        {
            if (Length == 5)
                return;
            mas[Length++] = i;
        }

        public T Pop()
        {
            if (Length == 0)
                return default(T);
            T temp = mas[0];
            for (int i = 0; i < 4; i++)
                mas[i] = mas[i + 1];
            return temp;
        }

        public void Print()
        {
            for(int i=0;i<Length;i++)
                Console.WriteLine(mas[i]);
        }
    }
}
