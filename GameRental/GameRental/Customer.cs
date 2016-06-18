using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRental
{
    /// <summary>
    /// A class to store customer information.
    /// </summary>
    class Customer
    {
        int id;    
        string firstname;
        string lastname;
        string address;
        string phonenumber;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }      

        public string Address
        {
            get { return address; }
            set { address = value; }
        }      

        public string Phonenumber
        {
            get { return phonenumber; }
            set { phonenumber = value; }
        }

        //Override the ToString() method to return a string of customer details separated by commas
        public override string ToString()
        {
            return ID + ", " + Firstname + ", " + Lastname + ", " + Address + ", " + Phonenumber;
        }
    }
}
