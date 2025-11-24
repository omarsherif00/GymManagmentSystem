using GymManagmentDAL.Data.Contexts;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repositries.abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Repositries.Implementation
{
    public class SesssionRepo : GenericRepositry<Session>, ISessionRepo
    {
        private readonly GymDbContext _dbContext;

        public SesssionRepo(GymDbContext dbContext):base(dbContext) 
        {
         _dbContext = dbContext;
        }
        public IEnumerable<Session> GetAllWithCategoryAndTrainer()
        {

            return _dbContext.Sessions.Include(x => x.Category)
                .Include(x => x.Trainer)
                .ToList();
        }

        public Session? GetByIdWithTrainerAndCategory(int sessionId)
        {
            return _dbContext.Sessions
                .Include(x => x.Category)
                .Include(x => x.Trainer)
                .FirstOrDefault(x=>x.id==sessionId);
        }

        public int GetCountOfBookedSlots(int sessionId)
        {
            return _dbContext.MemberSessions.Count(x => x.SessionId == sessionId);
        }
    }
}
