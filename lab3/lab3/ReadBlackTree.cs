using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class ReadBlackTree : AbsTree<ReadBlackTree, int>
    {
        private ReadBlackTree parent;

        public ReadBlackTree(int v)
        {
            color = Color.Black;
            Value = v;
        }

        private ReadBlackTree(int v, Color c, ReadBlackTree parent)
        {
            color = c;
            this.parent = parent;
            Value = v;
        }

        public void Insert(int a)
        {
            var root = this;
            ReadBlackTree node = new ReadBlackTree(a);
            node.color = Color.Red;
            while (true)
            {
                if (a > root.Value)
                {
                    if (root.Right == null)
                    {
                        root.Right = node;
                        node.parent = root;
                        while (root != this)
                        {
                            fixTrouble(root, node);
                            node = root;
                            root = root.parent;
                        }
                        this.color = Color.Black;
                        break;
                    }
                    root = root.Right;
                }
                else if (a < root.Value)
                {
                    if (root.Left == null)
                    {
                        root.Left = node;
                        node.parent = root;
                        while (root != this)
                        {
                            fixTrouble(root, node);
                            node = root;
                            root = root.parent;
                        }
                        this.color = Color.Black;
                        break;
                    }
                    root = root.Left;
                }
            }
            
        }

        private void fixTrouble(ReadBlackTree root, ReadBlackTree newChild){
            if (root.parent == null)
                return;
            if (root == root.parent.Left) // если отец слева от дедушки.
            {
                if (root.color == Color.Red && root.color == newChild.color)  // проверяем, оба ли красные.
                {
                    // проверяем дядю ребенка
                    if (root.parent.Right == null ||
                        root.parent.Right.color == Color.Black)  // p.s лист всегда черный если он null.
                    {
                        if (root.Right == newChild)
                        {
                            newChild.parent = root.parent;
                            root.parent.Left = newChild;
                            root.parent = newChild;
                            newChild.parent.Left = root;
                            root.Right = null;
                            newChild.Left = root;
                            newChild = newChild.Left;  // меняем сейчас ранен созданные  элемент с новым,
                            root = newChild.parent;    // чтоб можно было для следующего случая использовать.
                        }

                        if (root.parent.parent == null) // если дедушка и есть корень.
                        {
                            var newRight = new ReadBlackTree(this.Value, Color.Red, this);
                            newRight.Right = this.Right;
                            if (this.Right != null)
                                this.Right.parent = newRight;
                            newRight.Left = root.Right;
                            if (root.Right != null)
                                root.Right.parent = newRight;
                            this.Value = root.Value;
                            this.Right = newRight;
                            this.Left = newChild;
                            newChild.parent = this;
                            
                        }

                        else
                        {
                            var grand = root.parent;
                            grand.Left = root.Right;
                            if (root.Right != null)
                                root.Right.parent = grand.Left;
                            grand.color = Color.Red;
                            root.Right = grand;
                            root.color = Color.Black;
                            root.parent = grand.parent;
                            if (grand.parent.Left == grand)
                                root.parent.Left = root;
                            else
                                root.parent.Right = root;
                            grand.parent = root;
                        }
                    }

                    else if (root.parent.Right.color == Color.Red)
                    {
                        root.parent.color = Color.Red;
                        root.color = Color.Black;
                        root.parent.Right.color = Color.Black;
                    }
                }
            }
            else // справа. все зеркально, относительно того, что выше.
            {
                if (root.color == Color.Red && root.color == newChild.color)  // проверяем, оба ли красные.
                {
                    // проверяем дядю ребенка
                    if (root.parent.Left == null ||
                        root.parent.Left.color == Color.Black)  // p.s лист всегда черный.
                    {
                        if (root.Left == newChild)
                        {
                            newChild.parent = root.parent;
                            root.parent.Right = newChild;
                            root.parent = newChild;
                            root.Left = null;
                            newChild.Right = root;
                            newChild = newChild.Right;  // меняем сейчас ранен созданные  элемент с новым,
                            root = newChild.parent;    // чтоб можно было для следующего случая использовать.
                        }

                        ////////////////////////////////////////////////////////
                        if (root.parent.parent == null) // если дедушка и есть корень.
                        {
                            var newLeft = new ReadBlackTree(this.Value, Color.Red, this);
                            newLeft.Left = this.Left;
                            if (this.Left != null)
                                this.Left.parent = newLeft;
                            newLeft.Right = root.Left;
                            if (root.Left != null)
                                root.Left.parent = newLeft;
                            this.Value = root.Value;
                            this.Left = newLeft;
                            this.Right = newChild;
                            newChild.parent = this;
                        }

                        else
                        {
                            var grand = root.parent;
                            grand.Right = root.Left;
                            if (root.Left != null)
                                root.Left.parent = grand;
                            grand.color = Color.Red;
                            root.Left = grand;
                            root.color = Color.Black;
                            root.parent = grand.parent;
                            if (grand.parent.Left == grand)
                                root.parent.Left = root;
                            else
                                root.parent.Right = root;
                            grand.parent = root;
                        }
                    }

                    else if (root.parent.Left.color == Color.Red)
                    {
                        root.parent.color = Color.Red;
                        root.color = Color.Black;
                        root.parent.Left.color = Color.Black;
                    }
                }
            }
        }

        public static bool operator ==(ReadBlackTree f, ReadBlackTree s)
        {
            try
            {
                return f.Equals(s);
            }
            catch (NullReferenceException)
            {
                try
                {
                    return s.Equals(f);
                }
                catch (NullReferenceException)
                {
                    return true;
                }
            }
        }

        public static bool operator !=(ReadBlackTree f, ReadBlackTree s)
        {
            return !(f == s);
        }

        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Value == ((ReadBlackTree)obj).Value && color == ((ReadBlackTree)obj).color;
        }

        public override int GetHashCode()
        {
            return Value;
        }
    }
}
