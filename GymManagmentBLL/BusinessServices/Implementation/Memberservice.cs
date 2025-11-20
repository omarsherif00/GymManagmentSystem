using GymManagmentBLL.BusinessServices.Interfaces.IMemberServices;
using GymManagmentBLL.ViewModels;
using GymManagmentBLL.ViewModels.MemberVM;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repositries.abstractions;
using GymManagmentDAL.UnitOfWorkPattern;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.BusinessServices.Implementation
{
    internal class Memberservice : IMemberServices
    {
        private readonly IUnintOfWork _unintOfWork;

        public Memberservice(IUnintOfWork unintOfWork)
        {
           _unintOfWork = unintOfWork;
        }

        public bool CreateMember(CreateMemberViewModel createMember)
        {
            //Email not exist

            #region first way
            //if (members.Any())
            //{
            //    foreach (var member in members)
            //    {
            //        if (member.Email == createMember.Email)
            //        {
            //            return false;
            //        }
            //    }
            //}
            #endregion


            //phone not exist

            if (isEmailExist(createMember.Email) || isPhoneExist(createMember.Phone))
            {
                return false;
            }

                //CreateMemberViewModel=>Member
                var member = new Member
            {
                Name = createMember.Name,
                Email = createMember.Email,
                Phone = createMember.Phone,
                Gender = createMember.Gender,
                DateOfBirth = createMember.DateOfBirth,
                Address = new Address
                {
                    BuildingNumber = createMember.BuildingNumber,
                    City = createMember.City,
                    Street = createMember.Street,

                },
                HealthRecord = new HealthRecord
                {
                    height = createMember.HealthRecord.Height,
                    weight = createMember.HealthRecord.Weight,
                    Bloodtype = createMember.HealthRecord.BloodType,
                    note = createMember.HealthRecord.note
                }


            };
            //Create Member in database
            _unintOfWork.GetRepositry<Member>().Add(member);


            return _unintOfWork.SaveChanges()>0;
        }

        public IEnumerable<MemberViewModel> GetAllMembers()
        {
            var members = _unintOfWork.GetRepositry<Member>().GetAll();
            if (members == null || !members.Any())
                return [];


            //first way of manual mapping

            //var ListOfMemberViewModel=new List<MemberViewModel>();
            //foreach(var member in members)
            //{
            //    var memberViewModel = new MemberViewModel
            //    {
            //        Id = member.id,
            //        Name = member.Name,
            //        Phone = member.Phone,
            //        Photo = member.photo,
            //        Email = member.Email,
            //        Gender = member.Gender.ToString(),

            //    };
            //    ListOfMemberViewModel.Add(memberViewModel);
            //}

            var memberViewModel = members.Select(M => new MemberViewModel
            {
                Id = M.id,
                Name = M.Name,
                Phone = M.Phone,
                Photo = M.photo,
                Email = M.Email,
                Gender = M.Gender.ToString(),

            });
            return memberViewModel;

        }

        public MemberViewModel? GetMemberDetails(int memberid)
        {
            var member = _unintOfWork.GetRepositry<Member>().GetById(memberid);
            if (member == null) return null;

            var MemberViewModel = new MemberViewModel
            {
                Name = member.Name,
                Phone = member.Phone,
                Email = member.Email,
                Gender = member.Gender.ToString(),
                DateOfBirth = member.DateOfBirth.ToShortDateString(),
                Address = $"{member.Address.BuildingNumber}-{member.Address.Street}-{member.Address.City}",
                Photo = member.photo,
                


            };
            //active membership
            var membership=_unintOfWork.GetRepositry<MemberShip>().GetAll(X=>X.MemberId==memberid && X.Status=="Active").FirstOrDefault();

            if (membership is not null)
            {
                MemberViewModel.MemberShipStartDate=membership.CreatedAt.ToShortDateString();
                MemberViewModel.MemberShipEndDate=membership.EndDate.ToShortDateString();

                var plan = _unintOfWork
                    .GetRepositry<Plan>()
                    .GetById(membership.PlanId);
                MemberViewModel.PlanName = plan?.Name;

            }
            return MemberViewModel;
        }

        public HealthRecordViewModel? GetMemberHealthDetails(int memberId)
        {
            var memberHealthRecord = _unintOfWork.GetRepositry<HealthRecord>().GetById(memberId);
            if (memberHealthRecord is null) return null;

            return new HealthRecordViewModel
            { 
                  Weight = memberHealthRecord.weight,
                  Height = memberHealthRecord.height,
                  BloodType = memberHealthRecord.Bloodtype,
                  note = memberHealthRecord.note,


                };
        }

        public MemberToUpdateViewModel? GetMemberToUpdate(int memberId)
        {
            var member = _unintOfWork.GetRepositry<Member>().GetById(memberId);
            if (member == null) return null;

            return new MemberToUpdateViewModel
            {
                Name = member.Name,
                Phone = member.Phone,
                Email = member.Email,
                Photo = member.photo,
                BuildingNumber = member.Address.BuildingNumber,
                City = member.Address.City,
                Street = member.Address.Street,

            };
        }

        public bool RemoveMember(int memberId)
        {
            try
            {
                var member = _unintOfWork
                    .GetRepositry<Member>()
                    .GetById(memberId);

                if (member == null) return false;
                var memberSessionIds = _unintOfWork
                    .GetRepositry<MemberSession>()
                    .GetAll(X => X.MemberId == memberId)
                    .Select(X => X.SessionId);

                var hasFutureSessions = _unintOfWork
                    .GetRepositry<session>()
                .GetAll(S => memberSessionIds.Contains(S.id) && S.StartDate > DateTime.Now).Any();

                if (hasFutureSessions)
                    return false;

                var membershipRepo = _unintOfWork
                    .GetRepositry<MemberShip>();
                var memberShips =membershipRepo
                    .GetAll(X => X.MemberId == memberId);

                if (memberShips.Any())
                {
                    foreach (var memberShip in memberShips)
                    {
                        membershipRepo.Delete(memberShip);
                    }

                }

                 _unintOfWork.GetRepositry<Member>().Delete(member);

               return _unintOfWork.SaveChanges() > 0;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateMember(int MemberId, MemberToUpdateViewModel memberToUpdate)
        {
            try
            {
               
                if (isEmailExist(memberToUpdate.Email) || isPhoneExist(memberToUpdate.Phone))
                {
                    return false;
                }
                var member = _unintOfWork.GetRepositry<Member>().GetById(MemberId);
                if (member == null) return false;

                member.Email = memberToUpdate.Email;
                member.Phone = memberToUpdate.Phone;
                member.Address.BuildingNumber = memberToUpdate.BuildingNumber;
                member.Address.City = memberToUpdate.City;
                member.Address.Street = memberToUpdate.Street;
                member.UpdatedAt = DateTime.Now;

                 _unintOfWork.GetRepositry<Member>().Update(member);

                return _unintOfWork.SaveChanges()>0;
            }
            catch (Exception)
            {

                return false;
            }

            }
        
        #region Helper Method
        private bool isEmailExist(string Email)
        {
            return  _unintOfWork.GetRepositry<Member>().GetAll(X => X.Email == Email).Any();

        }
        private bool isPhoneExist(string phone)
        {
            return _unintOfWork.GetRepositry<Member>().GetAll(X => X.Phone == phone).Any();

        }

        #endregion

    }
}
