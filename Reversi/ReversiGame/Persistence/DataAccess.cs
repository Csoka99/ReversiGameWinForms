using ReversiGame.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversiGame.Persistence
{
    public class DataAccess : IDataAccess
    {
        public async Task<(int, FieldStates, int, int, FieldStates[,])> LoadGameAsync(string path)
        {
            try
            {
                using(StreamReader reader = new StreamReader(path))
                {
                    string line = await reader.ReadLineAsync();
                    int size = int.Parse(line);

                    line = await reader.ReadLineAsync();
                    FieldStates current = FieldStates.Empty;
                    if (line == "Black")
                    {
                        current = FieldStates.Black;
                    }
                    if (line == "White")
                    {
                        current = FieldStates.White;
                    }
                    if (line == "ValidMove")
                    {
                        current = FieldStates.ValidMove;
                    }
                    if (line == "Empty")
                    {
                        current = FieldStates.Empty;
                    }

                    

                    line = await reader.ReadLineAsync();
                    int blackTime = int.Parse(line);

                    line = await reader.ReadLineAsync();
                    int whiteTime = int.Parse(line);

                    FieldStates[,] board = new FieldStates[size,size]; 

                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            line = await reader.ReadLineAsync();

                            if (line == "Black")
                            {
                                board[i, j] = FieldStates.Black;
                            }
                            if (line == "White")
                            {
                                board[i, j] = FieldStates.White;
                            }
                            if (line == "ValidMove")
                            {
                                board[i, j] = FieldStates.ValidMove;
                            }
                            if(line == "Empty")
                            {
                                board[i, j] = FieldStates.Empty;
                            }
                            

                        }
                    }

                    return (size,current,blackTime,whiteTime,board);
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                FieldStates[,] board = new FieldStates[0, 0];
                return (0, FieldStates.Empty, 0, 0, board);
                
            }
        }
        
        public async Task<bool> SaveGameAsync(string path, ReversiModel model)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.WriteLine(model.Size);
                    writer.WriteLine(model.CurrentPlayer);
                    writer.WriteLine(model.BlackTime);
                    writer.WriteLine(model.WhiteTime);
                    for (int i = 0; i < model.Size; i++)
                    {
                        for (int j = 0; j < model.Size; j++)
                        {
                            await writer.WriteAsync(model.Board[i, j]+"\n");
                        }
                    }
                    
                }

                return true;

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
    }
}
