using ReversiGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversiGame.EventArguments
{
    public class FieldChangedEventArgs
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public FieldStates NewState { get; set; }

        public FieldChangedEventArgs(int row, int column, FieldStates newState)
        {
            Row = row;
            Column = column;
            NewState = newState;
        }
    }
}
