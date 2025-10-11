using GymManagmentDAL.Data.Contexts;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repositries.abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Repositries.Implementation
{
    internal class GenericRepositry<TEntity> : IGenericRepositry<TEntity> where TEntity : BaseEntity,new()
    {
        private readonly GymDbContext _dbContext;

        public GenericRepositry(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll() => _dbContext.Set<TEntity>().ToList();

        public TEntity? GetById(int id) => _dbContext.Set<TEntity>().Find(id);

        public int Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            return _dbContext.SaveChanges();
        }
    }
}
