using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ACM.Library.Test
{
    [TestClass]
    public class BuilderTest
    {
        private TestContext _testContextInstance;

        /// <summary>
        ///  Gets or sets the test context which provides
        ///  information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get { return _testContextInstance; }
            set { _testContextInstance = value; }
        }

        [TestMethod]
        public void BuildIntSequanceTest()
        {
            //Arrange
            Builder b = new Builder();

            //Act
            var range = b.BuildIntSequance();

            foreach (var item in range)
            {
                TestContext.WriteLine(item.ToString());
            }

            //Assert
            Assert.IsNotNull(range);
            Assert.AreEqual(10, range.Count());
            Assert.AreEqual(0, range.First());
            Assert.AreEqual(9, range.Last());
        }

        [TestMethod]
        public void BuildRepeatbleIntSequanceTest()
        {
            //Arrange
            Builder b = new Builder();

            //Act
            var range = b.BuildRepeatbleIntSequance();

            foreach (var item in range)
            {
                TestContext.WriteLine(item.ToString());
            }

            //Assert
            Assert.IsNotNull(range);
            Assert.AreEqual(10, range.Count());
            Assert.AreEqual(1, range.First());
            Assert.AreEqual(1, range.Last());
        }

        [TestMethod]
        public void BuildCharSequanceTest()
        {
            //Arrange
            Builder b = new Builder();

            //Act
            var chars = b.BuildCharSequance();

            foreach (var item in chars)
            {
                TestContext.WriteLine(item.ToString());
            }

            //Assert
            Assert.IsNotNull(chars);
            Assert.AreEqual(10, chars.Count());
            Assert.AreEqual('A', chars.First());
            Assert.AreEqual('J', chars.Last());
        }

        [TestMethod]
        public void CompareSequencesTest()
        {
            //Arrange
            Builder b = new Builder();

            //Act
            var list = b.CompareSequences();

            foreach (var item in list)
            {
                //System.Diagnostics.Debug.WriteLine(item);
                TestContext.WriteLine(item.ToString());
            }

            //Assert
            Assert.IsNotNull(list);
            //Assert.AreEqual(4, list.Count());
            //Assert.AreEqual(0, list.First());
            //Assert.AreEqual(9, list.Last());
        }
    }
}
