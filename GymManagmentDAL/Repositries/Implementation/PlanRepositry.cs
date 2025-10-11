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
    internal class PlanRepositry:IPlanRepositries
    {
        private readonly GymDbContext _dbContext;

        //private GymDbContext _dbContext=new GymDbContext();
        public PlanRepositry(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }
     

        public Plan? Get(int id)=>  _dbContext.Plans.Find(id);



        public IEnumerable<Plan> GetAllPlans(Plan plan) => _dbContext.Plans.ToList();

        public int Update(Plan plan)
        {
            _dbContext.Plans.Update(plan);
            return _dbContext.SaveChanges();
        }
    }
}
