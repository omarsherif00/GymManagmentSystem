using AutoMapper;
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
        private readonly IMapper _mapper;

        public SessionService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<SessionViewModel> GetAlllSessions()
        {
            var sessionRepo = _unitOfWork.SessionRepo;
            var sessions = sessionRepo.GetAllWithCategoryAndTrainer();
            if (!sessions.Any())
                return [];

            //return sessions.Select(session => new SessionViewModel
            //{
            //    Id = session.id,
            //    Description = session.Description,
            //    StartDate = session.StartDate,
            //    EndDate = session.EndDate,
            //    Capacity = session.Capacity,
            //    TrainerName = session.Trainer.Name,
            //    CategoryName = session.Category.CategoryName,
            //    AvailableSlots = session.Capacity - sessionRepo.GetCountOfBookedSlots(session.id)

            //});
            var MappedSession = _mapper.Map<IEnumerable<Session>, IEnumerable<SessionViewModel>>(sessions);

            foreach(var session in MappedSession)
                session.AvailableSlots = session.Capacity - _unitOfWork.SessionRepo.GetCountOfBookedSlots(session.Id);


            return MappedSession;
        }

        public SessionViewModel? GetSessionDetails(int sessionId)
        {
            var session = _unitOfWork.SessionRepo.GetByIdWithTrainerAndCategory(sessionId);

            if (session == null) return null;

            //return new SessionViewModel
            //{
            //    Id = session.id,
            //    Description = session.Description,
            //    StartDate = session.StartDate,
            //    EndDate = session.EndDate,
            //    Capacity = session.Capacity,
            //    TrainerName = session.Trainer.Name,
            //    CategoryName = session.Category.CategoryName,
            //    AvailableSlots = session.Capacity - _unitOfWork.SessionRepo.GetCountOfBookedSlots(session.id)
            //};

            var MappedSession = _mapper.Map<Session, SessionViewModel>(session);

            MappedSession.AvailableSlots = MappedSession.Capacity - _unitOfWork.SessionRepo.GetCountOfBookedSlots(session.id);

            return MappedSession;
        }
    }
}
