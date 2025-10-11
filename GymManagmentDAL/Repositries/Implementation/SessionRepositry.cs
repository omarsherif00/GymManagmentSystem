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
    internal class SessionRepositry : ISessionRepositry
    {
             private readonly GymDbContext _dbContext = new GymDbContext();
        public int Add(session session)
        {
            _dbContext.Sessions.Add(session);
            return _dbContext.SaveChanges();
        }

        public int Delete(int id)
        {
            var session = _dbContext.Sessions.Find(id);
            if (session is null)
                return 0;


            _dbContext.Sessions.Remove(session);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<session> GetAllSession()=>_dbContext.Sessions.ToList();

        public session? GetSessionById(int id)=> _dbContext.Sessions.Find(id);
        public int Update(session session)
        {
            _dbContext.Sessions.Update(session);
            return _dbContext.SaveChanges();
        }
    }
}
