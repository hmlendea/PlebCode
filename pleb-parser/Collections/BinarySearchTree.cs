using System;

namespace PlebCode.Infrastructure.Collections
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        internal BinarySearchTreeNode<T> root;

        protected int Count { get; private set; }

        public bool Empty
        {
            get
            {
                return (root == null);
            }
        }

        public BinarySearchTree()
        {
            root = null;
            Count = 0;
        }

        public void Insert(T el)
        {
            BinarySearchTreeNode<T> node = new BinarySearchTreeNode<T>(el);

            if (root == null)
                root = node;
            else
                InsertNode(root, node);

            Count += 1;
        }

        private void InsertNode(BinarySearchTreeNode<T> parent, BinarySearchTreeNode<T> node)
        {
            if (node.Element.CompareTo(parent.Element) < 0)
            {
                if (parent.ChildLeft == null)
                {
                    parent.ChildLeft = node;
                    node.Parent = parent;
                }
                else
                    InsertNode(parent.ChildLeft, node);
            }
            else if (node.Element.CompareTo(parent.Element) > 0)
            {
                if (parent.ChildRight == null)
                {
                    parent.ChildRight = node;
                    node.Parent = parent;
                }
                else
                    InsertNode(parent.ChildRight, node);
            }
        }

        public virtual void Remove(T el)
        {
            BinarySearchTreeNode<T> node = SearchElement_Rec(el, root);

            // Has no children
            if (node.ChildLeft == null && node.ChildRight == null)
            {
                if (node.Parent != null)
                {
                    if (node.Parent.ChildLeft == node)
                        node.Parent.ChildLeft = null;
                    else
                        node.Parent.ChildRight = null;
                }
                node = null;
                Count -= 1;
            }
            // Has one child (Left)
            else if (node.ChildRight == null)
            {
                if (node.Parent != null)
                {
                    if (node.Parent.ChildLeft == node)
                    {
                        node.ChildLeft.Parent = node.Parent;
                        node.Parent.ChildLeft = node.ChildLeft;
                    }
                    else
                    {
                        node.ChildLeft.Parent = node.Parent;
                        node.Parent.ChildRight = node.ChildLeft;
                    }
                }
                node = null;
                Count -= 1;
            }
            // Has one child (Right)
            else if (node.ChildLeft == null)
            {
                if (node.Parent != null)
                {
                    if (node.Parent.ChildRight == node)
                    {
                        node.ChildRight.Parent = node.Parent;
                        node.Parent.ChildRight = node.ChildRight;
                    }
                    else
                    {
                        node.ChildRight.Parent = node.Parent;
                        node.Parent.ChildLeft = node.ChildRight;
                    }
                }
                node = null;
                Count -= 1;
            }
            // Has both children
            else
            {
                BinarySearchTreeNode<T> x = node;

                while (x.ChildLeft != null)
                    x = x.ChildLeft;

                node.Element = x.Element;
                BinarySearchTreeNode<T> nodeChild = x.ChildLeft == null ? x.ChildRight : x.ChildLeft;
                if (x.ChildLeft != null)
                {
                    if (x.Parent.ChildLeft == x)
                        x.Parent.ChildLeft = nodeChild;
                    else
                        x.Parent.ChildRight = nodeChild;
                }
                else
                {
                    if (x.Parent.ChildLeft == x)
                        x.Parent.ChildLeft = nodeChild;
                    else
                        x.Parent.ChildRight = nodeChild;
                }
                Count -= 1;
            }
        }

        private BinarySearchTreeNode<T> SearchElement_Rec(T el, BinarySearchTreeNode<T> root)
        {
            BinarySearchTreeNode<T> node = root;

            if (node == null)
                return null;

            if (el.CompareTo(node.Element) == 0)
                return node;
            else if (el.CompareTo(node.Element) < 0)
                return SearchElement_Rec(el, node.ChildLeft);
            else
                return SearchElement_Rec(el, node.ChildRight);                       
        }

        public virtual void Clear()
        {
            root = null;
            Count = 0;
        }

        public bool Contains(T el)
        {
            if (SearchElement_Rec(el, root) != null)
                return true;
            return false;
        }

        public BinarySearchTreeIterator<T> CreateIterator()
        {
            return new BinarySearchTreeIterator<T>(root);
        }
    }
}
