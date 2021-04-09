﻿// <auto-generated />
using System;
using JobSearchApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JobSearchApp.Migrations
{
    [DbContext(typeof(JobSearchDbContext))]
    [Migration("20210409124355_updated AppliedJob property")]
    partial class updatedAppliedJobproperty
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JobSearchApp.Models.AppliedJob", b =>
                {
                    b.Property<int>("AppliedJobID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("JobPostingID")
                        .HasColumnType("int");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AppliedJobID");

                    b.ToTable("AppliedJob");
                });

            modelBuilder.Entity("JobSearchApp.Models.Candidate", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("FullName")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("UserID");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("JobSearchApp.Models.Employer", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Biography")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("Company")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Email")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("FullName")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("JobTitle")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Phone")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("YearEstablished")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("UserID");

                    b.ToTable("Employers");
                });

            modelBuilder.Entity("JobSearchApp.Models.JobApplication", b =>
                {
                    b.Property<int>("ApplicationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Coverletter")
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Date")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("JobPostingID")
                        .HasColumnType("int");

                    b.Property<int?>("ResumeID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ApplicationID");

                    b.HasIndex("JobPostingID");

                    b.HasIndex("ResumeID");

                    b.HasIndex("UserID");

                    b.ToTable("JobApplications");
                });

            modelBuilder.Entity("JobSearchApp.Models.JobCreated", b =>
                {
                    b.Property<int>("JobCreatedID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("JobPostingID")
                        .HasColumnType("int");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobCreatedID");

                    b.ToTable("JobCreated");
                });

            modelBuilder.Entity("JobSearchApp.Models.JobPosting", b =>
                {
                    b.Property<int>("JobPostingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("CompanyAddress")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("Email")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("JobPostingID");

                    b.HasIndex("UserID");

                    b.ToTable("JobPostings");
                });

            modelBuilder.Entity("JobSearchApp.Models.Notification", b =>
                {
                    b.Property<int>("NotificationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Date")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("Type")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("NotificationID");

                    b.HasIndex("UserID");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("JobSearchApp.Models.Resume", b =>
                {
                    b.Property<int>("ResumeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("HighestEducation")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Language")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Phone")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Skills")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("WorkExperience")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("ResumeID");

                    b.HasIndex("UserID");

                    b.ToTable("Resumes");
                });

            modelBuilder.Entity("JobSearchApp.Models.SavedSearch", b =>
                {
                    b.Property<int>("SavedSearchID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CandidateID")
                        .HasColumnType("int");

                    b.Property<int?>("EmployerID")
                        .HasColumnType("int");

                    b.Property<string>("SearchedTerm")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("SavedSearchID");

                    b.HasIndex("UserID");

                    b.ToTable("SavedSearches");
                });

            modelBuilder.Entity("JobSearchApp.Models.JobApplication", b =>
                {
                    b.HasOne("JobSearchApp.Models.JobPosting", "JobPosting")
                        .WithMany("JobApplications")
                        .HasForeignKey("JobPostingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobSearchApp.Models.Resume", "Resume")
                        .WithMany("JobApplications")
                        .HasForeignKey("ResumeID");

                    b.HasOne("JobSearchApp.Models.Candidate", "Candidate")
                        .WithMany("JobApplications")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("JobPosting");

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("JobSearchApp.Models.JobPosting", b =>
                {
                    b.HasOne("JobSearchApp.Models.Employer", "Employer")
                        .WithMany("JobPostings")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employer");
                });

            modelBuilder.Entity("JobSearchApp.Models.Notification", b =>
                {
                    b.HasOne("JobSearchApp.Models.Candidate", "Candidate")
                        .WithMany("Notifications")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobSearchApp.Models.Employer", "Employer")
                        .WithMany("Notifications")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("Employer");
                });

            modelBuilder.Entity("JobSearchApp.Models.Resume", b =>
                {
                    b.HasOne("JobSearchApp.Models.Candidate", "Candidate")
                        .WithMany("Resumes")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("JobSearchApp.Models.SavedSearch", b =>
                {
                    b.HasOne("JobSearchApp.Models.Candidate", "Candidate")
                        .WithMany("SavedSearches")
                        .HasForeignKey("UserID");

                    b.HasOne("JobSearchApp.Models.Employer", "Employer")
                        .WithMany("SavedSearches")
                        .HasForeignKey("UserID");

                    b.Navigation("Candidate");

                    b.Navigation("Employer");
                });

            modelBuilder.Entity("JobSearchApp.Models.Candidate", b =>
                {
                    b.Navigation("JobApplications");

                    b.Navigation("Notifications");

                    b.Navigation("Resumes");

                    b.Navigation("SavedSearches");
                });

            modelBuilder.Entity("JobSearchApp.Models.Employer", b =>
                {
                    b.Navigation("JobPostings");

                    b.Navigation("Notifications");

                    b.Navigation("SavedSearches");
                });

            modelBuilder.Entity("JobSearchApp.Models.JobPosting", b =>
                {
                    b.Navigation("JobApplications");
                });

            modelBuilder.Entity("JobSearchApp.Models.Resume", b =>
                {
                    b.Navigation("JobApplications");
                });
#pragma warning restore 612, 618
        }
    }
}
