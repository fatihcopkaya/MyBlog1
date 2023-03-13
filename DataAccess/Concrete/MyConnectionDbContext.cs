using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DataAccess.Concrete
{
    public class MyConnectionDbContext : DbContext
    {





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string ConnetDeveloper = "server=127.0.0.1;port=3306;database=Myblog;user=root;password=12345678;Charset=utf8;";

            optionsBuilder.UseLazyLoadingProxies()
                .UseMySql(ConnetDeveloper, ServerVersion.AutoDetect(ConnetDeveloper))
                .EnableSensitiveDataLogging()
                .ConfigureWarnings(warnings =>
                {
                    warnings.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning);
                });
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comments> Comment { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var admin = new User()
            {
                UserId = 1,
                Username = "admin@admin.com",
                UserPassword = "123456",
                RoleId = 1
            };
            modelBuilder.Entity<User>().HasData(admin);
            base.OnModelCreating(modelBuilder);
            var writer = new User()
            {
                UserId = 2,
                Username = "writer@writer.com",
                UserPassword = "123456",
                RoleId = 2
            };
            modelBuilder.Entity<User>().HasData(writer);
            base.OnModelCreating(modelBuilder);


        }
    }
}