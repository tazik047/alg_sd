using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Splay_Tree_Node: AbsTree<Splay_Tree_Node, int> 
    {
        //родитель сплэй-узла
        public Splay_Tree_Node Parent { get; set; }

        public void init(Splay_Tree_Node self, int value,
            Splay_Tree_Node left = null, Splay_Tree_Node right = null, Splay_Tree_Node parent = null)
        {
            self.Left = left;
            self.Right = right;
            self.Value = value;
            self.Parent = parent;

        }
        #region для работы с указателями на родителей
        public void set_parent(Splay_Tree_Node child,
            Splay_Tree_Node parent)
        {
            if (child != null) child.Parent = parent;//если нулл, тогда становится корнем
        }

        public void keep_parent(Splay_Tree_Node v)
        {
            set_parent(v.Left, v);
            set_parent(v.Right, v);
        }
#endregion

        public void rotate(Splay_Tree_Node parent, Splay_Tree_Node child)
        //После обращения к любой вершине, она поднимается в корень.
        //Подъем реализуется через повороты вершин.
        //За один поворот, можно поменять местами родителя с ребенком
        {
            Splay_Tree_Node grandparent = parent.Parent;
            if (grandparent != null)
            {
                if (grandparent.Left == child) grandparent.Left = child;
                else { grandparent.Right = child; }
            }
            if (parent.Left == child)
            {
                parent.Left = child.Right;
                child.Right = parent;
            }
            else 
            {
                parent.Right = child.Left;
                child.Left = parent;
            }
            keep_parent(child);
            keep_parent(parent);
            child.Parent = grandparent;
        }

    }
    class Splay_Tree
    {
        public Splay_Tree()
        {
            root = null;
        }
       /* public Splay_Tree_Node SPlay(Splay_Tree_Node v)
        {
            if (v.Parent == null) 
                return v;
            Splay_Tree_Node parent = v.Parent;
            Splay_Tree_Node grandparent = parent.Parent;
            if(grandparent == null)
                //rotate()///?ругается что нет
        }*/
        private Splay_Tree_Node root;
    }
}

