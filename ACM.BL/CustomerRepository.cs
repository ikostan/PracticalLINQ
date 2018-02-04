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
            var sortedList = list.OrderBy((c) => c.FirstName);
            return sortedList;
        }

        /// <summary>
        /// Predefined list of customers.
        /// </summary>
        /// <returns></returns>
        public List<Customer> Retrieve()
        {
            List<Customer> custList = new List<Customer>
                    {new Customer() 
                          { CustomerId = 1, 
                            FirstName="Frodo",
                            LastName = "Baggins",
                            EmailAddress = "fb@hob.me",
                            CustomerTypeId=1},
                    new Customer() 
                          { CustomerId = 2, 
                            FirstName="Bilbo",
                            LastName = "Baggins",
                            EmailAddress = "bb@hob.me",
                            CustomerTypeId=null},
                    new Customer() 
                          { CustomerId = 3, 
                            FirstName="Samwise",
                            LastName = "Gamgee",
                            EmailAddress = "sg@hob.me",
                            CustomerTypeId=1},
                    new Customer() 
                          { CustomerId = 4, 
                            FirstName="Rosie",
                            LastName = "Cotton",
                            EmailAddress = "rc@hob.me",
                            CustomerTypeId=2}};
            return custList;
        }
    }
}
