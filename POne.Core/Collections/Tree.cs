using System;

namespace POne.Core.Collections
{
    public class Tree<T> where T : IComparable<T>
    {
        public TreeNode<T> Root { get; set; }

        public void Add(T value)
        {
            if (Root == null)
            {
                Root = new TreeNode<T>(value);
                return;
            }

            Add(Root, value);
        }


        private void Add(TreeNode<T> current, T value)
        {
            var comparation = value.CompareTo(current.Value);
            if (comparation > 0)
            {
                if (current.Right == null)
                {
                    current.Right = new TreeNode<T>(value);
                    return;
                }

                Add(current.Right, value);
            }
            else if (comparation < 0)
            {
                if (current.Left == null)
                {
                    current.Left = new TreeNode<T>(value);
                    return;
                }

                Add(current.Left, value);
            }
        }

        public void Remove(T value)
        {
            if (Root == null)
                return;


        }

        private void Remove(TreeNode<T> current, T value)
        {
            var comparation = value
                .CompareTo(current.Value);

            if (comparation > 0)
            {
                if (current.Right is not TreeNode<T> right)
                    return;

                if (right.CompareTo(value) == 0)
                {
    
                    if (FindGreatest(right.Right) is TreeNode<T> greatestFromLeft )


                    return;
                }

                Remove(right, value);
            }
            else if (comparation < 0)
                Remove(current.Left, value);
            else
            {
            }
        }

        private void OverrideLeftValue()
        {

        }

        private TreeNode<T> FindGreatest(TreeNode<T> current)
        {
            if (current.Right is TreeNode<T> right)
                return FindSmallest(right);

            return current;
        }
        private TreeNode<T> FindSmallest(TreeNode<T> current)
        {
            if (current.Left is TreeNode<T> left)
                return FindSmallest(left);

            return current;
        }
    }
}
