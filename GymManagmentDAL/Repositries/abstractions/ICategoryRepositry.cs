using GymManagmentDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Repositries.abstractions
{
    internal interface ICategoryRepositry
    {
        IEnumerable<Category> GetAllMembers();
        Category? GetMemberById(int id);
        int Add(Category member);
        int Update(Category member);
        int Delete(int id);
    }
}
