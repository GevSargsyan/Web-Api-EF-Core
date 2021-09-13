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
            modelBuilder.ApplyConfiguration(new GithubAccountConfiguration());
            modelBuilder.ApplyConfiguration(new MemberConfiguration());
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
            base.OnModelCreating(modelBuilder);
        }

       public DbSet<Homework> Homeworks { get; set; }
       public DbSet<Member> Members{ get; set; }
       public DbSet<GithubAccount> GithubAccounts{ get; set; }
    }
}
