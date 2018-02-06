using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BL.Test
{
    [TestClass]
    public class InvoiceRepositoryTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void CalculateMeanTest()
        {
            // Arrange           

            // Act

            // Assert
        }

        [TestMethod]
        public void CalculateMedianTest()
        {
            // Arrange

            // Act

            // Assert
        }

        [TestMethod]
        public void CalculateModeTest()
        {
            // Arrange

            // Act

            // Assert
        }

        [TestMethod]
        public void CalculateTotalAmountInvoicedTest()
        {
            // Arrange
            InvoiceRepository invoiceRepository = new InvoiceRepository();
            var invoices = invoiceRepository.Retrieve();

            // Act
            var total = invoiceRepository.CalculateTotalAmountInvoice(invoices);

            // Assert
            Assert.AreEqual(1333.14M, total);
        }

        [TestMethod]
        public void CalculateTotalUnitsSoldTest()
        {
            // Arrange
            InvoiceRepository invoiceRepository = new InvoiceRepository();
            var invoices = invoiceRepository.Retrieve();

            // Act
            var total = invoiceRepository.CalculateTotalAmountUnitsSold(invoices);

            // Assert
            Assert.AreEqual(136, total);
        }

        [TestMethod]
        public void GetInvoiceTotalByIsPaidTest()
        {
            // Arrange

            // Act

            // NOT REALLY A TEST
        }

        [TestMethod]
        public void GetInvoiceTotalByIsPaidAndMonthTest()
        {
            // Arrange

            // Act

            // NOT REALLY A TEST
        }
    }
}
