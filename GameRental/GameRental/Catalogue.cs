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
    /// Handles adding, deleting and editing game details.
    /// </summary>
    public partial class Catalogue : Form
    {
        public Catalogue()
        {
            InitializeComponent();
            //Instantiate a DBConnect class called connect.
            DBConnect connect = new DBConnect();
            //Use the .SelectAllGame() method to get a list of games then put into listbox.
            lbxGames.Items.AddRange(connect.SelectAllGame().ToArray());
        }

        /// <summary>
        /// Adds a new game into the system using the information entered in the textboxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Instantiate a DBConnect class called connect.
            DBConnect connect = new DBConnect();
            //Store texts from the textboxes in string and int variables.
            string title = tbxTitle.Text;
            string ps4 = "PS4";
            string xbone = "XBONE";
            string wiiu = "WIIU";
            int year = int.Parse(tbxYear.Text);
            string publisher = tbxPublisher.Text;
            int quantity = int.Parse(tbxQuantity.Text);
            int price = int.Parse(tbxPrice.Text);
            string other = tbxOther.Text;
            
            //If statement to check which radio button is checked.
            if (rdoPS4.Checked == true)
            {
                //Use the .InsertGame method to add the new ps4 game into the system.
                connect.InsertGame(title, ps4, year, publisher, quantity, price, other);
            }
            else if (rdoXBONE.Checked == true)
            {
                //Use the .InsertGame method to add the new xbone game into the system.
                connect.InsertGame(title, xbone, year, publisher, quantity, price, other);
            }
            else if (rdoWIIU.Checked == true)
            {
                //Use the .InsertGame method to add the new wiiu game into the system.
                connect.InsertGame(title, wiiu, year, publisher, quantity, price, other);
            }
            //Refresh the data shown in the listbox. 
            RefreshData();
            //Clear all texts in textboxes.
            ClearText();
        }

        /// <summary>
        /// Get the selected item from the listbox and use the details as properties for a game class to edit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            //Check if the selected item is a ps4 game.
            if (lbxGames.SelectedItem is PS4)
            {
                //Create a ps4 class to edit.
                PS4 editGame = new PS4();
                //Cast the selected item in the listbox into a ps4 class.
                editGame = (PS4)lbxGames.SelectedItem;     
                //Set the radio button to ps4.
                rdoPS4.Checked = true;
                //Set the texts in the textboxes to the properties of the ps4 class.
                tbxTitle.Text = editGame.Title;
                tbxYear.Text = editGame.Year.ToString();
                tbxPublisher.Text = editGame.Publisher;
                tbxQuantity.Text = editGame.Quantity.ToString();
                tbxPrice.Text = editGame.Price.ToString();
                tbxOther.Text = editGame.PsMove;
            }
            //Check if the selected item is a xbone game.
            else if (lbxGames.SelectedItem is XBONE)
            {
                //Create a xbone class to edit.
                XBONE editGame = new XBONE();
                //Cast the selected item in the listbox into a xbone class.
                editGame = (XBONE)lbxGames.SelectedItem;
                //Set the radio button to xbone.
                rdoXBONE.Checked = true;
                //Set the texts in the textboxes to the properties of the xbone class.
                tbxTitle.Text = editGame.Title;
                tbxYear.Text = editGame.Year.ToString();
                tbxPublisher.Text = editGame.Publisher;
                tbxQuantity.Text = editGame.Quantity.ToString();
                tbxPrice.Text = editGame.Price.ToString();
                tbxOther.Text = editGame.Kinect;
            }
            //Check if the selected item is a wiiu game.
            else if (lbxGames.SelectedItem is WII_U)
            {
                //Create a wiiu class to edit.
                WII_U editGame = new WII_U();
                //Cast the selected item in the listbox into a wiiu class.
                editGame = (WII_U)lbxGames.SelectedItem;
                //Set the radio button to wiiu.
                rdoWIIU.Checked = true;
                //Set the texts in the textboxes to the properties of the wiiu class.
                tbxTitle.Text = editGame.Title;
                tbxYear.Text = editGame.Year.ToString();
                tbxPublisher.Text = editGame.Publisher;
                tbxQuantity.Text = editGame.Quantity.ToString();
                tbxPrice.Text = editGame.Price.ToString();
                tbxOther.Text = editGame.GamePad;
            }                      
        }

        /// <summary>
        /// Saves into the system the edited game details.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //Instantiate a DBConnect class called connect.
            DBConnect connect = new DBConnect();
            //Store in a string the selected item from the listbox.
            string row = lbxGames.SelectedItem.ToString();
            //Split the string where there are commas then store into a string array.
            string[] details = row.Split(',');
            //Store into string and int variables the texts stored in textboxes.
            int id = int.Parse(details[0]);
            string title = tbxTitle.Text;
            string ps4 = "PS4";
            string xbone = "XBONE";
            string wiiu = "WIIU";
            int year = int.Parse(tbxYear.Text);
            string publisher = tbxPublisher.Text;
            int quantity = int.Parse(tbxQuantity.Text);
            int price = int.Parse(tbxPrice.Text);
            string other = tbxOther.Text;

            //Check which radio button is checked.
            if (rdoPS4.Checked == true)
            {
                //Use the .UpdateGame method to update the ps4 game details in the system.
                connect.UpdateGame(id, title, ps4, year, publisher, quantity, price, other);
            }
            else if (rdoXBONE.Checked == true)
            {
                //Use the .UpdateGame method to update the xbone game details in the system
                connect.UpdateGame(id, title, xbone, year, publisher, quantity, price, other);
            }
            else if (rdoWIIU.Checked == true)
            {
                //Use the .UpdateGame method to update the wiiu game details in the system
                connect.UpdateGame(id, title, wiiu, year, publisher, quantity, price, other);
            }
            //Refresh the data shown in the listbox. 
            RefreshData();
            //Clear all texts in textboxes.
            ClearText();
        }

        /// <summary>
        /// Deletes a selected game from the listbox and the system.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Instantiate a DBConnect class called connect.
            DBConnect connect = new DBConnect();
            //Check if the selected game is a ps4.
            if (lbxGames.SelectedItem is PS4)
            {
                //Cast the selected item into a ps4 class.
                PS4 toDelete = (PS4)lbxGames.SelectedItem;
                //Use the .DeleteGame method to delete the game from the system.
                connect.DeleteGame(toDelete.ID);
            }
            //Check if the selected game is a xbone.
            else if (lbxGames.SelectedItem is XBONE)
            {
                //Cast the selected item into a xbone class.
                XBONE toDelete = (XBONE)lbxGames.SelectedItem;
                //Use the .DeleteGame method to delete the game from the system.
                connect.DeleteGame(toDelete.ID);
            }
            //Check if the selected game is a wiiu.
            else if (lbxGames.SelectedItem is WII_U)
            {
                //Cast the selected item into a wiiu class.
                WII_U toDelete = (WII_U)lbxGames.SelectedItem;
                //Use the .DeleteGame method to delete the game from the system.
                connect.DeleteGame(toDelete.ID);
            }
            //Refresh the data shown in the listbox. 
            RefreshData(); 
        }

        /// <summary>
        /// Method to refresh the data shown in the listboxes.
        /// </summary>
        private void RefreshData()
        {
            //Instantiate a DBConnect class called connect.
            DBConnect connect = new DBConnect();
            //Clear all the items stored in listbox.
            lbxGames.Items.Clear();
            //Use the .SelectAllGame() method to get a list of games then put into listbox.
            lbxGames.Items.AddRange(connect.SelectAllGame().ToArray());
        }

        /// <summary>
        /// Method to clear texts in textboxes.
        /// </summary>
        private void ClearText()
        {
            //Clear texts in textboxes.
            tbxTitle.Clear();
            tbxYear.Clear();
            tbxPublisher.Clear();
            tbxQuantity.Clear();
            tbxPrice.Clear();
            tbxOther.Clear();
        }

   
    }
}
