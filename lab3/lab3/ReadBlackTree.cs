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

        public ReadBlackTree()
        {
            color = Color.Black;
        }

        public void Insert(int a)
        {
            var root = this;
            ReadBlackTree node = new ReadBlackTree();
            node.color = Color.Red;
            node.Value = a;
            while (true)
            {
                if (a > root.Value)
                {
                    if (root.Right == null)
                    {
                        root.Right = node;
                        node.parent = root;
                        if (root.color == Color.Red)
                        {

                        }
                        break;
                    }
                    root = root.Right;
                }
                else if (a < root.Value)
                {
                    if (root.Left == null)
                    {
                        //TODO
                        break;
                    }
                    root = root.Left;
                }
            }
            
        }

        public static bool operator== (ReadBlackTree f, ReadBlackTree s){
            return f.Value==s.Value && f.color==s.color;
        }

        private void fixTrouble(ReadBlackTree root, ReadBlackTree newChild){
            if (root == root.parent.Left) // если отец слева от дедушки.
            {
                if (root.color == Color.Red && root.color == root.Left.color)  // проверяем, оба ли красные.
                {
                    // проверяем дядю ребенка
                    if (root.parent.Right == null ||
                        root.parent.Right.color == Color.Black)  // p.s лист всегда черный.
                    {
                        if (root.Right == newChild)
                        {
                            newChild.parent = root.parent;
                            root.parent = newChild;
                            newChild.parent.Left = newChild;
                            root.Right = null;
                            newChild.Left = root;
                            newChild = newChild.Left;  // меняем сейчас ранен созданные  элемент с новым,
                            root = newChild.parent;    // чтоб можно было для следующего случая использовать.
                        }

                        if (root.parent.parent == null) // если дедушка и есть корень.
                        {

                        }

                        else
                        {
                            var grand = root.parent;
                            grand.Left = root.Right;
                            grand.color = Color.Red;
                            root.Right = grand;
                            root.color = Color.Black;
                            root.parent = grand.parent;
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
        }
    }

    enum childEnum
	{
	    Left,Right
	}
}
