using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class Tree<T>
    {
        public Tree<T> Left { get; set; }
        public Tree<T> Right { get; set; }

        public T Value { get; set; }

        public Tree(T v)
        {
            Value = v;
        }

        public void DrawTree()
        {
            var t = new Print<T>(this);
            t.ShowDialog();
        }
    }
}
