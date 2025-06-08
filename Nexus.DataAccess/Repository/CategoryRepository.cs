using Nexus.DataAccess.Data;
using Nexus.DataAccess.Repository.IRepository;
using Nexus.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        //public void Save()
        //{
        //   _dbContext.SaveChanges();
        //}

        public void update(Category category)
        {
            _dbContext.Categories.Update(category);
        }
    }
}
