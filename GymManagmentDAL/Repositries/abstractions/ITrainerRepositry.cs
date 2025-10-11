using GymManagmentDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Repositries.abstractions
{
    internal interface ITrainerRepositry
    {
        IEnumerable<Trainer> GetAllTrainer();
        Trainer? GetTrainerById(int id);
        int Add(Trainer trainer);
        int Update(Trainer trainer);
        int Delete(int id);
    }
}
