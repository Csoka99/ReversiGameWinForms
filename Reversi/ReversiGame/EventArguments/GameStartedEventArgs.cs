using ReversiGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversiGame.EventArguments
{
    public class GameStartedEventArgs
    {
        public int BoardSize { get; set; }

        public FieldStates[,] Board { get; set; }

        public GameStartedEventArgs(int boardSize, FieldStates[,] board)
        {
            BoardSize = boardSize;
            Board = board;
        }
    }
}
