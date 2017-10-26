using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XUnitTestProject1;

namespace LeetCode
{
    class PathSum2
    {
        public IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            if (root == null) return new List<IList<int>>();
            var list = new List<IList<int>>();
            if (root.val == sum)
            {
                list.Add(new List<int>() { root.val});
                return list;
            }
            
            if(root.left!=null)
                list.AddRange(PathSum(root.left, sum - root.val));
            if (root.right != null)
                list.AddRange(PathSum(root.right, sum - root.val));
            list.ForEach((e) => {
                e.Insert(0, root.val);
            });
            return list;
        }
    }
}
