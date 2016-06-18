using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GameRental
{
    /// <summary>
    /// Handles connection to database and sending queries.
    /// </summary>
    class DBConnect
    {
        //Declare sql connection.
        private MySqlConnection connection;
        //Name of the server to be used.
        private string server;
        //Database to be accessed.
        private string database;
        //Uid to use.
        private string uid;
        //Password
        private string password;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            //Set the server name.
            server = "localhost";
            //Set database name.
            database = "rental_database";
            //Set uid.
            uid = "root";
            //Set the password.
            password = "";
            //Declare a string variable to store connection string.
            string connectionString;
            //Set the connection.
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            //Use the connection.
            connection = new MySqlConnection(connectionString);
        }

        //Open connection to database.
        private bool OpenConnection()
        {
            try
            {
                //Open the connection
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    //0: Cannot connect to server.
                    case 0:
                        //MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    //1045: Invalid user name and/or password.
                    case 1045:
                        //MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                //Close the connection.
                connection.Close();
                return true;
            }
            catch (MySqlException)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Method to query and get all games from database.
        /// </summary>
        /// <returns> Returns a list of games </returns>
        public List<Game> SelectAllGame()
        {
            //Set the query
            string query = "SELECT * FROM game";
            //Declare new list of games to be populated.
            List<Game> games = new List<Game>();
            //String variable to temporarily store the game details.
            string game;
            //Array to store split game details.
            string[] gameSpecs;

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    game = dataReader["id"] + "," + dataReader["title"] + "," + dataReader["platform"]+ "," + dataReader["year"] + "," + dataReader["publisher"] + "," + dataReader["quantity"] + "," + dataReader["price"] + "," + dataReader["other"];                                                       
                    //Split where there are commas.
                    gameSpecs = game.Split(',');
                    //Check if the game is a ps4 game.
                    if (dataReader["platform"].ToString() == "PS4")
                    {
                        //Add the game to the list.
                        //Use the ConvertToPS4 method to convert.
                        games.Add(ConvertToPS4(gameSpecs));
                    }
                    //Check if the game is a xbone game.
                    else if (dataReader["platform"].ToString() == "XBONE")
                    {
                        //Add the game to the list.
                        //Use the ConvertToXBONE method to convert.
                        games.Add(ConvertToXBONE(gameSpecs));
                    }
                    //Check if the game is a wiiu game.
                    else if (dataReader["platform"].ToString() == "WIIU")
                    {
                        //Add the game to the list.
                        //Use the ConvertToWIIU method to convert.
                        games.Add(ConvertToWIIU(gameSpecs));
                    }
                    
                }

                //Close Data Reader.
                dataReader.Close();

                //Close Connection.
                this.CloseConnection();

                //Return list to be displayed.
                return games;
            }
            else
            {
                //Return list.
                return games;
            }
        }

        //Insert statement for the game database.
        public void InsertGame(string title, string platform, int year, string publisher, int quantity, int price, string other)
        {
            //Set the query.
            string query = "INSERT INTO game (title, platform, year, publisher, quantity, price, other) VALUES('"+ title + "','" + platform + "','" + year + "','" + publisher + "','" + quantity + "','" + price + "','" + other + "')";

            //Open connection.
            if (this.OpenConnection() == true)
            {
                //Create command and assign the query and connection from the constructor.
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command.
                cmd.ExecuteNonQuery();

                //Close connection.
                this.CloseConnection();
            }
        }

        //Update statement for the game database
        public void UpdateGame(int id, string title, string platform, int year, string publisher, int quantity, int price, string other)
        {
            //Set the query.
            string query = "UPDATE game SET title='" + title + "', platform='" + platform + "', year='" + year + "', publisher='" + publisher + "', quantity='" + quantity + "', price='" + price + "', other='" + other + "' WHERE id='" + id + "'";

            //Open connection.
            if (this.OpenConnection() == true)
            {
                //Create mysql command.
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText.
                cmd.CommandText = query;
                //Assign the connection using Connection.
                cmd.Connection = connection;

                //Execute query.
                cmd.ExecuteNonQuery();

                //Close connection.
                this.CloseConnection();
            }
        }

        //Delete statement for the game database.
        public void DeleteGame(int id)
        {
            //Set the query.
            string query = "DELETE FROM game WHERE id='" + id + "'";

            //Open connection.
            if (this.OpenConnection() == true)
            {
                //Create mysql command.
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Execute query.
                cmd.ExecuteNonQuery();
                //Close connection.
                this.CloseConnection();
            }
        }

        /// <summary>
        /// Method to query and get all customers from database.
        /// </summary>
        /// <returns> Returns a list of customers </returns>
        public List<Customer> SelectAllCustomers()
        {
            //Set the query.
            string query = "SELECT * FROM customer";
            //Create a list of customers to be populated.
            List<Customer> customers = new List<Customer>();
            //Array to store customer details.
            string[] custDetails;
            //Temporary variable to store customer details.
            string temp;

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    temp = dataReader["id"] + "," + dataReader["first_name"] + "," + dataReader["last_name"] + "," + dataReader["address"] + "," + dataReader["phone_number"];
                    //Split where there are commas.
                    custDetails = temp.Split(',');
                    //Create a new customer.
                    Customer customer = new Customer();
                    //Set the customer details using the array.
                    customer.ID = int.Parse(custDetails[0]);
                    customer.Firstname = custDetails[1];
                    customer.Lastname = custDetails[2];
                    customer.Address = custDetails[3];
                    customer.Phonenumber = custDetails[4];
                    //Add the customer to the list.
                    customers.Add(customer);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                //return list;
                return customers;
            }
            else
            {
                //return list;
                return customers;
            }
        }

        //Insert statement for the customer database.
        public void InsertCustomer(string firstname, string lastname, string address, string phonenumber)
        {
            //Set the query.
            string query = "INSERT INTO customer (first_name, last_name, address, phone_number) VALUES('" + firstname + "','" + lastname + "','" + address + "','" + phonenumber + "')";

            //Open connection.
            if (this.OpenConnection() == true)
            {
                //Create command and assign the query and connection from the constructor.
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command.
                cmd.ExecuteNonQuery();

                //Close connection.
                this.CloseConnection();
            }
        }

        //Update statement for the customer database.
        public void UpdateCustomer(int id, string firstname, string lastname, string address, string phonenumber)
        {
            //Set the query.
            string query = "UPDATE customer SET first_name='" + firstname + "', last_name='" + lastname + "', address='" + address + "', phone_number='" + phonenumber + "' WHERE id='" + id + "'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create command.
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;
                //Execute query
                cmd.ExecuteNonQuery();
                //Close connection.
                this.CloseConnection();
            }
        }

        //Delete statement for the customer database.
        public void DeleteCustomer(int id)
        {
            //Set the query.
            string query = "DELETE FROM customer WHERE id='" + id + "'";

            //Open connection.
            if (this.OpenConnection() == true)
            {
                //Create command and assign the query and connection from the constructor.
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Execute command.
                cmd.ExecuteNonQuery();
                //Close connection.
                this.CloseConnection();
            }
        }

        /// <summary>
        /// Method to query and get all rentals from database.
        /// </summary>
        /// <returns> Returns a list of rentals </returns>
        public List<string> SelectAllGameRental()
        {
            //Set the query.
            //string query = "SELECT gr.id, gr.rent_date, gr.rent_due, c.first_name, c.last_name, g.platform, g.title FROM customer AS c INNER JOIN game_rental AS gr ON c.id=gr.customer_id INNER JOIN game g ON g.id=gr.game_id";
            string query = "SELECT * FROM game_rental";
            //Create a list to store rentals.
            List<string> rentals = new List<string>();
            //Variable to store a rental.
            string rental;

            //Open connection.
            if (this.OpenConnection() == true)
            {
                //Create Command.
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command.
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list.
                while (dataReader.Read())
                {
                    //rental = dataReader["game_rental.id"] + "," + dataReader["customer.first_name"] + "," + dataReader["customer.last_name"] + "," + dataReader["game.platform"] + "," + dataReader["game.title"] + "," + dataReader["game_rental.rent_date"] + "," + dataReader["game_rental.rent_due"];
                    rental = dataReader["id"] + "," + dataReader["customer_id"] + "," + dataReader["game_id"] + "," + dataReader["rent_date"] + "," + dataReader["rent_due"];
                    //Add the rental to the rentals list.
                    rentals.Add(rental);
                }

                //Close Data Reader.
                dataReader.Close();

                //Close Connection.
                this.CloseConnection();

                //Return list to be displayed.
                return rentals;
            }
            else
            {
                //Return list.
                return rentals;
            }
        }

        //Insert statement for the game_rental database.
        public void InsertRent(int customer_id, int game_id, string rentdate, string rentdue)
        {
            //Set the query.
            string query = "INSERT INTO game_rental (customer_id, game_id, rent_date, rent_due) VALUES('" + customer_id + "','" + game_id + "','" + rentdate + "','" + rentdue + "')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Execute command
                cmd.ExecuteNonQuery();
                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement for the game_rental database.
        public void DeleteRent(int id)
        {
            //Set the query.
            string query = "DELETE FROM game_rental WHERE id='" + id + "'";
            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Execute command
                cmd.ExecuteNonQuery();
                //close connection
                this.CloseConnection();
            }
        }

        /// <summary>
        /// Method to convert a string array to a ps4 game.
        /// </summary>
        /// <param name="gameSpecs"></param>
        /// <returns> Returns a game class. </returns>
        public Game ConvertToPS4(string[] gameSpecs)
        {
            //Create a new ps4 class.
            PS4 ps4Game = new PS4();
            //Check if the game is a ps4 game.
            if (gameSpecs[2] == "PS4")
            {
                //Use the string array as properties for the game.
                ps4Game.ID = int.Parse(gameSpecs[0]);
                ps4Game.Title = gameSpecs[1];
                ps4Game.Platform = gameSpecs[2];
                ps4Game.Year = int.Parse(gameSpecs[3]);
                ps4Game.Publisher = gameSpecs[4];
                ps4Game.Quantity = int.Parse(gameSpecs[5]);
                ps4Game.Price = int.Parse(gameSpecs[6]);
                ps4Game.PsMove = gameSpecs[7];
            }
            //Return game.
            return ps4Game;
        }

        /// <summary>
        /// Method to convert a string array to a xbone game.
        /// </summary>
        /// <param name="gameSpecs"></param>
        /// <returns> Returns a game class. </returns>
        public Game ConvertToXBONE(string[] gameSpecs)
        {
            //Create a new xbone class.
            XBONE xboneGame = new XBONE();
            //Check if the game is a xbone game.
            if (gameSpecs[2] == "XBONE")
            {
                //Use the string array as properties for the game.
                xboneGame.ID = int.Parse(gameSpecs[0]);
                xboneGame.Title = gameSpecs[1];
                xboneGame.Platform = gameSpecs[2];
                xboneGame.Year = int.Parse(gameSpecs[3]);
                xboneGame.Publisher = gameSpecs[4];
                xboneGame.Quantity = int.Parse(gameSpecs[5]);
                xboneGame.Price = int.Parse(gameSpecs[6]);
                xboneGame.Kinect = gameSpecs[7];
            }
            //Return game.
            return xboneGame;
        }

        /// <summary>
        /// Method to convert a string array to a wiiu game.
        /// </summary>
        /// <param name="gameSpecs"></param>
        /// <returns> Returns a game class. </returns>
        public Game ConvertToWIIU(string[] gameSpecs)
        {
            //Create a new wiiu class.
            WII_U wiiuGame = new WII_U();
            //Check if the game is a wiiu game.
            if (gameSpecs[2] == "WIIU")
            {
                //Use the string array as properties for the game.
                wiiuGame.ID = int.Parse(gameSpecs[0]);
                wiiuGame.Title = gameSpecs[1];
                wiiuGame.Platform = gameSpecs[2];
                wiiuGame.Year = int.Parse(gameSpecs[3]);
                wiiuGame.Publisher = gameSpecs[4];
                wiiuGame.Quantity = int.Parse(gameSpecs[5]);
                wiiuGame.Price = int.Parse(gameSpecs[6]);
                wiiuGame.GamePad = gameSpecs[7];
            }
            //Return game.
            return wiiuGame;
        }
    }
}
