using GymManagmentBLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.BusinessServices.Interfaces
{
    public interface IAnalyticsService
    {
        HomeAnalyticsViewModel GetHomeAnalyticsService();
    }
}
