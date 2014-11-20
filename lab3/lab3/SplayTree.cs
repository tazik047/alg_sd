using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class TreeNode : AbsTree<TreeNode, int>
    {
        public TreeNode Parent;

        public TreeNode(int key, TreeNode node)
        {
            this.Value = key;
            this.Parent = node;
        }


        public bool parentExists()
        {
            return Parent != null;
        }

        public bool leftExists()
        {
            return Left != null;
        }

        public bool rightExists()
        {
            return Right != null;
        }
    }

    public class SplayTree
    {
        private TreeNode root;

        public SplayTree(int v) { root = new TreeNode(v, null); }

        private void splay(TreeNode node)
        {
            if (node == null)
                return;
            while (node.parentExists())
            {
                TreeNode parent = node.Parent;
                if (!parent.parentExists())
                {
                    if (parent.Left == node)
                    {
                        rotateRight(parent);
                    }
                    else
                    {
                        rotateLeft(parent);
                    }
                }
                else
                {
                    TreeNode gparent = parent.Parent;
                    if (parent.Left == node && gparent.Left == parent)
                    {
                        rotateRight(gparent);
                        rotateRight(node.Parent);
                    }
                    else if (parent.Right == node &&
                          gparent.Right == parent)
                    {
                        rotateLeft(gparent);
                        rotateLeft(node.Parent);
                    }
                    else if (parent.Left == node &&
                          gparent.Right == parent)
                    {
                        rotateRight(parent);
                        rotateLeft(node.Parent);
                    }
                    else
                    {
                        rotateLeft(parent);
                        rotateRight(node.Parent);
                    }
                }
            }
        }

        private void rotateLeft(TreeNode x)
        {
            TreeNode y = x.Right;
            x.Right = y.Left;
            if (y.Left != null)
                y.Left.Parent = x;
            y.Parent = x.Parent;
            if (x.Parent == null)
                root = y;
            else
            {
                if (x == x.Parent.Left)
                    x.Parent.Left = (y);
                else
                    x.Parent.Right = (y);
            }
            y.Left = (x);
            x.Parent = (y);
        }

        private void rotateRight(TreeNode x)
        {
            TreeNode y = x.Left;
            x.Left = (y.Right);
            if (y.Right != null)
                y.Right.Parent = (x);
            y.Parent = (x.Parent);
            if (x.Parent == null)
                root = y;
            else
            {
                if (x == x.Parent.Left)
                    x.Parent.Left = (y);
                else
                    x.Parent.Right = (y);
            }
            y.Right = (x);
            x.Parent = (y);
        }

        public void insert(int key)
        {
            if (root == null)
            {
                root = new TreeNode(key, null);
                return;
            }

            insert(key, root);
            search(key);
        }

        private void insert(int key, TreeNode node)
        {
            if (key < node.Value)
            {
                if (node.leftExists())
                    insert(key, node.Left);
                else
                    node.Left = (new TreeNode(key, node));
            }

            if (key > node.Value)
            {
                if (node.rightExists())
                    insert(key, node.Right);
                else
                    node.Right = (new TreeNode(key, node));
            }
        }

        public bool search(int key)
        {
            if (root == null)
                return false;

            TreeNode node = search(key, root);
            splay(node);
            return node != null;
        }

        private TreeNode search(int key, TreeNode node)
        {
            if (key == node.Value)
                return node;

            if (key < node.Value)
            {
                if (!node.leftExists())
                    return null;
                return search(key, node.Left);
            }

            if (key > node.Value)
            {
                if (!node.rightExists())
                    return null;
                return search(key, node.Right);
            }

            return null;
        }

        public void DrawTree()
        {
            root.DrawTree();
        }

    }
}
