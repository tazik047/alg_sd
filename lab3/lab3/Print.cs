using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class Print<T> : Form
    {
        private Tree<T> tree;

        private Tree<Point> position;

        private int circleSize = 17;

        public Print()
        {
            InitializeComponent();
            position = new Tree<Point>();
        }

        public Print(Tree<T> tree)
            : this()
        {
            this.tree = tree;
            creartePos(position, tree);
            drawTree();
        }

        private void drawTree()
        {
            int height = countHeight(tree);
            int posX = 0;
            if(height==1){

            }
            posX = Convert.ToInt32(Math.Pow(2, height - 1) - 1);
            List<Tree<T>> treeChilds = new List<Tree<T>>() { tree };
            List<Tree<Point>> positionChilds = new List<Tree<Point>>() { position };
            int posY = 30;
            pictureBox1.Size = new Size(posX * circleSize * 2 + circleSize,posY+height*50);
            while (height != 0)
            {
                drawElementTree(treeChilds, positionChilds, posX * circleSize, posY);
                treeChilds = getNewChild(treeChilds);
                positionChilds = getNewChild(positionChilds);
                posX -= 1;
                posX /= 2;
                posY += 50;
                height--;
            }
            pictureBox1.Invalidate();
        }

        private List<Tree<E>> getNewChild<E>(List<Tree<E>> treeChilds)
        {
            List<Tree<E>> res = new List<Tree<E>>();
            foreach (var i in treeChilds)
            {
                if (i == null)
                    res.AddRange(new List<Tree<E>>() { null, null });
                else
                    res.AddRange(new List<Tree<E>>() { i.Left, i.Right });
            }
            return res;
        }

        private void drawElementTree(List<Tree<T>> treeChilds, List<Tree<Point>> position, int posX, int posY)
        {
            int pos = posX + circleSize;
            position[0].Value = new Point(posX, posY);
            for (int i = 1; i < treeChilds.Count; i++)
            {
                pos += posX * 2 + circleSize;
                if(treeChilds!=null)
                position[i].Value = new Point(pos, posY);
                pos += circleSize;
            }
        }

        private int countHeight<E>(Tree<E> t)
        {
            if (t == null)
                return 0;
            return countHeight(t.Left) > countHeight(t.Right) ? 
                (countHeight(t.Left) + 1) : (countHeight(t.Right) + 1);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            draw(g, position, tree);
        }

        private void draw(Graphics g, Tree<Point> poin, Tree<T> t)
        {
            if (poin == null)
                return;

            Point p = poin.Value;
            g.DrawEllipse(Pens.Black, p.X, p.Y, circleSize, circleSize);
            g.DrawString(t.Value.ToString(), Font, Brushes.Black, p.X+1, p.Y+2);
            if (t.Left != null)
            {
                g.DrawLine(Pens.Black, poin.Value.X + 2, poin.Value.Y + 15, poin.Left.Value.X + 15, poin.Left.Value.Y + 2);
                draw(g, poin.Left, t.Left);
            }
            if (t.Right != null)
            {
                g.DrawLine(Pens.Black, poin.Value.X + 15, poin.Value.Y + 15, poin.Right.Value.X + 2, poin.Right.Value.Y + 2);
                draw(g, poin.Right, t.Right);
            }
        }

        private void creartePos(Tree<Point> p, Tree<T> t)
        {
            if (t == null)
                return;
            if (t.Left != null)
            {
                p.Left = new Tree<Point>();
                creartePos(p.Left, t.Left);
            }
            if (t.Right != null)
            {
                p.Right = new Tree<Point>();
                creartePos(p.Right, t.Right);
            }
        }
    }
}
