using System;

namespace PlebCode.Infrastructure.Collections
{
    /// <summary>
    /// Self-balancing Binary Search Tree
    /// </summary>
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        internal BinarySearchTreeNode<T> root;

        /// <summary>
        /// Gets the number of nodes.
        /// </summary>
        /// <returns>The node count</returns>
        protected int Count { get; private set; }

        /// <summary>
        /// Checks wether the tree is empty
        /// </summary>
        /// <returns>True if empty, false otherwise.</returns>
        public bool Empty
        {
            get
            {
                return (root == null);
            }
        }

        /// <summary>
        /// Initializes a new Binary Search Tre
        /// </summary>
        public BinarySearchTree()
        {
            root = null;
            Count = 0;
        }

        /// <summary>
        /// Inserts a new element in the tree
        /// </summary>
        /// <param name="el">Element</param>
        public void Add(T el)
        {
            BinarySearchTreeNode<T> node = new BinarySearchTreeNode<T>(el);

            if (root == null)
                root = node;
            else
                InsertNode(root, node);

            Count += 1;
        }

        /// <summary>
        /// Inserts a node as a child of another node
        /// </summary>
        /// <param name="parent">Parent</param>
        /// <param name="node">Inserted node</param>
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

        /// <summary>
        /// Removes a element from the tree
        /// </summary>
        /// <param name="el">Element</param>
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

        /// <summary>
        /// Recursively searches for a node in the tree
        /// </summary>
        /// <param name="el"></param>
        /// <param name="root"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Empties the tree
        /// </summary>
        public virtual void Clear()
        {
            root = null;
            Count = 0;
        }

        /// <summary>
        /// Checks wether the tree contains a certain element
        /// </summary>
        /// <param name="el">Element</param>
        /// <returns>True if element is contained, false otherwise</returns>
        public bool Contains(T el)
        {
            if (SearchElement_Rec(el, root) != null)
                return true;
            return false;
        }

        /// <summary>
        /// Creates an PlebCode.Infrastructure.Collections.BinarySearchTreeIterator<T> for the tree
        /// </summary>
        /// <returns>The iterator</returns>
        public BinarySearchTreeIterator<T> CreateIterator()
        {
            return new BinarySearchTreeIterator<T>(root);
        }
    }
}
