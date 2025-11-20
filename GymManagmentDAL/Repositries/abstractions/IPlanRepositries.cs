using GymManagmentDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Repositries.abstractions
{
    public interface IPlanRepositries
    {
        IEnumerable<Plan> GetAllPlans(Plan plan);
        void Update(Plan plan);
        Plan? GetById(int id);

    }
}
