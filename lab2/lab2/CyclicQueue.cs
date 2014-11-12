using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class CyclicQueue<T>
    {
        T[] mas;

        public int First { get; private set; }
        public int Last { get; private set; }

        public CyclicQueue()
        {
            mas = new T[5];
            Last = 0;
            First = -1;
        }

        public void Push(T i)
        {
            if (((Last + 1) % mas.Length) == First)
                return;
            if (First == -1)
                First = 0;
            mas[(Last++) % mas.Length] = i;
        }

        public T Pop()
        {
            if (First == -1)
                return default(T);
            return mas[(First++) % mas.Length];
        }

        public void Print()
        {
            int i = First;
            while (i != Last)
                Console.Write(string.Format("{0} ", mas[(i++) % mas.Length]));
            Console.WriteLine();
        }
    }
}
