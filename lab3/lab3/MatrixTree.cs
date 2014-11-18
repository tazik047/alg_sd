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

        public MatrixTree()
            : base(0)
        {
        }

        /*
        def addKey(key,t):
    if t==None: return
    level,pos = getLevel(key)    
    node = tree(key,level,pos)
    
    if t.value==0 and t.left==None and t.right==None: # если отсутствуют другие элементы, то элемент включается в четное поддерево в качестве корня.        
        t.left=node
    else:
        if t.value==0: addKey(node.value,t.left) # если попытка добавить к нулевому уровню, то идем в левую подветвь
        else:
            t = findNode(node,t) # поиск в дереве элемента с которым может быть связан новый элемент
            
            elems = 2**fabs(level-t.level) # количество элементов под элементом
            last_pos = t.pos*elems # позиция последнего элемента
            first_pos = last_pos-elems+1 # позиция первого элемента
            
            while not pos in xrange(int(first_pos),int(last_pos)+1): # пока позиция нового элемента не входит в интервал позиций 
                elems *= 2 # удваиваем количество элементов в интервале
                first_pos = last_pos-elems+1  # перерасчет позиции первого элемента
                
            key1 = (2**first_pos)*(2*first_pos-1) # ключ первого элемента
            key2 = (2**first_pos)*(2*last_pos-1) # ключ последнего элемента
            xkey = (key1+key2)/2 # ключ общей вершины
            
            if t.value>node.value:
                t.right = tree(t.value,t.level,t.pos)
                t.left = node
            else:
                t.right = node
                t.left = tree(t.value,t.level,t.pos)
                
            t.value = xkey*/

        public void Add(int key, Tree<int> t)
        {
            if (t == null) return;
            Point levelAndPos = findHeightPos(key);
            Tree<int> node = new Tree<int>(key);
            if (t.Value == 0 && t.Left == null && t.Right == null)
                t.Left = node;
            else
            {
                t = findNode(node, t);
                int elems = Convert.ToInt32(Math.Pow(2,
                    Convert.ToInt32(Math.Abs(LevelAndPos(node).X - LevelAndPos(t).X))));
                int last_pos = LevelAndPos(t).X * elems;
                int first_pos = last_pos - elems + 1;

                while (first_pos <= LevelAndPos(node).Y && LevelAndPos(node).Y <= last_pos) // пока позиция нового элемента не входит в интервал позиций 
                {
                    elems *= 2; //удваиваем количество элементов в интервале
                    first_pos = last_pos - elems + 1;  // перерасчет позиции первого элемента
                }

                int key1 = Convert.ToInt32(Math.Pow(2, first_pos)) * (2 * first_pos - 1); //ключ первого элемента
                int key2 = Convert.ToInt32(Math.Pow(2, first_pos)) * (2 * last_pos - 1); // ключ последнего элемента
                int xkey = (key1 + key2) / 2; // ключ общей вершины

                if (t.Value > node.Value)
                {
                    t.Right = new Tree<int>(t.Value);
                    t.Left = node;
                }
                else
                {
                    t.Right = node;
                    t.Left = new Tree<int>(t.Value);
                }
                t.Value = xkey;
            }
            /*
            Point lev = findHeightPos(v);
            Point main = findHeightPos(Value);
            int raznost = main.X - lev.X;
            int count = Convert.ToInt32(Math.Pow(2, raznost));
            int maxPos = 2 * count;
            int minPos = maxPos - count + 1;
            if (minPos <= main.Y && main.Y <= maxPos)
            {

            }
            else
            {
                while (!(minPos <= main.Y && main.Y <= maxPos))
                {
                    count *= 2;
                    maxPos = 2 * count;
                    minPos = maxPos - count + 1;
                }

            }*/
        }

        private Tree<int> findNode(Tree<int> node, Tree<int> t)
        {
            if (t == null) return null;
            if (t.Right == null || t.Left == null)
                if (LevelAndPos(node).X - LevelAndPos(t).X >= 0) return t;
            Tree<int> r = findNode(node, t.Left);
            if (r != null) return r;
            return findNode(node, t.Right);
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

        /// <summary>
        /// X - уровень
        /// Y - позиция
        /// </summary>
        private static Point LevelAndPos(Tree<int> key)
        {
            if (key.Value == 0)
                return new Point();
            int x = Convert.ToInt32(Math.Log(key.Value, 2));
            while (x != 0)
            {
                int t = key.Value / Convert.ToInt32(Math.Pow(2, x));
                if (t * Convert.ToInt32(Math.Pow(2, x)) == key.Value)
                    return new Point(x, (t + 1) / 2);
                x--;
            }
            return new Point(0, (key.Value + 1) / 2);
        }
    }
}
