using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class AVLNode
    {
       
       public AVLNode(String name)//узел дерева авл
       {
          value = name;
       }
 
       public String value; // значение
       public int height; // высота
       public AVLNode left; // левое дерево
       public AVLNode right; // правое дерево
 
    }
 
    public class AVLTree
    {
       
       public AVLTree()
       {
           root = null;// Рут это значение корневого узла
       }
 
       // метод добавления узла, принимает строку value
       public void insert(String value)
       {
          /* Если root = null, то создаем новый корневой узел */
          if (root == null)
             root = new AVLNode(value);
 
          // сравниваем текущее значение со значением корневого узла
          // и в соответствии с этим добавляем в левое или правое поддерево
          int compareResult = value.CompareTo(root.value);
 
          if (compareResult < 0)
          {
             root.left.value = value; // присваиваем значение
 
             // проверяем балансировку
             // если высота левого дерева - высота правого дерева == 2 то
             if (root.left.height - root.right.height == 2)
                // если текущее значение меньше root.left.value
                if (value.CompareTo(root.left.value) < 0)
                   // то выполняем одно вращение влево
                   singleRotation(root, 0);
                else
                   // в противном случае выполняем 2 вращения влево
                   doubleRotation(root, 0);
             // в противном случае если результат сравнения со значением корнегого узла >0
             else if (compareResult > 0)
             {
                root.right.value = value; // присваиваем значение
                // если высота правого - высота левого == 2
                if (root.right.height - root.left.height == 2)
                {
                   // если текущее значение меньше root.right.value
                   if (value.CompareTo(root.right.value) > 0)
                      root = singleRotation(root, 1);
                   else
                      root = doubleRotation(root, 1);
                }
             }
 
             // высота дерева
             root.height = Math.Max(root.left.height, root.right.height) + 1;
          }
       }
 
       // одно вращение
       private AVLNode singleRotation(AVLNode node, int side)
       {
          AVLNode temp = node; 
 
          if (side == 0) // Левое вращение
          {
             temp = node.left;
             node.left = temp.right;
             temp.right = node;
             node.height = Math.Max(node.left.height, node.right.height) + 1;
             temp.height = Math.Max(temp.left.height, node.height) + 1;
          }
          else if (side == 1) // Правое вращение
          {
             temp = node.right;
             node.right = temp.left;
             temp.left = node;
             node.height = Math.Max(node.left.height, node.right.height) + 1;
             temp.height = Math.Max(temp.right.height, node.height) + 1;
          }
 
          return temp;
       }
       private AVLNode doubleRotation(AVLNode node, int side)
       {
          if (side == 0) //Двойное левое вращение
          {
             node.left = singleRotation(node.left, 1);
             return singleRotation(node, 0);
          }
 
          else if (side == 1) //Двойное правое вращение
          {
             node.right = singleRotation(node.right, 0);
             return singleRotation(node, 1);
          }
 
          return node;
       }
       public AVLNode SearchNode(String value, AVLNode node)//поиск 
       {
          
          if (root == null)
             return null;
          else
          {
             if (node.value == value)
                return node;
             else if (value.CompareTo(node.value) < 0)
                return SearchNode(value, root.left);
             else
                return SearchNode(value, root.right);
          }
       }
 
 
       private AVLNode root;
    }
}
