using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{

    class RecursList<T>
    {
        /// <summary>
        /// Создаем список со следующими свойствами: Длина,Индекс,Информ.Поле,Хвост списка
        /// </summary>
        private T Info;
        private RecursList<T> Tail;
        private int Index;
        public int Length
        {
            get { return Index + 1; }
        }
        
        public RecursList(T value)
        {
            Info = value;
            Tail = null;
            Index = 0;
        }

        private RecursList(T value, RecursList<T> othertail)
        {
            Info = value;
            Tail = othertail;
            if (othertail != null)
                Index = othertail.Index + 1;
            else
                Index = 0;
        }

        public RecursList()
        {
            Info = default(T);
            Tail = null;
            Index = -1;
        }

        public T this[int index]//индексатор списка
        {
            get
            {
                try
                {
                    if (index < 0 || index >= Length)
                        throw new Exception("Индекс за границей списка");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return default(T);
                }
                for (RecursList<T> i = this; i != null; i = i.Tail)
                {
                    if (i.Index == index)
                        return i.Info;
                }
                return default(T);
            }

            set
            {
                try
                {
                    if (index < 0 || index >= Length)
                        throw new Exception("Индекс за границей списка");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }

                for (RecursList<T> i = this; i != null; i = i.Tail)
                {
                    if (i.Index == index)
                        i.Info = value;
                }
            }
        }

        public void Add(T value)//добавление элемента
        {
            Tail = new RecursList<T>(Info, Tail);
            Info = value;
            Index++;
            if (Index == 0)
                Tail = null;
        }

        public void Print()
        {
            if (Index == -1)
                return;
            print(this);
            Console.WriteLine();
        }
        private void print(RecursList<T> Item)
        {
            if (Item.Tail != null)
                print(Item.Tail);
            Console.Write("{0} ", Item.Info);
        }

        public void PrintDebug()
        {
            if (Index == -1)
                return;
            printDebug(this);
        }
        private void printDebug(RecursList<T> Item)
        {
            if (Item.Tail != null)
                printDebug(Item.Tail);
            Console.WriteLine("[{1}] = {0} | {2}", Item.Info, Item.Index, Item.Length);
        }

        public int Find(T value)//поиск элемента
        {
            for (RecursList<T> i = this; i != null; i = i.Tail)
                if (i.Info.Equals(value))
                    return i.Index;
           return -1;
        }

        public void Insert(int index, T value)
        {
            try
            {
                if (index < 0 || index > Length)
                    throw new Exception("Индекс находится за границей списка");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            if (index == Length)
            {
                Add(value);
                return;
            }

            if (Index == -1)
            {
                Add(value);
                return;
            }
            for (RecursList<T> i = this; i != null; i = i.Tail)
            {
                if(i.Index==index)
                {
                    i.Tail=new RecursList<T>(value,i.Tail);
                    i.Index++;
                    return;
                }
                i.Index++;
            }
        }

        public void InsertBeforeValue(T findValue, T value)
        {
            int index = Find(findValue);
            try
            {
                if (index == -1)
                    throw new Exception(String.Format("Элемент {0} не найден", findValue));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            Insert(index, value);

        }

        public void InsertAfterValue(T findValue, T value)
        {
            int index = Find(findValue);
            try
            {
                if (index == -1)
                    throw new Exception(String.Format("Элемент {0} не найден", findValue));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            Insert(index + 1, value);
        }

        public void InsertBeforeAllValue(T findValue, T value)
        {
            var ind = FindAll(findValue);
            if(ind.Count==0)
            {
                Console.WriteLine("Элемент {0} не найден", findValue);
                return;
            }
            for (int i = 0; i < ind.Count; ++i)
                Insert(ind[i], value);

        }//

        public List<int> FindAll(T value)
        {
            List<int> temp = new List<int>();
            for (RecursList<T> i = this; i != null; i = i.Tail)
                if (i.Info.Equals(value))
                    temp.Add(i.Index);
            return temp;
        }

        public void Del(int index)
        {
            try
            {
                if (index < 0 || index >= Length)
                    throw new Exception("Индекс находится за границей списка");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            #region Удаление последнего элемента
            if (index == Index)
            {
                Index--;
                if(Index==-1)
                    return;
                Info =Tail.Info;
                Tail = Tail.Tail;
                return;
            }
            #endregion

            RecursList<T> i = this;
            for (; i.Tail.Tail != null; i = i.Tail)
            {
                i.Index--;
                if (i.Tail.Index == index)
                {
                    i.Tail = i.Tail.Tail;
                    return;
                }
            }
            if (index == 0)
            {
                i.Tail = null;
                i.Index--;
            }
        }

        public void DelByValue(T value)
        {
            int index = Find(value);
            try
            {
                if (index == -1)
                    throw new Exception(String.Format("Элемент {0} не найден", value));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            Del(index);
        }

        public void DelAll()
        {
            Index = -1;
            Tail = null;
        }

        public void Reverse()//для задания 7
        {
            for (int i = 0; i < Length / 2; i++)
            {
                Swap(i, Length - 1 - i);
            }
        }

        public void Swap(int first, int second)//меняет значения
        {
            T temp = this[first];
            this[first] = this[second];
            this[second] = temp;
        }

        public void SwapRef(int first, int second)//меняет ссылки
        {
            RecursList<T> f = null, s = null;
            if (Index != first && Index != second)
            {
                for (RecursList<T> i = this; i.Tail != null; i = i.Tail)
                {
                    if (i.Tail.Index == first)
                    {
                        f = i;
                        break;
                    }
                }
                for (RecursList<T> i = this; i.Tail != null; i = i.Tail)
                {
                    if (i.Tail.Index == second)
                    {
                        s = i;
                        break;
                    }
                }
                if (f == null || s == null)
                    return;
                var t = f.Tail;
                f.Tail = s.Tail;
                s.Tail = t;
                t = f.Tail.Tail;
                f.Tail.Tail = s.Tail.Tail;
                s.Tail.Tail = t;
                f.Tail.Index = first;
                s.Tail.Index = second;
            }
            else
            {
                Swap(first, second);
            }
        }

    }

}
