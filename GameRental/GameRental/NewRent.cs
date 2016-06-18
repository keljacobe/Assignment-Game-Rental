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
    /// Handles adding rentals into the system.
    /// </summary>
    public partial class NewRent : Form
    {
        public NewRent()
        {
            InitializeComponent();

            //Instantiate a DBConnect class called connect.
            DBConnect connect = new DBConnect();

            //Use the .SelectAllGame() method to get a list of games then put into listbox.
            lbxGamesList.Items.AddRange(connect.SelectAllGame().ToArray());
            //Use the .SelectAllCustomer() method to get a list of customers then put into listbox.
            lbxCustomersList.Items.AddRange(connect.SelectAllCustomers().ToArray());
        }

        /// <summary>
        /// Adds a new rental into the system when the button is clicked, getting the information to
        /// input from the selected item in the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRent_Click(object sender, EventArgs e)
        {
            //Instantiate a DBConnect class called connect.
            DBConnect connect = new DBConnect();

            //Store into a string the selected item in the listbox.
            string customer = lbxCustomersList.SelectedItem.ToString();
            //Split the string where there are commas then store into a string array.
            string[] custDetails = customer.Split(',');
            //Store into a string the selected item in the listbox.
            string game = lbxGamesList.SelectedItem.ToString();
            //Split the string where there are commas then store into a string array.
            string[] gameDetails = game.Split(',');
            //Store into an int what is stored in the array.
            int customer_id = int.Parse(custDetails[0]);
            //Store into an int what is stored in the array.
            int game_id = int.Parse(gameDetails[0]);
            //Store into a string what is stored in the array.
            string rent_date = tbxRentDate.Text;
            //Store into a string what is stored in the array.
            string rent_due = tbxRentDue.Text;

            //Use the .InsertRent method to add a new rental into the system.
            connect.InsertRent(customer_id, game_id, rent_date, rent_due);
            //Refresh the data shown in the listbox. 
            RefreshData();
            //Clear all the texts in the textboxes.
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
            lbxCustomersList.Items.Clear();
            //Clear all the items stored in listbox.
            lbxGamesList.Items.Clear();
            //Use the .SelectAllGame() method to get a list of games then put into listbox.
            lbxGamesList.Items.AddRange(connect.SelectAllGame().ToArray());
            //Use the .SelectAllCustomer() method to get a list of customers then put into listbox.
            lbxCustomersList.Items.AddRange(connect.SelectAllCustomers().ToArray());
        }

        /// <summary>
        /// Method to clear texts in textboxes.
        /// </summary>
        private void ClearText()
        {
            //Clear texts in textbox.
            tbxRentDate.Clear();
            //Clear texts in textbox.
            tbxRentDue.Clear();
        }
    }
}
