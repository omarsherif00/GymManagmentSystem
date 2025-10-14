using GymManagmentBLL.BusinessServices.Interfaces.IMemberServices;
using GymManagmentBLL.ViewModels;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repositries.abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.BusinessServices.Implementation
{
    internal class Memberservice : IMemberServices
    {
        private readonly IGenericRepositry<Member> _memberRepositry;

        public Memberservice(IGenericRepositry<Member> memberRepositry)
        {
            _memberRepositry = memberRepositry;
        }

        public bool CreateMember(CreateMemberViewModel createMember)
        {
            //Email not exist
            var EmailExist = _memberRepositry.GetAll(X=>X.Email==createMember.Email).Any();
            if(EmailExist)
                return false;
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
            var PhoneExist=_memberRepositry.GetAll(X=>X.Phone==createMember.Phone).Any();
            if (PhoneExist) return false;

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
                HealthRecord=new HealthRecord
                {
                    height=createMember.HealthRecord.Height,
                    weight=createMember.HealthRecord.Weight,
                    Bloodtype=createMember.HealthRecord.BloodType,
                    note=createMember.HealthRecord.note
                }
                

            };
            //Create Member in database
            return _memberRepositry.Add(member)>0;



        }

        public IEnumerable<MemberViewModel> GetAllMembers()
        {
            var members = _memberRepositry.GetAll();
            if(members == null || !members.Any())
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
    }
}
