using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRental
{
    /// <summary>
    /// An abstract class used to store information about a game
    /// </summary>
    public abstract class Game
    {
        int id;
        string title;
        int year;
        string publisher;
        int price;
        int quantity;
        string platform;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
     
        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }     

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public string Platform
        {
            get { return platform; }
            set { platform = value; }
        }

        //Override the ToString() method to return a string of game details consisting only of platform,title and price separated by commas
        public override string ToString()
        {
            return Platform + ", " + Title + ", " + Price;
        }

        

        
    }
}
