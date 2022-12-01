using ReversiGame.EventArguments;
using ReversiGame.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace ReversiGame.Model
{
    public class ReversiModel
    {
        #region EventArgs
        public event EventHandler<GameStartedEventArgs> GameStarted;
        public event EventHandler<FieldChangedEventArgs> FieldChanged;
        public event EventHandler<GameOverEventArgs> GameOver;
        public event EventHandler<GamePassedEventArgs> GamePassed;
        #endregion

        #region Field
        private IDataAccess _dataAccess;
        private int _size;
        private int _validMoveNum;
        private int _blackNum;
        private int _whiteNum;
        private FieldStates[,] _board;
        private FieldStates _currentPlayer;
        private Winner _winner;

        private int _blackTime;
        private int _whiteTime;
        #endregion

        #region Properties

        public Winner Winner { get => _winner; set => _winner = value; }
        public int Size { get => _size; set => _size = value; }
        public int ValidMoveNum { get => _validMoveNum; set => _validMoveNum = value; }
        public int BlackNum { get => _blackNum; set => _blackNum = value; }
        public int WhiteNum { get => _whiteNum; set => _whiteNum = value; }
        public FieldStates[,] Board { get => _board; set => _board = value; }
        public FieldStates CurrentPlayer { get => _currentPlayer; set => _currentPlayer = value; }
        public int BlackTime { get => _blackTime; set => _blackTime = value; }
        public int WhiteTime { get => _whiteTime; set => _whiteTime = value; }

        #endregion
        public ReversiModel(IDataAccess dataAccess)
        {
            this._dataAccess = dataAccess;
        }

        public void StartNewGame(int size)
        {
            this._size = size;
            _validMoveNum = 0;

            _blackTime = 0;
            _whiteTime = 0;
            
            //_timer.Start();

            _blackNum = 2;
            _whiteNum = 2;

            _board = new FieldStates[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    _board[i, j] = FieldStates.Empty;
                }
            }

            var half = size / 2;

            _board[half-1, half-1] = FieldStates.Black;
            _board[half-1, half] = FieldStates.White;
            _board[half, half] = FieldStates.Black;
            _board[half, half-1] = FieldStates.White;

            _currentPlayer = FieldStates.Black;

            ValidMoves();

            if (GameStarted is not null)
            {
                GameStarted(this, new GameStartedEventArgs(size, _board));
            }
        }

        public string IntToTime(int time)
        {
            int val = time;
            TimeSpan result = TimeSpan.FromSeconds(val);
            string fromTimeString = result.ToString("mm':'ss");
            return fromTimeString;
        }

        public void TimerTicked()
        {
            if(_currentPlayer == FieldStates.Black)
            {
                _blackTime++;
            }

            if(_currentPlayer == FieldStates.White)
            {
                _whiteTime++;
            }
        }

        public void FieldClicked(int row, int column)
        {
            if (_board[row,column] == FieldStates.ValidMove)
            {
                _board[row, column] = _currentPlayer;


                toConverse(row, column);

                _validMoveNum = 0;
                _whiteNum = 0;
                _blackNum = 0;
                _currentPlayer = Opposite(_currentPlayer);

                for (int i = 0; i < _size; i++)
                {
                    for (int j = 0; j < _size; j++)
                    {
                        if (_board[i, j] == FieldStates.ValidMove)
                        {
                            _board[i, j] = FieldStates.Empty;
                        }
                        if(_board[i, j] == FieldStates.White)
                        {
                            _whiteNum++;
                        }
                        if (_board[i, j] == FieldStates.Black)
                        {
                            _blackNum++;
                        }
                    }
                }

                ValidMoves();

                for (int i = 0; i < _size; i++)
                {
                    for (int j = 0; j < _size; j++)
                    {
                        if (FieldChanged is not null)
                        {
                            FieldChanged(this, new FieldChangedEventArgs(i, j, _board[i, j]));
                        }
                    }
                }

                if (!isThereValidMove())
                {
                    _currentPlayer = Opposite(_currentPlayer);
                    ValidMoves();
                    for (int i = 0; i < _size; i++)
                    {
                        for (int j = 0; j < _size; j++)
                        {
                            if (FieldChanged is not null)
                            {
                                FieldChanged(this, new FieldChangedEventArgs(i, j, _board[i, j]));
                            }
                        }
                    }
                    if (!isThereValidMove())
                    {
                        GameOverModel();
                    }
                    else
                    {
                        GamePassedModel();
                    }
                }

            }
        }

        private void GamePassedModel()
        {
            FieldStates playerPassed = Opposite(_currentPlayer);

            if (GamePassed is not null)
            {
                GamePassed(this, new GamePassedEventArgs(playerPassed));
            }
        }

        public void GameOverModel()
        {
            if(_blackNum < _whiteNum)
            {
                _winner = Winner.White;
            }

            if(_whiteNum < _blackNum)
            {
                _winner = Winner.Black;
            }

            if(_whiteNum == _blackNum)
            {
                _winner = Winner.Row;
            }

            //_timer.Stop();

            if(GameOver is not null)
            {
                GameOver(this, new GameOverEventArgs(_winner));
            }
        }

        public bool isThereValidMove()
        {
            if(_validMoveNum == 0)
            {
                return false;
            }
            return true;
        }

        public void toConverse(int row, int column)
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (Math.Abs(row - i) <= 1 && Math.Abs(column - j) <= 1)
                    {
                        if (_board[i, j] != _board[row, column] && _board[row, column] == _currentPlayer && _board[i, j] != FieldStates.Empty && _board[i, j] != FieldStates.ValidMove)
                        {

                            var menetirany = row - i;
                            var menetirany2 = column - j;

                            ColourBoxes(i, j, menetirany, menetirany2);
                        }
                    }
                }
            }
        }

        public void ColourBoxes(int row, int column, int rowDirection, int columnDirection)
        {
            var current = _board[row, column];
            var i = row;
            var j = column;

            while (i >= 0 && j >= 0 && i <= _size - 1 && j <= _size - 1 && current != _currentPlayer && current != FieldStates.Empty && current != FieldStates.ValidMove)
            {
                current = _board[i, j];
                i = i - rowDirection;
                j = j - columnDirection;
                
            }

            if (current == _currentPlayer)
            {
                current = _board[row, column];
                i = row;
                j = column;

                while (i >= 0 && j >= 0 && i <= _size - 1 && j <= _size - 1 && current != _currentPlayer && current != FieldStates.Empty && current != FieldStates.ValidMove)
                {
                    current = _board[i, j];
                    _board[i, j] = _currentPlayer;
                    i = i - rowDirection;
                    j = j - columnDirection;

                }

            }
        }

        public void ValidMoves()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (_board[i,j] == _currentPlayer)
                    {
                        CheckIfItsGood(i,j);
                    }
                }
            }
        }

        public FieldStates Opposite(FieldStates value)
        {
            if (value == FieldStates.White)
            {
                return FieldStates.Black;
            }

            if (value == FieldStates.Black)
            {
                return FieldStates.White;
            }

            return value;
        }

        public void CheckIfItsGood(int row, int column)
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (Math.Abs(row - i) <= 1 && Math.Abs(column - j) <= 1)
                    {
                        if (_board[i,j] != _board[row, column] && _board[row, column] == _currentPlayer && _board[i,j] != FieldStates.Empty && _board[i, j] != FieldStates.ValidMove)
                        {
                            //board[i, j] = FieldStates.ValidMove;
                            var rowDirection = row - i;
                            var columnDirection = column - j;

                            PossibleSolution(i,j,rowDirection,columnDirection);
                        }
                    }
                }
            }
        }

        public void PossibleSolution(int row, int column, int rowDirection, int columnDirection)
        {
            var current = _board[row, column];
            var i = row;
            var j = column;

            while (i >= 0 && j >= 0 && i <= _size-1 && j <= _size-1 && current != _currentPlayer && current != FieldStates.Empty && current != FieldStates.ValidMove)
            {
                i = i - rowDirection;
                j = j - columnDirection;
                if(i<0 || j < 0 || i > _size - 1 || j > _size - 1)
                {
                    break;
                }
                current = _board[i, j];
            }

            if(current == FieldStates.Empty)
            {
                _board[i, j] = FieldStates.ValidMove;
                _validMoveNum++;
            }
            
        }

        public async Task SaveGame(string path)
        {
            await _dataAccess.SaveGameAsync(path,this);
        }

        public async Task LoadGame(string path)
        {
            (_size, _currentPlayer, _blackNum, _whiteNum, _board) = await _dataAccess.LoadGameAsync(path);

            _validMoveNum = 0;
            _whiteNum = 0;
            _blackNum = 0;

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (_board[i, j] == FieldStates.ValidMove)
                    {
                        _board[i, j] = FieldStates.Empty;
                    }
                    if (_board[i, j] == FieldStates.White)
                    {
                        _whiteNum++;
                    }
                    if (_board[i, j] == FieldStates.Black)
                    {
                        _blackNum++;
                    }
                }
            }

            ValidMoves();

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (FieldChanged is not null)
                    {
                        FieldChanged(this, new FieldChangedEventArgs(i, j, _board[i, j]));
                    }
                }
            }
        }

        public FieldStates StringToField(string line)
        {
            if(line == "Black")
            {
                return FieldStates.Black;
            }
            if(line == "White")
            {
                return FieldStates.White;
            }
            if(line == "ValidMove")
            {
                return FieldStates.ValidMove;
            }
            return FieldStates.Empty;
        }
    }
}
