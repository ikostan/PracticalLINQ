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
        public TestContext testContext { get; set; }

        [TestMethod]
        public void BuildIntSequanceTest()
        {
            //Arrange
            Builder b = new Builder();

            //Act
            var range = b.BuildIntSequance();

            //foreach (var item in range)
            //{
            //    testContext.WriteLine(item.ToString());
            //}

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

            //foreach (var item in range)
            //{
            //    testContext.WriteLine(item.ToString());
            //}

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

            //foreach (var item in range)
            //{
            //    testContext.WriteLine(item.ToString());
            //}

            //Assert
            Assert.IsNotNull(chars);
            Assert.AreEqual(10, chars.Count());
            Assert.AreEqual('A', chars.First());
            Assert.AreEqual('J', chars.Last());
        }
    }
}
