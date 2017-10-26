using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XUnitTestProject1;

namespace LeetCode
{
    class FindBottomLeftTreeValueClass
    {
        public int FindBottomLeftValue(TreeNode root)
        {
            return find(root).Item2;
        }
        public Tuple<int, int> find(TreeNode root) {
            if (root.left == null && root.right==null) return new Tuple<int, int>(1,root.val);
            if (root.left != null && root.right==null) {
                var x = find(root.left);
                return new Tuple<int, int>(x.Item1 + 1, x.Item2);
            }
            if (root.right != null && root.left == null)
            {
                var x = find(root.right);
                return new Tuple<int, int>(x.Item1 + 1, x.Item2);
            }
            var left = find(root.left);
            var right = find(root.right);
            if (right.Item1 > left.Item1) return new Tuple<int, int>(right.Item1 + 1, right.Item2);
            else return new Tuple<int, int>(left.Item1 + 1, left.Item2);
        }
    }
}
