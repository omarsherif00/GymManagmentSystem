using GymManagmentDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Repositries.abstractions
{
    public interface IGenericRepositry<TEntity> where TEntity:BaseEntity,new()
    {
       IEnumerable<TEntity> GetAll(Func<TEntity,bool>? condition);
       TEntity? GetById(int id);
       int Add(TEntity entity);
       int Update(TEntity entity);
       int Delete(TEntity entity);


    }
}
