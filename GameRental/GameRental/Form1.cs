using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GameRental
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Main form that shows all rentals.
        /// Handles opening of the other forms.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            //Instantiate a DBConnect class called connect.
            DBConnect connect = new DBConnect();
            //Use the .SelectAllGameRental() method to get a list of rentals then put into listbox.
            lbxRental.Items.AddRange(connect.SelectAllGameRental().ToArray());
        }

        /// <summary>
        /// Opens the catalogue form when clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCatalogue_Click(object sender, EventArgs e)
        {
            //Instantiate a new catalogue class.
            Catalogue catalogue = new Catalogue();
            // Show the catalogue form.
            catalogue.ShowDialog();
        }

        /// <summary>
        /// Opens the newrental form when clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            //Instantiate a new NewRent class.
            NewRent newRental = new NewRent();
            // Show the newRental form.
            newRental.ShowDialog();
        }

        /// <summary>
        /// Opens the customers form when clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCustomers_Click(object sender, EventArgs e)
        {
            //Instantiate a new customers class.
            Customers customers = new Customers();
            // Show the customers form.
            customers.ShowDialog();
        }

        /// <summary>
        /// Deletes a selected rental from the listbox and the system.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Instantiate a DBConnect class called connect.
            DBConnect connect = new DBConnect();
            //Store in a string the selected item from the listbox.
            string row = lbxRental.SelectedItem.ToString();
            //Split the string where there are commas then store into a string array.
            string[] details = row.Split(',');
            //Store in an int variable the rental id of the item.
            int rentID = int.Parse(details[0]);
            //Use the .DeleteRent method to delete the rental from the system
            connect.DeleteRent(rentID);
            //Refresh the data shown in the listbox.
            RefreshData();
        }

        private void RefreshData()
        {
            //Instantiate a DBConnect class called connect.
            DBConnect connect = new DBConnect();
            //Clear all the items stored in listbox.
            lbxRental.Items.Clear();
            //Use the .SelectAllGameRental() method to get a list of rentals then put into listbox.
            lbxRental.Items.AddRange(connect.SelectAllGameRental().ToArray());
        }
    }
}
