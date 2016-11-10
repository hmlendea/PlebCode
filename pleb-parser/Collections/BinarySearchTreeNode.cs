using System;

namespace PlebCode.Infrastructure.Collections
{
    public class BinarySearchTreeNode<T> where T : IComparable<T>
    {
        public BinarySearchTreeNode<T> Parent { get; set; }

        public BinarySearchTreeNode<T> ChildLeft { get; set; }

        public BinarySearchTreeNode<T> ChildRight { get; set; }

        public T Element { get; set; }

        public BinarySearchTreeNode(T elem)
        {
            Parent = null;
            ChildLeft = null;
            ChildRight = null;
            Element = elem;
        }
    }
}
