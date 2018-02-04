using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.Library.Test
{
    [TestClass]
    public class StringExtensionsTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void ConvertToTitleCase()
        {
            // Arrange
            var source = "the return of the king";
            var expected = "The Return Of The King";

            // Act
            //var result = StringExtensions.ConvertToTitleCase(source); //Calling as a standart method
            var result = source.ConvertToTitleCase(); //Calling as an extention method

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

    }
}
