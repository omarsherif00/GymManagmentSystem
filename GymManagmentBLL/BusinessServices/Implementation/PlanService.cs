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
                Id = P.id,
                Name = P.Name,
                Description = P.Description,
                Price = P.Price,
                isActive = P.IsActive,
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
            var plan = _unintOfWork
                .GetRepositry<Plan>()
                .GetById(PlanId);

            if (plan is null || plan.IsActive == false || HasActiveMemberShips(PlanId)) return null;

            return new PlanToUpdateViewModel
            {
                Name = plan.Name,
                Description = plan.Description,
                Price = plan.Price,
                DurationDays = plan.DurationDays
            };
        }

        public bool ToggleStatus(int planId)
        {
            var plan = _unintOfWork.GetRepositry<Plan>().GetById(planId);
            if (plan is null || HasActiveMemberShips(planId))
                return false;

            plan.IsActive = plan.IsActive == true ? false : true;

            plan.UpdatedAt = DateTime.Now;
            _unintOfWork.GetRepositry<Plan>().Update(plan);

            return _unintOfWork.SaveChanges() > 0;

        }

        public bool UpdatePlan(int PlanId, PlanToUpdateViewModel planToUpdate)
        {
            var plan = _unintOfWork.GetRepositry<Plan>().GetById(PlanId);

            if (plan is null || planToUpdate is null) return false;

            (plan.Description, plan.DurationDays, plan.Price)
                = (planToUpdate.Description, planToUpdate.DurationDays, planToUpdate.Price);

            plan.UpdatedAt = DateTime.Now;
            try
            {
                _unintOfWork.GetRepositry<Plan>().Update(plan);
                return _unintOfWork.SaveChanges() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }


        private bool HasActiveMemberShips(int planId)
        {
            var activeMemberShips = _unintOfWork.GetRepositry<MemberShip>()
                .GetAll(X => X.PlanId == planId && X.Status == "Active");
            return activeMemberShips.Any();

        }
    }
}
