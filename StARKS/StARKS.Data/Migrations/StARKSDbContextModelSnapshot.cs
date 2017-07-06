using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using StARKS.Data;

namespace StARKS.Data.Migrations
{
    [DbContext(typeof(StARKSDbContext))]
    partial class StARKSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StARKS.Data.Entities.Cours", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Code");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("StARKS.Data.Entities.MarksForStudent", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<int>("CoursCode");

                    b.Property<int>("Mark");

                    b.HasKey("StudentId", "CoursCode")
                        .HasName("PK_MarksForStudent");

                    b.HasIndex("CoursCode");

                    b.ToTable("MarksForStudent");
                });

            modelBuilder.Entity("StARKS.Data.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("LastName");

                    b.Property<string>("State");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StARKS.Data.Entities.MarksForStudent", b =>
                {
                    b.HasOne("StARKS.Data.Entities.Cours", "Cours")
                        .WithMany("Marks")
                        .HasForeignKey("CoursCode")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StARKS.Data.Entities.Student", "Student")
                        .WithMany("Marks")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
