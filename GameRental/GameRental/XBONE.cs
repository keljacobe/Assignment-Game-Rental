using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRental
{
    /// <summary>
    /// A child class of game that stores a new property calles Kinect.
    /// To be used when a game is a xbox game.
    /// </summary>
    class XBONE : Game
    {
        string kinect;
       
        public string Kinect
        {
            get { return kinect; }
            set { kinect = value; }
        }

        //Override the ToString() method to return a string of xbox details separated by commas
        public override string ToString()
        {
            return ID + ", " + Platform + ", " + Title + ", " + Year + ", " + Publisher + ", " + Price + ", " + Quantity + ", " + Kinect;
        }
    }
}
