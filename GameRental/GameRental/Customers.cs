using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameRental
{
    /// <summary>
    /// Handles adding, deleting and editing customer details.
    /// </summary>
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();

            //Instantiate a DBConnect class called connect.
            DBConnect connect = new DBConnect();
            //Use the .SelectAllCustomers() method to get a list of customers then put into listbox.
            lbxCustomers.Items.AddRange(connect.SelectAllCustomers().ToArray());
        }

        /// <summary>
        /// Adds a new customer into the system using the information entered in the textboxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Instantiate a DBConnect class called connect.
            DBConnect connect = new DBConnect();
            //Create a new customer.
            Customer toAdd = new Customer();
            //Use the texts stored in textboxes as properties for the customer.
            toAdd.Firstname = tbxFirstName.Text;
            toAdd.Lastname = tbxLastName.Text;
            toAdd.Address = tbxAddress.Text;
            toAdd.Phonenumber = tbxPhoneNumber.Text;

            //Use the .InsertCustomer method to add the new customer into the system.
            connect.InsertCustomer(toAdd.Firstname, toAdd.Lastname, toAdd.Address, toAdd.Phonenumber);
            //Refresh the data shown in the listbox. 
            RefreshData();
            //Clear all texts in textboxes.
            ClearText();
        }   

        /// <summary>
        /// Deletes a selected customer from the listbox and the system.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Instantiate a DBConnect class called connect.
            DBConnect connect = new DBConnect();
            //Create a new customer class and cast the selected item in the listbox into the customer class.
            Customer toDelete = (Customer)lbxCustomers.SelectedItem;
            //Use the .DeleteCustomer method to delete the customer from the system.
            connect.DeleteCustomer(toDelete.ID);
            //Refresh the data shown in the listbox.
            RefreshData();
        }

        /// <summary>
        /// Get the selected item from the listbox and use the details as properties for a customer class to edit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            //Create a new customer.
            Customer editCustomer = new Customer();
            //Cast the selected item in the listbox into the customer class.
            editCustomer = (Customer)lbxCustomers.SelectedItem;
            //Use the texts stored in textboxes as properties for the customer.
            tbxFirstName.Text = editCustomer.Firstname;
            tbxLastName.Text = editCustomer.Lastname;
            tbxAddress.Text = editCustomer.Address;
            tbxPhoneNumber.Text = editCustomer.Phonenumber;
        }

        /// <summary>
        /// Saves into the system the edited customer details.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //Instantiate a DBConnect class called connect.
            DBConnect connect = new DBConnect();
            //Store in a string the selected item from the listbox.
            string row = lbxCustomers.SelectedItem.ToString();
            //Split the string where there are commas then store into a string array.
            string[] details = row.Split(',');
            //Create a new customer.
            Customer toSave = new Customer();
            //Use the texts stored in textboxes as properties for the customer.
            toSave.ID = int.Parse(details[0]);
            toSave.Firstname = tbxFirstName.Text;
            toSave.Lastname = tbxLastName.Text;
            toSave.Address = tbxAddress.Text;
            toSave.Phonenumber = tbxPhoneNumber.Text;
            //Use the .UpdateCustomer method to update the customer details in the system
            connect.UpdateCustomer(toSave.ID, toSave.Firstname, toSave.Lastname, toSave.Address, toSave.Phonenumber);
            //Refresh the data shown in the listbox.
            RefreshData();
            //Clear all texts in textboxes.
            ClearText();
        }

        /// <summary>
        /// Method to refresh the data shown in the listboxes.
        /// </summary>
        private void RefreshData()
        {
            //Instantiate a DBConnect class called connect.
            DBConnect connect = new DBConnect();
            //Clear all the items stored in listbox.
            lbxCustomers.Items.Clear();
            //Use the .SelectAllCustomer() method to get a list of customers then put into listbox.
            lbxCustomers.Items.AddRange(connect.SelectAllCustomers().ToArray());
        }

        /// <summary>
        /// Method to clear texts in textboxes.
        /// </summary>
        private void ClearText()
        {
            //Clear texts in textboxes.
            tbxFirstName.Clear();
            tbxLastName.Clear();
            tbxAddress.Clear();
            tbxPhoneNumber.Clear();
        }
    }
}
