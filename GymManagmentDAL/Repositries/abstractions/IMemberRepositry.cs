using GymManagmentDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Repositries.abstractions
{
    internal interface IMemberRepositry
    {
        //5 signature methods

        IEnumerable<Member> GetAllMembers();
        Member? GetMemberById(int id);
        int Add(Member member);
        int Update(Member member);
        int Delete(int id);

    }
}
