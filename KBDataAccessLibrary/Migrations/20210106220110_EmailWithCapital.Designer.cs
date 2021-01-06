﻿// <auto-generated />
using System;
using KBDataAccessLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KBDataAccessLibrary.Migrations
{
    [DbContext(typeof(KBContext))]
    [Migration("20210106220110_EmailWithCapital")]
    partial class EmailWithCapital
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("ClassInstructor", b =>
                {
                    b.Property<int>("ClassesClassId")
                        .HasColumnType("int");

                    b.Property<int>("InstructorsInstructorId")
                        .HasColumnType("int");

                    b.HasKey("ClassesClassId", "InstructorsInstructorId");

                    b.HasIndex("InstructorsInstructorId");

                    b.ToTable("ClassInstructor");
                });

            modelBuilder.Entity("KBDataAccessLibrary.Models.AgeCategory", b =>
                {
                    b.Property<int>("AgeCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("varchar(7)");

                    b.HasKey("AgeCategoryId");

                    b.ToTable("AgeCategories");
                });

            modelBuilder.Entity("KBDataAccessLibrary.Models.Attendance", b =>
                {
                    b.Property<int>("AttendanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ClassId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("AttendanceId");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudentId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("KBDataAccessLibrary.Models.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AgeCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ClassId");

                    b.HasIndex("AgeCategoryId");

                    b.HasIndex("GroupId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("KBDataAccessLibrary.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AgeCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("GroupId");

                    b.HasIndex("AgeCategoryId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("KBDataAccessLibrary.Models.Instructor", b =>
                {
                    b.Property<int>("InstructorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("InstructorId");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("KBDataAccessLibrary.Models.LoginModels.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("KBDataAccessLibrary.Models.Membership", b =>
                {
                    b.Property<int>("MembershipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("ExpireTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastPaid")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("MembershipId");

                    b.HasIndex("StudentId");

                    b.ToTable("Memberships");
                });

            modelBuilder.Entity("KBDataAccessLibrary.Models.RegisterModels.Invitation", b =>
                {
                    b.Property<Guid>("InvitationString")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("AgeCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Belt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.HasKey("InvitationString");

                    b.HasIndex("AgeCategoryId");

                    b.HasIndex("GroupId");

                    b.ToTable("Invitations");
                });

            modelBuilder.Entity("KBDataAccessLibrary.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AgeCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Belt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("StudentId");

                    b.HasIndex("AgeCategoryId");

                    b.HasIndex("GroupId");

                    b.HasIndex("Username");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ClassInstructor", b =>
                {
                    b.HasOne("KBDataAccessLibrary.Models.Class", null)
                        .WithMany()
                        .HasForeignKey("ClassesClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KBDataAccessLibrary.Models.Instructor", null)
                        .WithMany()
                        .HasForeignKey("InstructorsInstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KBDataAccessLibrary.Models.Attendance", b =>
                {
                    b.HasOne("KBDataAccessLibrary.Models.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId");

                    b.HasOne("KBDataAccessLibrary.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.Navigation("Class");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("KBDataAccessLibrary.Models.Class", b =>
                {
                    b.HasOne("KBDataAccessLibrary.Models.AgeCategory", "AgeCategory")
                        .WithMany()
                        .HasForeignKey("AgeCategoryId");

                    b.HasOne("KBDataAccessLibrary.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");

                    b.Navigation("AgeCategory");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("KBDataAccessLibrary.Models.Group", b =>
                {
                    b.HasOne("KBDataAccessLibrary.Models.AgeCategory", "AgeCategory")
                        .WithMany()
                        .HasForeignKey("AgeCategoryId");

                    b.Navigation("AgeCategory");
                });

            modelBuilder.Entity("KBDataAccessLibrary.Models.Membership", b =>
                {
                    b.HasOne("KBDataAccessLibrary.Models.Student", "Student")
                        .WithMany("Memberships")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("KBDataAccessLibrary.Models.RegisterModels.Invitation", b =>
                {
                    b.HasOne("KBDataAccessLibrary.Models.AgeCategory", "AgeCategory")
                        .WithMany()
                        .HasForeignKey("AgeCategoryId");

                    b.HasOne("KBDataAccessLibrary.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");

                    b.Navigation("AgeCategory");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("KBDataAccessLibrary.Models.Student", b =>
                {
                    b.HasOne("KBDataAccessLibrary.Models.AgeCategory", "AgeCategory")
                        .WithMany("Students")
                        .HasForeignKey("AgeCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KBDataAccessLibrary.Models.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KBDataAccessLibrary.Models.LoginModels.User", "User")
                        .WithMany()
                        .HasForeignKey("Username");

                    b.Navigation("AgeCategory");

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KBDataAccessLibrary.Models.AgeCategory", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("KBDataAccessLibrary.Models.Group", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("KBDataAccessLibrary.Models.Student", b =>
                {
                    b.Navigation("Memberships");
                });
#pragma warning restore 612, 618
        }
    }
}
