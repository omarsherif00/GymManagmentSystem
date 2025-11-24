using GymManagmentDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Repositries.abstractions
{
    public interface ISessionRepo
    {
        IEnumerable<session> GetAllWithCategoryAndTrainer();
        int GetCountOfBookedSlots(int sessionId);
    }
}
