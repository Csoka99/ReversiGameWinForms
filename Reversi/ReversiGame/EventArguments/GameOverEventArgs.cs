using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReversiGame.Model;

namespace ReversiGame.EventArguments
{
    public class GameOverEventArgs
    {
        public Winner Winner { get; set;}

        public GameOverEventArgs(Winner winner)
        {
            Winner = winner;
        }
    }
}
