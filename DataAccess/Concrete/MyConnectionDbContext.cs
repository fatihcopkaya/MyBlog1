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
            const string ConnetDeveloper = "server=localhost;port=3306;database=YeniNews;user=root;password=0987654321;Charset=utf8;";
         
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
        
}
}