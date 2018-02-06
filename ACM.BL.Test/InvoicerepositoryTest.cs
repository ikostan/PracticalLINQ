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
            InvoiceRepository invoiceRepository = new InvoiceRepository();
            var invoices = invoiceRepository.Retrieve();

            // Act
            var mean = invoiceRepository.CalculateMean(invoices);

            // Assert
            Assert.AreEqual(6.875M, mean);
        }

        [TestMethod]
        public void CalculateMedianTest()
        {
            // Arrange
            InvoiceRepository invoiceRepository = new InvoiceRepository();
            var invoices = invoiceRepository.Retrieve();

            // Act
            var median = invoiceRepository.CalculateMedian(invoices);

            // Assert
            Assert.AreEqual(10.0M, median);
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
            InvoiceRepository invoiceRepository = new InvoiceRepository();
            var invoices = invoiceRepository.Retrieve().ToList();

            // Act
            var paid = invoiceRepository.GetIvoiceTotalByIsPaid(invoices);

            // NOT REALLY A TEST
        }

        [TestMethod]
        public void GetInvoiceTotalByIsPaidAndMonthTest()
        {
            // Arrange
            InvoiceRepository invoiceRepository = new InvoiceRepository();
            var invoices = invoiceRepository.Retrieve();

            // Act
            var quaery = invoiceRepository.GetInvoiceTotalByIsPaidAmountMonth(invoices.ToList());

            // NOT REALLY A TEST
        }

        [TestMethod]
        public void GetInvoiceTotalByCustomerTypeTest()
        {
            // Arrange
            CustomerRepository cr= new CustomerRepository();
            CustomerTypeRepository ct = new CustomerTypeRepository();
            var invoices = cr.Retrieve();
            var types = ct.Retrieve();

            // Act
            var quaery = cr.GetInvoiceTotalByCustomerType(invoices, types);

            // NOT REALLY A TEST
        }
    }
}
