using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Tree<int>(10);
            createtree(t, 10);
            t.DrawTree();
        }

        static void createtree(Tree<int> t, int h)
        {
            if (h == 0)
                return;
            t.Left = new Tree<int>(99);
            t.Right = new Tree<int>(10);
            createtree(t.Left, h - 1);
            createtree(t.Right, h - 1);
        }
    }
}
