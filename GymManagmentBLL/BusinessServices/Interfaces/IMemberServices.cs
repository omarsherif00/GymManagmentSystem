using GymManagmentBLL.ViewModels;
using GymManagmentBLL.ViewModels.MemberVM;
using GymManagmentDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.BusinessServices.Interfaces
{
    internal interface IMemberServices
    {
        IEnumerable<MemberViewModel> GetAllMembers();
        bool CreateMember(CreateMemberViewModel createMember);

        MemberViewModel? GetMemberDetails(int Memberid);

        MemberToUpdateViewModel? GetMemberToUpdate(int memberId);

        bool UpdateMember(int MemberId,MemberToUpdateViewModel memberToUpdate);

        public HealthRecordViewModel? GetMemberHealthDetails(int memberId);
        bool RemoveMember(int memberId);
    }
}
