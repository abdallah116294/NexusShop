using Nexus.DataAccess.Data;
using Nexus.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public ICategoryRepository CategoryRepository { get; private set; }
        public UnitOfWork(ApplicationDbContext dbcontext)
        {
                    _dbContext = dbcontext;
            //add the CategoryRepository to the UnitOfWork
            CategoryRepository = new CategoryRepository(_dbContext);
        }


        public void Save()
        {
           _dbContext.SaveChanges();
        }
    }
}
