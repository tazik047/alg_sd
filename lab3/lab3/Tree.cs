using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Tree
    {
        public Tree Left { get; set; }
        public Tree Right { get; set; }

        public int Value { get; set; }

        public Tree(int v)
        {
            Value = v;
        }
    }
}
