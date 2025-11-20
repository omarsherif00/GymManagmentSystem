using GymManagmentDAL.Entities;
using GymManagmentDAL.Repositries.abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.UnitOfWorkPattern
{
    public interface IUnintOfWork
    {
       IGenericRepositry<TEntity> GetRepositry<TEntity>() where TEntity:BaseEntity,new();

        int SaveChanges();
    }
}
