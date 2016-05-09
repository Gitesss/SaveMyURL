using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace SaveMyURL.Model
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=SaveMyURLData.db");
        }


        private const string TableNameGroups = "Groups";
        private const string TableNamelinks = "links";
        private const string TableNameTags = "Tags";


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().ToTable(TableNameGroups);
            modelBuilder.Entity<Link>().ToTable(TableNamelinks);
            modelBuilder.Entity<Tag>().ToTable(TableNameTags);

            modelBuilder.Entity<Link>()
            .HasOne(p => p.Group)
            .WithMany(b => b.Links)
            .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Tag>()
            .HasOne(p => p.Link)
            .WithMany(b => b.Tags)
            .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);

        }


    }
}
