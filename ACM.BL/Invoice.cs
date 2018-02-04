using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACM.BL
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool? IsPaid { get; set; }

        public override string ToString()
        {
            return String.Format("Invoice id: {0}, Customer id: {1}", InvoiceId, CustomerId);
        }
    }
}
