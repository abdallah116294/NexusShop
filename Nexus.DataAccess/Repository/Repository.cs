using Microsoft.EntityFrameworkCore;
using Nexus.DataAccess.Data;
using Nexus.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.DataAccess.Repository
{
    //Make sure to implement the IRepository interface for the Repository class and Make the Repository class generic so it can work with any type of entity.
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        //inuser the T is in Dbset <T> so it can work with any type of entity, such as Category, Product, etc.
        internal DbSet<T> dbset;
        public Repository(ApplicationDbContext dbContext)
        {
                _dbContext = dbContext ;
                this.dbset=_dbContext.Set<T>();
        }
        public void Add(T entity)
        {
            _dbContext.Add(entity);
        }

        public void Delete(T entity)
        {
             _dbContext.Remove(entity);
        }

        public void DeleteRangeg(IEnumerable<T> entities)
        {
             dbset.RemoveRange(entities);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbset;
            query= query.Where(filter);
           return query.FirstOrDefault();
        }

        public T GetById(int id)
        {
           var entity = dbset.Find(id);
            if (entity != null)
            {
                return entity;
            }
            else
            {
                throw new ArgumentNullException($"Entity with id {id} not found.");
            }
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> qurey= dbset;
            return qurey.ToList();
        }
    }
}
