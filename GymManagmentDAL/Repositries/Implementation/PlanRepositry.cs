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
        private GymDbContext _dbContext=new GymDbContext();

        public int Add(Plan plan)
        {
            _dbContext.Plans.Add(plan);
            return _dbContext.SaveChanges();
        }

        public int Delete(int id)
        {
            var plan=_dbContext.Plans.Find(id);
            if(plan is null)
                return 0;
            _dbContext.Plans.Remove(plan);
            return _dbContext.SaveChanges();
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
