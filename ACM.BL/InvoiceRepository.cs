using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACM.BL
{
    public class InvoiceRepository
    {
        /// <summary>
        /// Return invoices per Customer Id
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        public IEnumerable<Invoice> Retrieve(int custId)
        {
            List<Invoice> invoices = new List<Invoice>()
            {
                new Invoice(){
                    InvoiceId = 1,
                    CustomerId = 1,
                    InvoiceDate = new DateTime(2013, 6, 20),
                    DueDate = new DateTime(2013, 8, 29),
                    IsPaid = null,
                    Amount = 199.99M,
                    NumberOfUnits=20,
                    DiscountPercent=0M
                },
                new Invoice(){
                    InvoiceId = 2,
                    CustomerId =1,
                    InvoiceDate = new DateTime(2013, 7, 20),
                    DueDate = new DateTime(2013, 8, 20),
                    IsPaid = null,
                    Amount = 98.50M,
                    NumberOfUnits=10,
                    DiscountPercent=10M
                },
                new Invoice(){
                    InvoiceId = 3,
                    CustomerId = 2,
                    InvoiceDate = new DateTime(2013, 7, 25),
                    DueDate = new DateTime(2013, 8, 25),
                    IsPaid = null,
                    Amount = 500M,
                    NumberOfUnits=42,
                    DiscountPercent=10M
                },
                new Invoice(){
                    InvoiceId = 4,
                    CustomerId = 3,
                    InvoiceDate = new DateTime(2013, 7, 1),
                    DueDate = new DateTime(2013, 9, 1),
                    IsPaid = null,
                    Amount = 75M,
                    NumberOfUnits=7,
                    DiscountPercent=0M
                }
            };

            var results = invoices.Where((i) => i.CustomerId == custId).ToList();

            return results;
        }

        //End of Class
    }
}
