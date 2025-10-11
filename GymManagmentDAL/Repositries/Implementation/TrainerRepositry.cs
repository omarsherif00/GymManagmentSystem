using GymManagmentDAL.Data.Contexts;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repositries.abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Repositries.Implementation
{
    internal class TrainerRepositry:ITrainerRepositry
    {
        private readonly GymDbContext _dbContext = new GymDbContext();

        public int Add(Trainer trainer)
        {
            _dbContext.Trainer.Add(trainer);
            return _dbContext.SaveChanges();
        }

        public int Delete(int id)
        {
            var trainer = _dbContext.Trainer.Find(id);
            if (trainer is null)
                return 0;   


            _dbContext.Trainer.Remove(trainer);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Trainer> GetAllTrainer() => _dbContext.Trainer.ToList();

        public Trainer? GetTrainerById(int id) => _dbContext.Trainer.Find(id);
        public int Update(Trainer trainer)
        {
            _dbContext.Trainer.Update(trainer);
            return _dbContext.SaveChanges();
        }
    }
}
