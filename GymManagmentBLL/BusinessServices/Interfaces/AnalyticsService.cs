using GymManagmentBLL.ViewModels;
using GymManagmentDAL.Entities;
using GymManagmentDAL.UnitOfWorkPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.BusinessServices.Interfaces
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnalyticsService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }   
        public HomeAnalyticsViewModel GetHomeAnalyticsService()
        {
            var sessions = _unitOfWork.GetRepositry<Session>().GetAll();
            return new HomeAnalyticsViewModel()
            {
                TotalMembers=_unitOfWork.GetRepositry<Member>().GetAll().Count(),
                TotalTrainers=_unitOfWork.GetRepositry<Trainer>().GetAll().Count(),
                ActiveMembers=_unitOfWork.GetRepositry<MemberShip>().GetAll(X=>X.Status=="Active").Count(),
                UpcomingSessions=sessions.Count(X=>X.StartDate>DateTime.Now),
                OngoingSessions=sessions.Count(X=>X.StartDate<=DateTime.Now&&X.EndDate>=X.EndDate),
                CompletedSessions=sessions.Count(X=>X.EndDate<DateTime.Now),


            };
        }
    }
}
