using Microsoft.EntityFrameworkCore;
using Nexus.Models.Models;


namespace Nexus.DataAccess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions): base(dbContextOptions)
        {
        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasData(new Category  {
                Id=1,
               Name="Action",
               DisplatOrder=1,
            }, new Category
            {
                Id = 2,
                Name = "Scifi",
                DisplatOrder =2,
            }, new Category
            {
                Id = 3,
                Name = "History",
                DisplatOrder =3 ,
            }
           );
        }
    }
}
