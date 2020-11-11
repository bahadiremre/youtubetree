using BESProject.YoutubeVideoTree.DataAccess.Concrete.EntityFrameworkCore.Mapping;
using BESProject.YoutubeVideoTree.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BESProject.YoutubeVideoTree.DataAccess.Concrete.Contexts
{
    class SqlDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-N4PGV7OS; database=YoutubeVideoTree; integrated security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
        }

        public DbSet<User> Users { get; set; }
    }
}
