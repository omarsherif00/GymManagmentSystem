using GymManagmentBLL.BusinessServices.Interfaces;
using GymManagmentBLL.ViewModels.PlanVM;
using GymManagmentDAL.Entities;
using GymManagmentDAL.UnitOfWorkPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.BusinessServices.Implementation
{
    internal class PlanService : IPlanServices
    {
        private readonly IUnintOfWork _unintOfWork;

        public PlanService(IUnintOfWork unintOfWork)
        {
            _unintOfWork = unintOfWork;
        }
        public IEnumerable<PlanViewModel> GetAllPlans()
        {
            var Plans = _unintOfWork
                .GetRepositry<Plan>()
                .GetAll();

            if (Plans is null || !Plans.Any())
                return [];

            return Plans.Select(P => new PlanViewModel
            {
                Id=P.id,
                Name=P.Name,
                Description=P.Description,
                Price=P.Price,
                isActive=P.IsActive
                DurationDays = P.DurationDays
            });

        }

        public PlanViewModel? GetPlanDetails(int PlanId)
        {
            var plan = _unintOfWork.GetRepositry<Plan>().GetById(PlanId);
            if (plan == null) return null;

            return new PlanViewModel
            {
                Id = plan.id,
                Name = plan.Name,
                Description = plan.Description,
                Price = plan.Price,
                isActive = plan.IsActive,
                DurationDays = plan.DurationDays
            };

        }

        public PlanToUpdateViewModel? GetPlanToUpdate(int PlanId)
        {
            throw new NotImplementedException();
        }

        public bool ToggleStatus(int planId)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePlan(int PlanId, PlanToUpdateViewModel planToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
