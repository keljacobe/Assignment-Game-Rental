using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRental
{
    /// <summary>
    /// A child class of game that stores a new property calles GamePad.
    /// To be used when a game is a wiiu game.
    /// </summary>
    class WII_U : Game
    {
        string game_pad;

        public string GamePad
        {
            get { return game_pad; }
            set { game_pad = value; }
        }

        //Override the ToString() method to return a string of wiiu details separated by commas
        public override string ToString()
        {
            return ID + ", " + Platform + ", " + Title + ", " + Year + ", " + Publisher + ", " + Price + ", " + Quantity + ", " + GamePad;
        }
    }
}
