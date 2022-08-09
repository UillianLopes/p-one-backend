using System;

namespace POne.Core.Collections
{
    public class TreeNode<T> : IComparable<TreeNode<T>>, IComparable<T> where T : IComparable<T>
    {

        public TreeNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

        public int CompareTo(TreeNode<T> other) => Value.CompareTo(other.Value);

        public int CompareTo(T other) => Value.CompareTo(other);
    }
}
