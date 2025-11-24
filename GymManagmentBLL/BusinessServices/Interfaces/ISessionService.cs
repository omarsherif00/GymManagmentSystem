using GymManagmentBLL.ViewModels.SessionVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.BusinessServices.Interfaces
{
    internal interface ISessionService
    {
        IEnumerable<SessionViewModel> GetAlllSessions();
    }
}
