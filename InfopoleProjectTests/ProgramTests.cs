using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfopoleProject.Tests
{
    [TestClass()]
    public partial class ProgramTests
    {
        [TestMethod()]
        public void getCountTest_input_10_10returned()
        {
            //arrange
            int expected = 10;
            TestConsoleReader reader = new TestConsoleReader(new string[]{"10"});
            //act
            int actual = Program.getCount(reader);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void getCountTest_input_something_5returned()
        {
            //arrange
            int expected = 5;
            TestConsoleReader reader = new TestConsoleReader(new string[] { "something" });
            //act
            int actual = Program.getCount(reader);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void getCountTest_input_negtive4_5returned()
        {
            //arrange
            int expected = 5;
            TestConsoleReader reader = new TestConsoleReader(new string[] { "-4" });
            //act
            int actual = Program.getCount(reader);
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}