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
    internal class MemberRepositry : IMemberRepositry
    {
        private readonly GymDbContext _dbContext;

        // private readonly GymDbContext _dbContext=new GymDbContext();

        public MemberRepositry(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(Member member)
        {
            _dbContext.Members.Add(member);
            return _dbContext.SaveChanges();
        }

        public int Delete(int id)
        {
            var member = _dbContext.Members.Find(id);
            if (member is null) 
                return 0;
         

            _dbContext.Members.Remove(member);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Member> GetAllMembers()=>_dbContext.Members.ToList();

        public Member? GetMemberById(int id) => _dbContext.Members.Find(id);
        

        public int Update(Member member)
        {
           _dbContext.Members.Update(member);
            return _dbContext.SaveChanges();
        }
    }
}
