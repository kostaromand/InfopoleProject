using Microsoft.VisualStudio.TestTools.UnitTesting;
using InfopoleProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfopoleProject.Tests
{
    [TestClass()]
    public class TreeNodeTests
    {
        [TestMethod()]
        public void EqualsTest_CompareWithNull_falseReturned()
        {
            //arrange
            bool expected = false;
            TreeNode node = new TreeNode(null,0,"Test");
            TreeNode obj = null;
            //act
            bool actual = node.Equals(obj);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EqualsTest_DifferentId_falseReturned()
        {
            //arrange
            bool expected = false;
            TreeNode node = new TreeNode(null, 0, "Test");
            TreeNode obj = new TreeNode(null, 1, "Test");
            //act
            bool actual = node.Equals(obj);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EqualsTest_DifferentChildren_falseReturned()
        {
            //arrange
            bool expected = false;
            TreeNode node = new TreeNode(null, 0, "Test");
            new TreeNode(node, 1, "Test1");
            new TreeNode(node, 2, "Test2");
            TreeNode obj = new TreeNode(null, 0, "Test");
            new TreeNode(node, 1, "2Test1");
            new TreeNode(node, 2, "2Test2");
            //act
            bool actual = node.Equals(obj);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EqualsTest_SameObjects_trueReturned()
        {
            //arrange
            bool expected = true;
            TreeNode node = new TreeNode(null, 0, "Test");
            new TreeNode(node, 1, "Test1");
            new TreeNode(node, 2, "Test2");
            TreeNode obj = new TreeNode(null, 0, "Test");
            new TreeNode(obj, 1, "Test1");
            new TreeNode(obj, 2, "Test2");
            //act
            bool actual = node.Equals(obj);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void getAreaTest_701returned()
        {
            //arrange
            long expected = 701;
            TreeNode root = new TreeNode(null, 0, "TestRoot");
            TreeCreator treeCreator = new TreeCreator(root);
            treeCreator.addVectorOfNodes("Test1.Test11.Test111");
            treeCreator.addVectorOfNodes("Test2.Test21.Test211");
            treeCreator.addVectorOfNodes("Test2.Test22");
            var leafs = treeCreator.getLeafs(root);
            leafs[0].Requests.Add("test11", 5);
            leafs[0].Requests.Add("test12", 10);
            leafs[0].Requests.Add("test13", 20);
            leafs[1].Requests.Add("test21", 502);
            leafs[1].Requests.Add("test22", 52);
            leafs[1].Requests.Add("test23", 12);
            leafs[2].Requests.Add("test31", 100);
            //act
            long actual = root.Area;
            //assert
            Assert.AreEqual(expected,actual);
        }


        [TestMethod()]
        public void getTopRequestsTest_count3()
        {
            //arrange
            int count = 3;
            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add("test21", 502);
            expected.Add("test31", 100);
            expected.Add("test22", 52);
            TreeNode root = new TreeNode(null, 0, "TestRoot");
            TreeCreator treeCreator = new TreeCreator(root);
            treeCreator.addVectorOfNodes("Test1.Test11.Test111");
            treeCreator.addVectorOfNodes("Test2.Test21.Test211");
            treeCreator.addVectorOfNodes("Test2.Test22");
            var leafs = treeCreator.getLeafs(root);
            leafs[0].Requests.Add("test11", 5);
            leafs[0].Requests.Add("test12", 10);
            leafs[0].Requests.Add("test13", 20);
            leafs[1].Requests.Add("test21", 502);
            leafs[1].Requests.Add("test22", 52);
            leafs[1].Requests.Add("test23", 12);
            leafs[2].Requests.Add("test31", 100);
            //act
            var actual = root.GetTopRequests(count);
            bool result = expected.SequenceEqual(actual);
            //assert
            Assert.IsTrue(result);
        }
    }
}