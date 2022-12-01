using ReversiGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversiGame.EventArguments
{
    public class GamePassedEventArgs
    {
        public FieldStates Pass { get; set; }
        public GamePassedEventArgs(FieldStates pass)
        {
            Pass = pass;
        }
    }
}
