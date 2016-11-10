using System;

namespace PlebCode.Infrastructure.Collections
{
    public class BinarySearchTreeIterator<T> where T : IComparable<T>
    {
        private BinarySearchTreeNode<T> currentNode;

        public T CurrentElement
        {
            get
            {
                return currentNode.Element;
            }
        }

        public bool Valid
        {
            get
            {
                return currentNode != null;
            }
        }

        public BinarySearchTreeIterator(BinarySearchTreeNode<T> root)
        {
            this.currentNode = GetMinimum(root);
        }

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

        private BinarySearchTreeNode<T> GetMinimum(BinarySearchTreeNode<T> root)
        {
            if (root == null)
                return null;

            if (root.ChildLeft != null)
                return GetMinimum(root.ChildLeft);

            return root;
        }

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
