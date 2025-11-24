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
    public class SesssionRepo : GenericRepositry<session>, ISessionRepo
    {
        private readonly GymDbContext _dbContext;

        public SesssionRepo(GymDbContext dbContext):base(dbContext) 
        {
         _dbContext = dbContext;
        }
        public IEnumerable<session> GetAllWithCategoryAndTrainer()
        {

            return _dbContext.Sessions.Include(x => x.Category)
                .Include(x => x.Trainer)
                .ToList();
        }

        public int GetCountOfBookedSlots(int sessionId)
        {
            return _dbContext.MemberSessions.Count(x => x.SessionId == sessionId);
        }
    }
}
