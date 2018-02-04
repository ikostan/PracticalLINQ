using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACM.BL
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? CustomerTypeId { get; set; }
        public string EmailAddress { get; set; }

        public List<Invoice> InvoiceList { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1}: {2}", FirstName, LastName, CustomerId);
        }
    }
}
