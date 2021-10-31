using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Context:DbContext
    {
        public Context (string conStr): base(conStr) 
        {
            //Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { set; get; }
        public DbSet<Group> Groups { set; get; }
        public DbSet<Test> Tests { set; get; }
        public DbSet<Question> Question { set; get; }
        public DbSet<Answer> Answers { set; get; }        
        public DbSet<TestUser> TestUsers { set; get; }
        public DbSet<UserAnswer> UserAnswers { set; get; }

        static Context()
        {
            Database.SetInitializer<Context>(new MyContextInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(x => x.TestUsers).WithRequired(x => x.User).WillCascadeOnDelete(true);
            modelBuilder.Entity<Test>().HasMany(x => x.TestUsers).WithRequired(x => x.Test).WillCascadeOnDelete(true);            

            modelBuilder.Entity<Answer>().HasMany(x => x.UserAnswers).WithRequired(x => x.Answer).WillCascadeOnDelete(true);
            modelBuilder.Entity<TestUser>().HasMany(x => x.UserAnswers).WithRequired(x => x.TestUser).WillCascadeOnDelete(true);

            //modelBuilder.Entity<SPJ>().HasKey(x => new { x.SId, x.PId, x.JId });

        }
    }
}
