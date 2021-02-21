using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebDevelopmentAssessment.Models;

namespace WebDevelopmentAssessment.Data
{
    public class WebContentContext : DbContext
    {
        public WebContentContext (DbContextOptions<WebContentContext> options)
            : base(options)
        {
        }

        public DbSet<Picture> Pictures { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Picture>().ToTable("Picture");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Tag>().ToTable("Tag");
        }

        public DbSet<WebDevelopmentAssessment.Models.Picture> Picture { get; set; }
    }
}
