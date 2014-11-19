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
    public partial class Print<C, T> : Form where C : AbsTree<C,T>
    {
        private AbsTree<C,T> tree;

        private Tree<Point> position;

        private int circleSize = 17;

        public Print()
        {
            InitializeComponent();
            position = new Tree<Point>(new Point());
        }

        public Print(AbsTree<C, T> tree)
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
            List<AbsTree<C, T>> treeChilds = new List<AbsTree<C, T>>() { tree };
            List<Tree<Point>> positionChilds = new List<Tree<Point>>() { position };
            int posY = 30;
            pictureBox1.Size = new Size(posX * circleSize * 2 + circleSize+5,posY+height*50);
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

        private List<Tree<Point>> getNewChild(List<Tree<Point>> treeChilds)
        {
            List<Tree<Point>> res = new List<Tree<Point>>();
            foreach (var i in treeChilds)
            {
                if (i == null)
                    res.AddRange(new List<Tree<Point>>() { null, null });
                else
                    res.AddRange(new List<Tree<Point>>() { i.Left, i.Right });
            }
            return res;
        }

        private List<AbsTree<C, T>> getNewChild(List<AbsTree<C, T>> treeChilds)
        {
            List<AbsTree<C, T>> res = new List<AbsTree<C, T>>();
            foreach (var i in treeChilds)
            {
                if (i == null)
                    res.AddRange(new List<AbsTree<C, T>>() { null, null });
                else
                    res.AddRange(new List<AbsTree<C, T>>() { i.Left, i.Right });
            }
            return res;
        }

        private void drawElementTree(List<AbsTree<C, T>> treeChilds, List<Tree<Point>> position, int posX, int posY)
        {
            int pos = posX + circleSize;
            if (treeChilds[0] != null)
                position[0].Value = new Point(posX, posY);
            for (int i = 1; i < treeChilds.Count; i++)
            {
                pos += posX * 2 + circleSize;
                if (treeChilds[i] != null)
                    position[i].Value = new Point(pos, posY);
                pos += circleSize;
            }
        }

        private int countHeight(AbsTree<C,T> t)
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

        private void draw(Graphics g, Tree<Point> poin, AbsTree<C, T> t)
        {
            if (poin == null)
                return;

            Point p = poin.Value;
            g.DrawEllipse(Pens.Black, p.X, p.Y, circleSize, circleSize);
            int r;
            if(Int32.TryParse(t.Value.ToString(), out r)){
                g.DrawString(t.Value.ToString(), Font, Brushes.Black, p.X+1, p.Y+2);
            }
            else{
                StringFormat f = new StringFormat();
                f.FormatFlags = StringFormatFlags.DirectionVertical;
                g.DrawString(t.Value.ToString(), Font, Brushes.Black, p.X+1, p.Y+2, f);
            }
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

        private void creartePos(Tree<Point> p, AbsTree<C, T> t)
        {
            if (t == null)
                return;
            if (t.Left != null)
            {
                p.Left = new Tree<Point>(new Point());
                creartePos(p.Left, t.Left);
            }
            if (t.Right != null)
            {
                p.Right = new Tree<Point>(new Point());
                creartePos(p.Right, t.Right);
            }
        }


    }
}
