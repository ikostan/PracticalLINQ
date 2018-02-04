using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BL.Test
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void FindTestExistingCustomer()
        {
            // Arrange
            CustomerRepository repository = new CustomerRepository();
            var customerList = repository.Retrieve();

            // Act
            var result = repository.Find(customerList, 2);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.CustomerId);
            Assert.AreEqual("Baggins", result.LastName);
            Assert.AreEqual("Bilbo", result.FirstName);
        }

        [TestMethod]
        public void FindTestNotFound()
        {
            // Arrange
            CustomerRepository repository = new CustomerRepository();
            var customerList = repository.Retrieve();

            // Act
            var result = repository.Find(customerList, 42);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SortByNAmeTest()
        {
            //Arrange
            CustomerRepository cr = new CustomerRepository();
            var list = cr.Retrieve();

            //Act
            var sorted = cr.SortByName(list);

            //Assert
            /*
                 CustomerId = 2, 
                 FirstName="Bilbo",
                 LastName = "Baggins"
             */

            Assert.IsNotNull(list);
            Assert.IsNotNull(sorted);
            Assert.AreEqual(2, sorted.First().CustomerId);
            Assert.AreEqual("Bilbo", sorted.First().FirstName);
            Assert.AreEqual("Baggins", sorted.First().LastName);
            //CollectionAssert.AreEqual(expected, sorted);
        }

    }
}
