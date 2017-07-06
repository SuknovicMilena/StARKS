using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using StARKS.Data;

namespace StARKS.Data.Migrations
{
    [DbContext(typeof(StARKSDbContext))]
    [Migration("20170706170552_RenamedFields")]
    partial class RenamedFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StARKS.Data.Entities.Course", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Code");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("StARKS.Data.Entities.Marks", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<int>("CourseCode");

                    b.Property<int>("Mark");

                    b.HasKey("StudentId", "CourseCode")
                        .HasName("PK_MarksForStudent");

                    b.HasIndex("CourseCode");

                    b.ToTable("Marks");
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

            modelBuilder.Entity("StARKS.Data.Entities.Marks", b =>
                {
                    b.HasOne("StARKS.Data.Entities.Course", "Course")
                        .WithMany("Marks")
                        .HasForeignKey("CourseCode")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StARKS.Data.Entities.Student", "Student")
                        .WithMany("Marks")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
