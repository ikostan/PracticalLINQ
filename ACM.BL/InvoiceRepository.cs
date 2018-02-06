using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACM.BL
{
    public class InvoiceRepository
    {
        /// <summary>
        /// Return invoices 
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        public IEnumerable<Invoice> Retrieve()
        {
            List<Invoice> invoices = new List<Invoice>()
            {
                    new Invoice()
                          { InvoiceId = 1,
                            CustomerId = 1,
                            InvoiceDate=new DateTime(2013, 6, 20),
                            DueDate=new DateTime(2013, 7,29),
                            IsPaid=null,
                            Amount=199.99M,
                            NumberOfUnits=20,
                            DiscountPercent=0M},
                    new Invoice()
                          { InvoiceId = 2,
                            CustomerId = 1,
                            InvoiceDate=new DateTime(2013, 7, 20),
                            DueDate=new DateTime(2013, 8,20),
                            IsPaid=null,
                            Amount=98.50M,
                            NumberOfUnits=10,
                            DiscountPercent=10M},
                    new Invoice()
                          { InvoiceId = 3,
                            CustomerId = 2,
                            InvoiceDate=new DateTime(2013, 7, 25),
                            DueDate=new DateTime(2013, 8,25),
                            IsPaid=null,
                            Amount=250M,
                            NumberOfUnits=25,
                            DiscountPercent=10M},
                    new Invoice()
                          { InvoiceId = 4,
                            CustomerId = 3,
                            InvoiceDate=new DateTime(2013, 7, 1),
                            DueDate=new DateTime(2013, 8,1),
                            IsPaid=true,
                            Amount=20M,
                            NumberOfUnits=2,
                            DiscountPercent=15M},
                    new Invoice()
                          { InvoiceId = 5,
                            CustomerId = 1,
                            InvoiceDate=new DateTime(2013, 8, 20),
                            DueDate=new DateTime(2013, 9,29),
                            IsPaid=true,
                            Amount=225M,
                            NumberOfUnits=22,
                            DiscountPercent=10M},
                    new Invoice()
                          { InvoiceId = 6,
                            CustomerId = 2,
                            InvoiceDate=new DateTime(2013, 8, 20),
                            DueDate=new DateTime(2013, 8,20),
                            IsPaid=false,
                            Amount=75M,
                            NumberOfUnits=8,
                            DiscountPercent=0M},
                    new Invoice()
                          { InvoiceId = 7,
                            CustomerId = 3,
                            InvoiceDate=new DateTime(2013,8, 25),
                            DueDate=new DateTime(2013, 9,25),
                            IsPaid=null,
                            Amount=500M,
                            NumberOfUnits=42,
                            DiscountPercent=10M},
                    new Invoice()
                          { InvoiceId = 8,
                            CustomerId = 4,
                            InvoiceDate=new DateTime(2013, 8, 1),
                            DueDate=new DateTime(2013, 9,1),
                            IsPaid=true,
                            Amount=75M,
                            NumberOfUnits=7,
                            DiscountPercent=0M}};

            //var results = invoices.Where((i) => i.CustomerId == custId).ToList();
            //return results;

            return invoices;
        }

        /// <summary>
        /// Return invoices per Customer Id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public List<Invoice> Retrieve(int customerId)
        {
            var invoiceList = this.Retrieve();
            List<Invoice> filteredList = invoiceList
                                            .Where((i) => i.CustomerId == customerId)
                                            .ToList();
            return filteredList;
        }

        /// <summary>
        /// Calculate total amount for all invoices
        /// </summary>
        /// <param name="invoices"></param>
        /// <returns></returns>
        public decimal CalculateTotalAmountInvoice(IEnumerable<Invoice> invoices)
        {
            var total = invoices.Sum((i) => i.TotalAmount);
            return total;
        }

        /// <summary>
        /// Calculate total amount units sold
        /// </summary>
        /// <param name="invoices"></param>
        /// <returns></returns>
        public int CalculateTotalAmountUnitsSold(IEnumerable<Invoice> invoices)
        {
            var total = invoices.Sum((i) => i.NumberOfUnits);
            return total;
        }

        /// <summary>
        /// Group invoices by isPaid property
        /// </summary>
        /// <param name="invoices"></param>
        /// <returns></returns>
        public dynamic GetIvoiceTotalByIsPaid(List<Invoice> invoices)
        {
            //Quaery:
            var paidInvoices = invoices.GroupBy((i) => i.IsPaid ?? false, 
                                                inv => inv.TotalAmount,
                                                (key, val) => new
                                                    {
                                                        Key = key,
                                                        InvoiceNumber = val.Sum()
                                                    }
            );

            //Debug only:
            foreach (var item in paidInvoices)
            {
                Console.WriteLine($"{item.Key}: {item.InvoiceNumber}");
            }

            return paidInvoices;
        }

        /// <summary>
        /// Group By two params: isPaid, InvoiceDate
        /// </summary>
        /// <param name="invoices"></param>
        /// <returns></returns>
        public dynamic GetInvoiceTotalByIsPaidAmountMonth(List<Invoice> invoices)
        {
            var quaery = invoices
                .GroupBy(
                        (i) => new {
                            isPaid = i.IsPaid ?? false,
                            Month = i.InvoiceDate.ToString("MMMM")
                        },
                        inv => inv.TotalAmount,
                        (key, val) => new {
                            Key = key,
                            InvoiceAmount = val.Sum()
                        }
                )
                .OrderBy((k) => k.Key.isPaid);

            foreach (var item in quaery)
            {
                Console.WriteLine($"{item.Key.isPaid} => {item.Key.Month}, {item.InvoiceAmount}");
            }

            return quaery;
        }

        //End of Class
    }
}
