using GymManagmentBLL.BusinessServices.Interfaces;
using GymManagmentBLL.ViewModels.SessionVM;
using GymManagmentDAL.Entities;
using GymManagmentDAL.UnitOfWorkPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Quic;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.BusinessServices.Implementation
{
    internal class SessionService : ISessionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SessionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<SessionViewModel> GetAlllSessions()
        {
            var sessionRepo = _unitOfWork.SessionRepo;
            var sessions = sessionRepo.GetAllWithCategoryAndTrainer();
            if (!sessions.Any())
                return [];

            return sessions.Select(session => new SessionViewModel
            {
                Id = session.id,
                Description = session.Description,
                StartDate = session.StartDate,
                EndDate = session.EndDate,
                TrainerName = session.Trainer.Name,
                CategoryName = session.Category.CategoryName,
                AvailableSlots = session.Capacity - sessionRepo.GetCountOfBookedSlots(session.id)

            });
        }
    }
}
