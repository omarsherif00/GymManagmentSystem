using GymManagmentBLL.ViewModels.PlanVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.BusinessServices.Interfaces
{
    public interface IPlanServices
    {
        IEnumerable<PlanViewModel> GetAllPlans();

        PlanViewModel? GetPlanDetails(int PlanId);

        PlanToUpdateViewModel? GetPlanToUpdate(int PlanId);

        bool UpdatePlan(int PlanId,PlanToUpdateViewModel planToUpdate);

        bool ToggleStatus(int planId);

    }
}
