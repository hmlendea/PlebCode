using System;

namespace PlebCode.Infrastructure.Collections
{
    public class BinarySearchTreeNode<T> where T : IComparable<T>
    {
        /// <summary>
        /// Gets or sets the parent node
        /// </summary>
        public BinarySearchTreeNode<T> Parent { get; set; }

        /// <summary>
        /// Gets or sets the left child node
        /// </summary>
        public BinarySearchTreeNode<T> ChildLeft { get; set; }

        /// <summary>
        /// Gets or sets the right child node
        /// </summary>
        public BinarySearchTreeNode<T> ChildRight { get; set; }

        /// <summary>
        /// Gets or sets the element
        /// </summary>
        public T Element { get; set; }

        /// <summary>
        /// Initializes a new PlebCode.Infrastructure.Collections.BinarySearchTreeNode<T>
        /// </summary>
        /// <param name="elem">Element</param>
        public BinarySearchTreeNode(T elem)
        {
            Parent = null;
            ChildLeft = null;
            ChildRight = null;
            Element = elem;
        }
    }
}
