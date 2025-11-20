using GymManagmentDAL.Data.Contexts;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repositries.abstractions;
using GymManagmentDAL.Repositries.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.UnitOfWorkPattern
{
    public class UnitOfWork : IUnintOfWork
    {
        private readonly Dictionary<Type, object> _repositries=new();
        private readonly GymDbContext _dbContext;

        public UnitOfWork(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IGenericRepositry<TEntity> GetRepositry<TEntity>() where TEntity : BaseEntity, new()
        {
            //Data structure [key-value]
            //key->type
            //value=>new genericRepositry<member>();

            var entityType=typeof(TEntity);

           // if (_repositries.ContainsKey(entityType))
               // return (IGenericRepositry<TEntity>) _repositries[entityType];
        
            if(_repositries.TryGetValue(entityType,out var repositry))
                return (IGenericRepositry<TEntity>) repositry;

            var newRepo = new GenericRepositry<TEntity>(_dbContext);
            _repositries[entityType]= newRepo;
            return newRepo;
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
