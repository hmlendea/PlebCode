using System;

namespace PlebCode.Infrastructure.Collections
{
    public class BinarySearchTreeIterator<T> where T : IComparable<T>
    {
        private BinarySearchTreeNode<T> currentNode;

        /// <summary>
        /// Gets the current element
        /// </summary>
        /// <returns>The current element</returns>
        public T CurrentElement
        {
            get
            {
                return currentNode.Element;
            }
        }

        /// <summary>
        /// Checks wether the current node is valid
        /// </summary>
        /// <returns>True if node is valid, false otherwise</returns>
        public bool Valid
        {
            get
            {
                return currentNode != null;
            }
        }

        /// <summary>
        /// Initializes a new PlebCode.Infrastructure.Collections.BinarySearchTreeIterator<T>
        /// </summary>
        /// <param name="root">The root node</param>
        public BinarySearchTreeIterator(BinarySearchTreeNode<T> root)
        {
            this.currentNode = GetMinimum(root);
        }

        /// <summary>
        /// Goes to the next node in the tree
        /// </summary>
        public void Next()
        {
            if (currentNode.ChildRight != null)
            {
                currentNode = GetMinimum(currentNode.ChildRight);
                return;
            }

            BinarySearchTreeNode<T> y = currentNode.Parent;
            BinarySearchTreeNode<T> x = currentNode;

            while (y != null && x == y.ChildRight)
            {
                x = y;
                y = y.Parent;
            }

            currentNode = y;
        }

        /// <summary>
        /// Goes to the previous element in the tree
        /// </summary>
        public void Previous()
        {
            if (currentNode.ChildLeft != null)
            {
                currentNode = GetMaximum(currentNode.ChildLeft);
                return;
            }

            BinarySearchTreeNode<T> y = currentNode.Parent;;
            BinarySearchTreeNode<T> x = currentNode;

            while (y != null && x == y.ChildLeft)
            {
                x = y;
                y = y.Parent;
            }

            currentNode = y;
        }

        /// <summary>
        /// Gets the minimum element in the tree
        /// </summary>
        /// <param name="root">The root node</param>
        /// <returns>The minimum element</returns>
        private BinarySearchTreeNode<T> GetMinimum(BinarySearchTreeNode<T> root)
        {
            if (root == null)
                return null;

            if (root.ChildLeft != null)
                return GetMinimum(root.ChildLeft);

            return root;
        }

        /// <summary>
        /// Gets the maximum element in the tree
        /// </summary>
        /// <param name="root">The root node</param>
        /// <returns>The maximum element</returns>
        private BinarySearchTreeNode<T> GetMaximum(BinarySearchTreeNode<T> root)
        {
            if (root == null)
                return null;

            if (root.ChildRight != null)
                return GetMaximum(root.ChildRight);

            return root;
        }
    }
}
