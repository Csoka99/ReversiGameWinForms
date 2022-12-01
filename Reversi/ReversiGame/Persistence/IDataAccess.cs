using ReversiGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversiGame.Persistence
{
    public interface IDataAccess
    {
        Task<(int, FieldStates, int, int, FieldStates[,])> LoadGameAsync(string path);
        Task<bool> SaveGameAsync(string path, ReversiModel model);
    }
}
