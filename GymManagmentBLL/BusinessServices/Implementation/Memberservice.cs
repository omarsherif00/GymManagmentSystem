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
