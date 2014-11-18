using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class AVLNode : AbsTree<AVLNode, int>
    {

        public AVLNode(int name)//узел дерева авл
        {
            Value = name;
            height = 1;
        }

        public int height; // высота

        // метод добавления узла, принимает строку value
        public void insert(int value)
        {
            // сравниваем текущее значение со значением теперешнего корневого узла
            // и в соответствии с этим добавляем в левое или правое поддерево
            int compareResult = value.CompareTo(this.Value);

            if (compareResult < 0)
            {
                if (this.Left == null)
                    this.Left = new AVLNode(value);
                else
                    this.Left.insert(value); // присваиваем значение

                // проверяем балансировку
                // если высота левого дерева - высота правого дерева == 2 то
                if (getHeight(this.Left) - getHeight(this.Right) == 2)
                {
                    // если текущее значение меньше root.left.value
                    if (value.CompareTo(this.Left.Value) < 0)
                        // то выполняем одно вращение влево
                        singleRotation(0);
                    else
                        // в противном случае выполняем 2 вращения влево
                        doubleRotation(0);
                }
            }
            // в противном случае если результат сравнения со значением корнегого узла >0
            else if (compareResult > 0)
            {
                if (this.Right == null)
                    this.Right = new AVLNode(value);
                else
                    this.Right.insert(value); // присваиваем значение
                // если высота правого - высота левого == 2
                if (getHeight(this.Right) - getHeight(this.Left) == 2)
                {
                    // если текущее значение меньше root.right.value
                    if (value.CompareTo(this.Right.Value) > 0)
                        singleRotation(1);
                    else
                        doubleRotation(1);
                }
            }

            // высота дерева
            this.height = Math.Max(getHeight(this.Left), getHeight(this.Right)) + 1;
        }

        // одно вращение
        private void singleRotation(int side)
        {
            AVLNode temp = this;

            if (side == 1) // Левое вращение
            {
                AVLNode templ = this.Left;
                AVLNode tempr = this.Right;
                this.Right = this.Right.Right;
                this.Left = new AVLNode(this.Value);
                if(this.Left!=null)
                this.Left.Left = templ;
                this.Left.Right = tempr.Left;
                this.Value = tempr.Value;
                this.Left.height = Math.Max(getHeight(this.Left.Left), getHeight(this.Left.Right)) + 1;
                this.height = Math.Max(getHeight(this.Left), getHeight(this.Right)) + 1;
            }
            else if (side == 0) // Правое вращение
            {
                AVLNode templ = this.Left;
                AVLNode tempr = this.Right;
                this.Left = this.Left.Left;
                this.Right = new AVLNode(this.Value);
                this.Right.Right = tempr;
                this.Right.Left = templ.Right;
                this.Value = templ.Value;
                this.Right.height = Math.Max(getHeight(this.Right.Left), getHeight(this.Right.Right)) + 1;
                this.height = Math.Max(getHeight(this.Left), getHeight(this.Right)) + 1;
            }
        }

        private void doubleRotation(int side)
        {
            if (side == 0) //Двойное левое вращение
            {
                this.Left.singleRotation(1);
                this.singleRotation(0);
            }

            else if (side == 1) //Двойное правое вращение
            {
                this.Right.singleRotation(0);
                this.singleRotation(1);
            }
        }

        private static int getHeight(AVLNode a)
        {
            return a == null ? 0 : a.height;
        }

    }

    public class AVLTree
    {

        public AVLTree()
        {
            root = null;// Рут это значение корневого узла
        }

        // метод добавления узла, принимает строку value
        public void insert(int value)
        {
            /* Если root = null, то создаем новый корневой узел */
            if (root == null)
            {
                root = new AVLNode(value);
                return;
            }
            // сравниваем текущее значение со значением корневого узла
            // и в соответствии с этим добавляем в левое или правое поддерево
            int compareResult = value.CompareTo(root.Value);

            if (compareResult < 0)
            {
                if (root.Left == null)
                    root.Left = new AVLNode(value);
                else
                    root.Left.Value = value; // присваиваем значение

                // проверяем балансировку
                // если высота левого дерева - высота правого дерева == 2 то
                if (getHeight(root.Left) - getHeight(root.Right) == 2)
                    // если текущее значение меньше root.left.value
                    if (value.CompareTo(root.Left.Value) < 0)
                        // то выполняем одно вращение влево
                        singleRotation(root, 0);
                    else
                        // в противном случае выполняем 2 вращения влево
                        doubleRotation(root, 0);
                // в противном случае если результат сравнения со значением корнегого узла >0
                else if (compareResult > 0)
                {
                    root.Right.Value = value; // присваиваем значение
                    // если высота правого - высота левого == 2
                    if (getHeight(root.Right) - getHeight(root.Left) == 2)
                    {
                        // если текущее значение меньше root.right.value
                        if (value.CompareTo(root.Right.Value) > 0)
                            root = singleRotation(root, 1);
                        else
                            root = doubleRotation(root, 1);
                    }
                }

                // высота дерева
                root.height = Math.Max(getHeight(root.Left), getHeight(root.Right)) + 1;
            }
        }

        // одно вращение
        private AVLNode singleRotation(AVLNode node, int side)
        {
            AVLNode temp = node;

            if (side == 0) // Левое вращение
            {
                temp = node.Left;
                node.Left = temp.Right;
                temp.Right = node;
                node.height = Math.Max(getHeight(node.Left), getHeight(node.Right)) + 1;
                temp.height = Math.Max(getHeight(temp.Left), getHeight(node)) + 1;
            }
            else if (side == 1) // Правое вращение
            {
                temp = node.Right;
                node.Right = temp.Left;
                temp.Left = node;
                node.height = Math.Max(getHeight(node.Left), getHeight(node.Right)) + 1;
                temp.height = Math.Max(getHeight(temp.Right), getHeight(node)) + 1;
            }

            return temp;
        }
        private AVLNode doubleRotation(AVLNode node, int side)
        {
            if (side == 0) //Двойное левое вращение
            {
                node.Left = singleRotation(node.Left, 1);
                return singleRotation(node, 0);
            }

            else if (side == 1) //Двойное правое вращение
            {
                node.Right = singleRotation(node.Right, 0);
                return singleRotation(node, 1);
            }

            return node;
        }

        public AVLNode SearchNode(int value, AVLNode node)//поиск 
        {

            if (root == null)
                return null;
            else
            {
                if (node.Value == value)
                    return node;
                else if (value.CompareTo(node.Value) < 0)
                    return SearchNode(value, root.Left);
                else
                    return SearchNode(value, root.Right);
            }
        }

        public void Draw()
        {
            root.DrawTree();
        }

        private AVLNode root;

        private int getHeight(AVLNode a)
        {
            return a == null ? 0 : a.height;
        }
    }
}
