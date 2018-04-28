using System;
using Microsoft.EntityFrameworkCore;


namespace EFDemo1.Model
{
    public class LMSDbContext: DbContext 
    {  
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        public LMSDbContext(DbContextOptions<LMSDbContext> options) :base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //Course
            modelBuilder.Entity<Course>().HasKey(a => a.Id);
            modelBuilder.Entity<Course>().Property(a => a.Id).ValueGeneratedOnAdd();

            //Student
            modelBuilder.Entity<Student>().HasKey(a => a.Id);
            modelBuilder.Entity<Student>().Property(a => a.Id).ValueGeneratedOnAdd();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder){
            //Please change your userid and pwd here
            var connectionString = "server = localhost; userid = root; pwd = -20051228Mysql; port = 3306; database = demo23_4; sslmode = none;";
            contextOptionsBuilder.UseMySQL(connectionString);
            base.OnConfiguring(contextOptionsBuilder);
        }
    }
}
