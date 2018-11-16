using InfopoleProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfopoleProject.Tests
{
    public class TreeCreator
    {
        public TreeNode Root;
        private int id;
        public TreeCreator(TreeNode Root)
        {
            this.Root = Root;
            id = Root.Id+1;
        }
        public void addVectorOfNodes(string fullPath)
        {
            string[] names = fullPath.Split('.');
            TreeNode current = Root;
            TreeNode child;
            foreach (var name in names)
            {
                child = current.Children.Find(x => x.ShortName == name);
                if (child == null)
                {
                    child = new TreeNode(current, id++, name);
                }
                current = child;
            }
        }
        public TreeNode[] getLeafs(TreeNode node)
        {
            if (node.Children.Count == 0)
            {
                return new TreeNode[] { node };
            }
            var mass = (from n in node.Children select getLeafs(n)).ToArray();
            TreeNode[] leafs = new TreeNode[0];
            foreach(var elem in mass)
            {
                leafs= leafs.Concat(elem).ToArray();
            }
            return leafs;
        }
    }
}
