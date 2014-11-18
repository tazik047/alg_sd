using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class Tree<T> : AbsTree<Tree<T>, T>
    {

        public Tree(T v)
        {
            Value = v;
        }
    }

    public abstract class AbsTree<ChildrenType, T> where ChildrenType : AbsTree<ChildrenType, T>
    {
        public ChildrenType Left { get; set; }
        public ChildrenType Right { get; set; }

        public Color color = Color.Transparent;

        public T Value { get; set; }

        public void DrawTree()
        {
            var t = new Print<ChildrenType, T>(this);
            t.ShowDialog();
        }
    }
}
