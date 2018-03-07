﻿// <auto-generated />
using Lab_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(SportContext))]
    partial class SportContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lab_1.Models.Group", b =>
                {
                    b.Property<int>("GroupID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Count_of_visitor");

                    b.Property<int>("InstructorID");

                    b.Property<string>("Name");

                    b.HasKey("GroupID");

                    b.HasIndex("InstructorID");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Lab_1.Models.Instructor", b =>
                {
                    b.Property<int>("InstructorID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Aducation");

                    b.Property<int>("Experience");

                    b.Property<string>("Midname");

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.HasKey("InstructorID");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("Lab_1.Models.TimeTable", b =>
                {
                    b.Property<int>("TimeTableID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Days_of_the_week");

                    b.Property<int>("GroupID");

                    b.Property<string>("Time_visits");

                    b.HasKey("TimeTableID");

                    b.HasIndex("GroupID");

                    b.ToTable("Timetables");
                });

            modelBuilder.Entity("Lab_1.Models.Visitor", b =>
                {
                    b.Property<int>("VisitorID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GroupID");

                    b.Property<string>("Midname");

                    b.Property<string>("Name");

                    b.Property<string>("Passport");

                    b.Property<string>("Surname");

                    b.HasKey("VisitorID");

                    b.HasIndex("GroupID");

                    b.ToTable("Visitors");
                });

            modelBuilder.Entity("Lab_1.Models.Group", b =>
                {
                    b.HasOne("Lab_1.Models.Instructor", "Instructor")
                        .WithMany("Groups")
                        .HasForeignKey("InstructorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Lab_1.Models.TimeTable", b =>
                {
                    b.HasOne("Lab_1.Models.Group", "Group")
                        .WithMany("TimeTables")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Lab_1.Models.Visitor", b =>
                {
                    b.HasOne("Lab_1.Models.Group", "Group")
                        .WithMany("Visitors")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
