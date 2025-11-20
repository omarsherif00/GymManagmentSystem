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
    public class PlanRepositry:IPlanRepositries
    {
        private readonly GymDbContext _dbContext;

        //private GymDbContext _dbContext=new GymDbContext();
        public PlanRepositry(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }
     

        public Plan? GetById(int id)=>  _dbContext.Plans.Find(id);



        public IEnumerable<Plan> GetAllPlans(Plan plan) => _dbContext.Plans.ToList();

        public void Update(Plan plan)
        {
            _dbContext.Plans.Update(plan);
        }
    }
}
