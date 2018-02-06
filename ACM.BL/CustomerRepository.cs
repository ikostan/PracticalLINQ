using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ACM.BL
{
    public class CustomerRepository
    {
        /// <summary>
        /// Find a customer by id
        /// </summary>
        /// <param name="customerList"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public Customer Find(List<Customer> customerList, int customerId)
        {
            Customer foundCustomer = null;

            //Generic method, using loop in order to find the customer 
            //foreach (var c in customerList)
            //{
            //    if (c.CustomerId == customerId)
            //    {
            //        foundCustomer = c;
            //        break;
            //    }
            //}

            //Using LINQ Quaery syntax:            
            //var c = from cust in customerList
            //        where cust.CustomerId == customerId
            //        select cust;

            //Get the result from the list
            //foundCustomer = c.ToArray()[0];
            //foundCustomer = c.First();

            //Using LINQ Method quaery:
            //var c = customerList.Where(
            //    (customer) => customer.CustomerId == customerId);
            //foundCustomer = customerList.First((cust) => cust.CustomerId == customerId); //Causes for Exception if nothing found

            //Returns null in case no valid results found
            foundCustomer = 
                customerList.FirstOrDefault(
                    (cust) => 
                        {
                            System.Diagnostics.Debug.WriteLine($"{cust.CustomerId}");
                            return cust.CustomerId == customerId;
                        }); 

            return foundCustomer;
        }

        /// <summary>
        /// Sort list by name
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public IEnumerable<Customer> SortByName(IEnumerable<Customer> list)
        {
            var sortedList = list
                .OrderBy((c) => c.LastName)
                .ThenBy((c) => c.FirstName);
            return sortedList;
        }

        /// <summary>
        /// Sort list by customer type
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public IEnumerable<Customer> SortByNameTypeId(IEnumerable<Customer> list)
        {
            //var sortedList = list.OrderBy((c) => c.CustomerTypeId);
            var sortedList = list
                .OrderByDescending((c) => c.CustomerTypeId.HasValue)
                .ThenBy((c) => c.CustomerTypeId);
            return sortedList;
        }

        /// <summary>
        /// Sort list by name in reverse order
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public IEnumerable<Customer> SortByNameInReverse(IEnumerable<Customer> list)
        {
            var sortedList = SortByName(list).Reverse();
            return sortedList;
        }

        /// <summary>
        /// Predefined list of customers.
        /// </summary>
        /// <returns></returns>
        public List<Customer> Retrieve()
        {
            InvoiceRepository ir = new InvoiceRepository();

            List<Customer> custList = new List<Customer>
                    {new Customer() 
                          { CustomerId = 1, 
                            FirstName="Frodo",
                            LastName = "Baggins",
                            EmailAddress = "fb@hob.me",
                            CustomerTypeId=1,
                            InvoiceList = ir.Retrieve(1).ToList()
                            },
                    new Customer() 
                          { CustomerId = 2, 
                            FirstName="Bilbo",
                            LastName = "Baggins",
                            EmailAddress = "bb@hob.me",
                            CustomerTypeId=null,
                            InvoiceList = ir.Retrieve(2).ToList()
                            },
                    new Customer() 
                          { CustomerId = 3, 
                            FirstName="Samwise",
                            LastName = "Gamgee",
                            EmailAddress = "sg@hob.me",
                            CustomerTypeId= 4,
                            InvoiceList = ir.Retrieve(3).ToList()
                            },
                    new Customer() 
                          { CustomerId = 4, 
                            FirstName="Rosie",
                            LastName = "Cotton",
                            EmailAddress = "rc@hob.me",
                            CustomerTypeId=2,
                            InvoiceList = ir.Retrieve(4).ToList()
                            }
            };

            return custList;
        }

        /// <summary>
        /// Receive list of names
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public IEnumerable<string> GetNames(IEnumerable<Customer> list)
        {
            return list.Select((c) => c.FirstName + " " + c.LastName);
        }

        /// <summary>
        /// Receive list of names and emails
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public dynamic GetNamesAndEmails(IEnumerable<Customer> list)
        {
            var newList = list
                .Select((c) => 
                    new {
                        Name = c.FirstName + " " + c.LastName,
                        Email = c.EmailAddress
                    });

            foreach (var item in newList)
            {
                Console.WriteLine(item.Name + ": " + item.Email);
            }

            return newList;
        }

        /// <summary>
        /// Joins customers and customer types
        /// </summary>
        /// <param name="customers"></param>
        /// <param name="types"></param>
        /// <returns></returns>
        public dynamic GetNamesAndType(
            IEnumerable<Customer> customers, 
            IEnumerable<CustomerType> types)
        {
            var results = customers
                .Join(
                    types,
                    cid => cid.CustomerTypeId,
                    tid => tid.CustomerTypeId,
                    (cid, tid) =>
                        new {
                            Name = cid.FirstName + " " + cid.LastName,
                            //tId = tid.CustomerTypeId,
                            tName = tid.TypeName
                        }
                );

            foreach (var item in results)
            {
                //Console.WriteLine(item.Name + ": " + item.tId + " => " + item.tName);
                Console.WriteLine(item.Name + ": " + item.tName);
            }

            return results.ToList();
        }

        /// <summary>
        /// Get list of overdue customers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customer> GetOverdueCustomers(List<Customer> custList)
        {
            var overdue = custList
                            .SelectMany((c) => c.InvoiceList
                                    .Where((i) => (i.IsPaid ?? false) == false),
                                                  (c, i) => c)
                            .Distinct();

            return overdue;
        }

        //End of Class
    }
}
