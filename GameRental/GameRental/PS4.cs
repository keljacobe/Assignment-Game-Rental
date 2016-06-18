using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRental
{
    /// <summary>
    /// A child class of game that stores a new property calles PsMove.
    /// To be used when a game is a ps4 game.
    /// </summary>
    class PS4 : Game
    {
        string ps_move;

        public string PsMove
        {
            get { return ps_move; }
            set { ps_move = value; }
        }

        //Override the ToString() method to return a string of PS4 details separated by commas
        public override string ToString()
        {
            return ID + ", " + Platform + ", " + Title + ", " + Year + ", " + Publisher + ", " + Price + ", " + Quantity + ", " + PsMove;
        }

    }
}
