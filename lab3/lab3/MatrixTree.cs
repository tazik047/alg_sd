using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class MatrixTree : Tree<int>
    {
        public MatrixTree(int v) : base(v) { }

        public void Add(int v)
        {
            Point lev = findHeightPos(v);
            int raznost = findHeightPos(Value).X - lev.X;
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
