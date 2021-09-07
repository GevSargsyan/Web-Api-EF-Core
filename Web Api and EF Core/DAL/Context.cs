using DAL.Configurations;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HomeworkConfigruation());
            base.OnModelCreating(modelBuilder);
        }

       public DbSet<Homework> Homeworks { get; set; }
    }
}
