using GymManagmentDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Repositries.abstractions
{
    internal interface IPlanRepositries
    {
        IEnumerable<Plan> GetAllPlans(Plan plan);
        int Update(Plan plan);
        Plan? Get(int id);

    }
}
