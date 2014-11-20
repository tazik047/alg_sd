using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();

            // просто дерево
            /*var t = new Tree<int>(10);
            createtree(t, 5);
            t.DrawTree();*/

            //var t = new ReadBlackTree(39);
            /*t.Insert(96); t.DrawTree();
            t.Insert(29); t.DrawTree();
            t.Insert(45); t.DrawTree();
            t.Insert(34); t.DrawTree();
            t.Insert(31); t.DrawTree();
            t.Insert(56); t.DrawTree();
            t.Insert(99); t.DrawTree();
            t.Insert(81); t.DrawTree();
            t.Insert(23); t.DrawTree();
            t.Insert(70); t.DrawTree();
            t.Insert(75); t.DrawTree();
            t.Insert(17);*/
            /*t.Insert(38); t.DrawTree();
            t.Insert(37); t.DrawTree();
            t.Insert(36); t.DrawTree();
            t.Insert(35);t.DrawTree();
            t.Insert(34);t.DrawTree();
            t.Insert(33);t.DrawTree();
            t.Insert(32);*/
            var t = new Splay_Tree(rnd.Next() % 100);
            for (int i = 0; i < 5; i++)
            {
                t.insert(rnd.Next() % 100);
                
            }
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

        static void createtree(Tree<Point> t, int h)
        {
            if (h == 0)
                return;
            t.Left = new Tree<Point>(new Point(3, 4));
            t.Right = new Tree<Point>(new Point(3, 4));
            createtree(t.Left, h - 1);
            createtree(t.Right, h - 1);
        }

        private static Point findHeightPos(int key)
        {
            int x = Convert.ToInt32(Math.Log(key, 2));
            while (x != 0)
            {
                int t = key / Convert.ToInt32(Math.Pow(2, x));
                if (t * Convert.ToInt32(Math.Pow(2, x)) == key)
                    return new Point(x, (t + 1) / 2);
                x--;
            }
            return new Point(0, (key + 1) / 2);
        }
    }
}
