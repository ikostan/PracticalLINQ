using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ACM.Library.Test
{
    [TestClass]
    public class BuilderTest
    {
        [TestMethod]
        public void BuildIntSequanceTest()
        {
            //Arrange
            Builder b = new Builder();

            //Act
            var range = b.BuildIntSequance();

            //Assert
            Assert.IsNotNull(range);
            Assert.AreEqual(10, range.Count());
            Assert.AreEqual(0, range.First());
            Assert.AreEqual(9, range.Last());
        }
    }
}
