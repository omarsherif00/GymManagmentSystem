using GymManagmentBLL.ViewModels;
using GymManagmentDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.BusinessServices.Interfaces.IMemberServices
{
    internal interface IMemberServices
    {
        IEnumerable<MemberViewModel> GetAllMembers();    
    
    }
}
