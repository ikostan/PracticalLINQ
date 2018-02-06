using ACM.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ACM.Win
{
    public partial class CustomerWin : Form
    {
        CustomerRepository customerRepository = new CustomerRepository();
        CustomerTypeRepository customerTypeRepository = new CustomerTypeRepository();

        public CustomerWin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Get customers event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetCustomersButton_Click(object sender, EventArgs e)
        {
            //CustomerGridView.DataSource = customerRepository.Retrieve();

            var customersList = customerRepository.Retrieve();
            var customersType = customerTypeRepository.Retrieve();
            var custNameType = customerRepository.GetNamesAndType(customersList, customersType);

            CustomerGridView.DataSource = custNameType;

            //CustomerGridView.DataSource = customerRepository.SortByName(customersList).ToList();
            
            //CustomerGridView.DataSource = customerRepository.GetOverdueCustomers(customersList).ToList();

            //var unpaidInvoices = customerRepository.GetOverdueCustomers(customerRepository.Retrieve());
            //var orderedList = customerRepository.SortByName(unpaidInvoices);
            //CustomerGridView.DataSource = orderedList.ToList();
        }

        /// <summary>
        /// On form load event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerWin_Load(object sender, EventArgs e)
        {
            var customers = customerRepository.Retrieve();
            var custNameId = customerRepository.GetNameAndId(customers);

            CustomerComboBox.DisplayMember = "Name";
            CustomerComboBox.ValueMember = "Id";
            CustomerComboBox.DataSource = custNameId;
        }

        /// <summary>
        /// ComboBox selected index changed event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CustomerComboBox.SelectedValue != null)
            {
                int custId;

                if (int.TryParse(CustomerComboBox.SelectedValue.ToString(), out custId))
                {
                    var customers = customerRepository.Retrieve();
                    //CustomerGridView.DataSource = customers.Where((c) => c.CustomerId == custId).ToList();
                    CustomerGridView.DataSource = 
                        new List<Customer>()
                        {
                            customerRepository.Find(customers, custId)
                        };
                }
            }
        }

        //End of class
    }
}
