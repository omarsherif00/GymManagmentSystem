using GymManagmentDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Repositries.abstractions
{
    internal interface ISessionRepositry
    {
        IEnumerable<session> GetAllSession();
        session? GetSessionById(int id);
        int Add(session session);
        int Update(session session);
        int Delete(int id);
    }
}
