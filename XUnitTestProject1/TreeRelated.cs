using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    class TreeRelated
    {//123
        //213

            //23,2
            //23,3
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder.Length == 0) return null;
            var root = new TreeNode(preorder[0]);
            var inorderList = inorder.ToList();
            var index = inorderList.FindIndex(t => t == preorder[0]);
            var rightNodesInorder = inorderList.Skip(index + 1);
            var leftNodesInorder = inorderList.Take(index);
            var skip = leftNodesInorder.Count()+1;
            if (leftNodesInorder.Count() > 0)
            {
                root.left = BuildTree( preorder.Skip(1).ToArray(), leftNodesInorder.ToArray());
            }
            if (rightNodesInorder.Count() > 0)
            {
                root.right = BuildTree(preorder.Skip(skip).ToArray(), rightNodesInorder.ToArray());
            }


            return root;
        }

        public TreeNode BuildTreeWithPostOrder(int[] inorder,int[] postorder)
        {
            if (postorder.Length == 0) return null;

            var root = new TreeNode(postorder[postorder.Length-1]);
            var inorderList = inorder.ToList();
            var index = inorderList.FindIndex(t => t == root.val);
            var rightNodesInorder = inorderList.Skip(index + 1);
            var leftNodesInorder = inorderList.Take(index);
            var skip = leftNodesInorder.Count() + 1;
            if (leftNodesInorder.Count() > 0)
            {
                root.left = BuildTreeWithPostOrder( leftNodesInorder.ToArray(),postorder.Take(leftNodesInorder.Count()).ToArray());
            }
            if (rightNodesInorder.Count() > 0)
            {
                root.right = BuildTreeWithPostOrder( rightNodesInorder.ToArray(),postorder.Skip(leftNodesInorder.Count()).Take(rightNodesInorder.Count()).ToArray());
            }


            return root;
        }

        public void PrintNode(TreeNode root, int level) {
            if (level != 1) {
                if (root.left != null) PrintNode(root.left, level - 1);
                if (root.right != null) PrintNode(root.right, level - 1);
                return;
            }
            Console.WriteLine(root.val);
        }
        
    }
    public class TreeTest
    {


    }
 }
