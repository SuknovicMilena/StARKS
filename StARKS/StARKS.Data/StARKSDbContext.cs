using Microsoft.EntityFrameworkCore;
using StARKS.Data.Entities;
using System;

namespace StARKS.Data
{
    public class StARKSDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public StARKSDbContext(DbContextOptions<StARKSDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MarksForStudent>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.CourseCode })
                .HasName("PK_MarksForStudent");
            });

        }
    }
}
