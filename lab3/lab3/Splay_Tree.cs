using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Splay_Tree: AbsTree<Splay_Tree, int> 
    {
        //родитель сплэй-узла
        public Splay_Tree Parent { get; set; }

        public Splay_Tree(int value,
            Splay_Tree left = null, Splay_Tree right = null, Splay_Tree parent = null)
        {
            this.Left = left;
            this.Right = right;
            this.Value = value;
            this.Parent = parent;

        }
        #region для работы с указателями на родителей
        public void set_parent(Splay_Tree child,
            Splay_Tree parent)
        {
            if (child != null) child.Parent = parent;//если нулл, тогда становится корнем
        }

        public void keep_parent(Splay_Tree  v)
        {
            set_parent(v.Left, v);
            set_parent(v.Right, v);
        }
        #endregion

        public void rotate(Splay_Tree parent, Splay_Tree child)
        //После обращения к любой вершине, она поднимается в корень.
        //Подъем реализуется через повороты вершин.
        //За один поворот, можно поменять местами родителя с ребенком
        {
            Splay_Tree grandparent = parent.Parent;
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

        public Splay_Tree(int v)
        {
            root = null;
            Value = v; 
        }

        public Splay_Tree SPlay(Splay_Tree v)
        {
            if (v.Parent == null) 
                return v;
            Splay_Tree parent = v.Parent;
            Splay_Tree grandparent = parent.Parent;
            if (grandparent == null)
            {
                rotate(parent, v);
                return v;
            }
            else 
            {
                var zigzig = (grandparent.Left == parent) == (parent.Left == v);
                if (zigzig)
                {
                    rotate(grandparent, parent);
                    rotate(parent, v);
                }
                else 
                {
                    rotate(parent, v);
                    rotate(grandparent, v);
                }
                return SPlay(v);
            }

        }
        //поиск в splay-дереве отличается от обычной только на последней стадии:
        //после того, как вершина найдена, мы тянем ее вверх и делаем корнем через splay.
        public Splay_Tree find(Splay_Tree v, int value)
        {
            if (v == null)
                return null;
            if (value == v.Value)
                return SPlay(v);
            if ((value < v.Value) && (v.Left != null)) return find(v.Left, value);
            if ((value > v.Value) && (v.Right != null)) return find(v.Right, value);
            return SPlay(v);
        }

        //split получает на вход ключ и делит дерево на два.
        public List<Splay_Tree> split(Splay_Tree root, int value)
        {
            if (root == null) return new List<Splay_Tree>() { null, null };
            root = find(root, value);
            if (root.Value == value) 
            {
                set_parent(root.Left, null);
                set_parent(root.Right, null);
                return new List<Splay_Tree>() { Left, Right  };
            }
            if (root.Value < value)
            {
                Right = root.Right;
                root.Right = null;
                set_parent(Right, null);
                return new List<Splay_Tree>() { root, Right };
              
            }
            else
            {
                Left = root.Left;
                root.Left = null;
                set_parent(Left, null);
                return new List<Splay_Tree>() { Left, root };
            }
        }

        public Splay_Tree insert(Splay_Tree root, int key){
        
            var t = split(root, key);
            Left = t[0];
            Right = t[1];
            root = new Splay_Tree(key, Left, Right);
            keep_parent(root);
            return root;
        }


        private Splay_Tree root;
    }
}

