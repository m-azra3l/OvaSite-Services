﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectService.Data;

#nullable disable

namespace ProjectService.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("ProjectService.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(0);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmpNameId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("OrgNameId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 9, 23, 12, 50, 41, 558, DateTimeKind.Local).AddTicks(8999),
                            Description = "No description",
                            Email = "test@mail.com",
                            EmpNameId = "emp1",
                            LastUpdatedOn = new DateTime(2023, 9, 23, 12, 50, 41, 558, DateTimeKind.Local).AddTicks(9001),
                            OrgNameId = "org1",
                            Username = "username1"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 9, 23, 12, 50, 41, 558, DateTimeKind.Local).AddTicks(9004),
                            Description = "No description",
                            Email = "test@mail.com",
                            EmpNameId = "emp2",
                            LastUpdatedOn = new DateTime(2023, 9, 23, 12, 50, 41, 558, DateTimeKind.Local).AddTicks(9005),
                            OrgNameId = "org1",
                            Username = "username2"
                        });
                });

            modelBuilder.Entity("ProjectService.Models.EmployeeProjectAssociation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(0);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmpNameId")
                        .HasColumnType("TEXT");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("OrgNameId")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Role")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectAssociations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 9, 23, 12, 50, 41, 558, DateTimeKind.Local).AddTicks(9535),
                            Description = "The project manager",
                            EmpNameId = "emp1",
                            EmployeeId = 1,
                            LastUpdatedOn = new DateTime(2023, 9, 23, 12, 50, 41, 558, DateTimeKind.Local).AddTicks(9536),
                            OrgNameId = "org1",
                            ProjectId = 1,
                            Role = "Project Manager"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 9, 23, 12, 50, 41, 558, DateTimeKind.Local).AddTicks(9540),
                            Description = "The project manager",
                            EmpNameId = "emp2",
                            EmployeeId = 2,
                            LastUpdatedOn = new DateTime(2023, 9, 23, 12, 50, 41, 558, DateTimeKind.Local).AddTicks(9540),
                            OrgNameId = "org1",
                            ProjectId = 1,
                            Role = "Supervisor"
                        });
                });

            modelBuilder.Entity("ProjectService.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(0);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Duration")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("OrgNameId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Progress")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("isOrg")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 9, 23, 12, 50, 41, 558, DateTimeKind.Local).AddTicks(9282),
                            CreatorId = "user1",
                            Description = "Project 1 started",
                            Duration = "12 Months",
                            EndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastUpdatedOn = new DateTime(2023, 9, 23, 12, 50, 41, 558, DateTimeKind.Local).AddTicks(9282),
                            Name = "Project1",
                            OrgNameId = "org1",
                            Progress = "6 months",
                            StartDate = new DateTime(2023, 9, 23, 12, 50, 41, 558, DateTimeKind.Local).AddTicks(9281),
                            Status = "In progres",
                            isOrg = true
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 9, 23, 12, 50, 41, 558, DateTimeKind.Local).AddTicks(9344),
                            CreatorId = "user1",
                            Description = "Project 1 started",
                            Duration = "12 Months",
                            EndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastUpdatedOn = new DateTime(2023, 9, 23, 12, 50, 41, 558, DateTimeKind.Local).AddTicks(9345),
                            Name = "Project2",
                            Progress = "6 months",
                            StartDate = new DateTime(2023, 9, 23, 12, 50, 41, 558, DateTimeKind.Local).AddTicks(9343),
                            Status = "In progres",
                            isOrg = false
                        });
                });

            modelBuilder.Entity("ProjectService.Models.ProjectForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(0);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("FormData")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("OrgNameId")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectForms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 9, 23, 12, 50, 41, 558, DateTimeKind.Local).AddTicks(9564),
                            CreatorId = "user1",
                            Description = "Form 1",
                            FormData = "{\"name\":\"Uhanmi V1\",\"description\":\"This is the first or cover image of Uhanmi NFT collection.\",\"image\":\"https://gateway.pinata.cloud/ipfs/QmXxtXrGznUsGoyMCRqCKVU53cuJPeQFxJHmWWiZ74TLvv\"}",
                            LastUpdatedOn = new DateTime(2023, 9, 23, 12, 50, 41, 558, DateTimeKind.Local).AddTicks(9564),
                            OrgNameId = "org1",
                            ProjectId = 1,
                            Title = "Form1"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 9, 23, 12, 50, 41, 558, DateTimeKind.Local).AddTicks(9568),
                            CreatorId = "user1",
                            Description = "Form 2",
                            FormData = "{\"name\":\"Uhanmi V1\",\"description\":\"This is the first or cover image of Uhanmi NFT collection.\",\"image\":\"https://gateway.pinata.cloud/ipfs/QmXxtXrGznUsGoyMCRqCKVU53cuJPeQFxJHmWWiZ74TLvv\"}",
                            LastUpdatedOn = new DateTime(2023, 9, 23, 12, 50, 41, 558, DateTimeKind.Local).AddTicks(9568),
                            ProjectId = 2,
                            Title = "Form2"
                        });
                });

            modelBuilder.Entity("ProjectService.Models.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(0);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("OrgNameId")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProjectFormId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ReportData")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<int>("SubmissionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProjectFormId");

                    b.HasIndex("SubmissionId");

                    b.ToTable("Reports");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 9, 23, 12, 50, 41, 558, DateTimeKind.Local).AddTicks(9598),
                            CreatorId = "user1",
                            Description = "Report 1",
                            LastUpdatedOn = new DateTime(2023, 9, 23, 12, 50, 41, 558, DateTimeKind.Local).AddTicks(9598),
                            OrgNameId = "org1",
                            ReportData = "my report",
                            SubmissionId = 1,
                            Title = "Report1"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 9, 23, 12, 50, 41, 558, DateTimeKind.Local).AddTicks(9602),
                            CreatorId = "user1",
                            Description = "report 2",
                            LastUpdatedOn = new DateTime(2023, 9, 23, 12, 50, 41, 558, DateTimeKind.Local).AddTicks(9602),
                            ReportData = "my report",
                            SubmissionId = 2,
                            Title = "Report2"
                        });
                });

            modelBuilder.Entity("ProjectService.Models.Submission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(0);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("FormId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("OrgNameId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SubmissionData")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.ToTable("Submissions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 9, 23, 12, 50, 41, 558, DateTimeKind.Local).AddTicks(9623),
                            CreatorId = "user1",
                            Description = "Submission 1",
                            FormId = 1,
                            LastUpdatedOn = new DateTime(2023, 9, 23, 12, 50, 41, 558, DateTimeKind.Local).AddTicks(9624),
                            OrgNameId = "org1",
                            SubmissionData = "{\"name\":\"Uhanmi V1\",\"description\":\"This is the first or cover image of Uhanmi NFT collection.\",\"image\":\"https://gateway.pinata.cloud/ipfs/QmXxtXrGznUsGoyMCRqCKVU53cuJPeQFxJHmWWiZ74TLvv\"}",
                            Title = "Submission1"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 9, 23, 12, 50, 41, 558, DateTimeKind.Local).AddTicks(9627),
                            CreatorId = "user1",
                            Description = "Submission 2",
                            FormId = 2,
                            LastUpdatedOn = new DateTime(2023, 9, 23, 12, 50, 41, 558, DateTimeKind.Local).AddTicks(9628),
                            SubmissionData = "{\"name\":\"Uhanmi V1\",\"description\":\"This is the first or cover image of Uhanmi NFT collection.\",\"image\":\"https://gateway.pinata.cloud/ipfs/QmXxtXrGznUsGoyMCRqCKVU53cuJPeQFxJHmWWiZ74TLvv\"}",
                            Title = "Submission2"
                        });
                });

            modelBuilder.Entity("ProjectService.Models.EmployeeProjectAssociation", b =>
                {
                    b.HasOne("ProjectService.Models.Employee", "Employee")
                        .WithMany("ProjectAssociations")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectService.Models.Project", "Project")
                        .WithMany("ProjectAssociations")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ProjectService.Models.ProjectForm", b =>
                {
                    b.HasOne("ProjectService.Models.Project", "Project")
                        .WithMany("ProjectForms")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ProjectService.Models.Report", b =>
                {
                    b.HasOne("ProjectService.Models.ProjectForm", null)
                        .WithMany("Reports")
                        .HasForeignKey("ProjectFormId");

                    b.HasOne("ProjectService.Models.Submission", "Submission")
                        .WithMany("Reports")
                        .HasForeignKey("SubmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Submission");
                });

            modelBuilder.Entity("ProjectService.Models.Submission", b =>
                {
                    b.HasOne("ProjectService.Models.ProjectForm", "ProjectForm")
                        .WithMany("Submissions")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectForm");
                });

            modelBuilder.Entity("ProjectService.Models.Employee", b =>
                {
                    b.Navigation("ProjectAssociations");
                });

            modelBuilder.Entity("ProjectService.Models.Project", b =>
                {
                    b.Navigation("ProjectAssociations");

                    b.Navigation("ProjectForms");
                });

            modelBuilder.Entity("ProjectService.Models.ProjectForm", b =>
                {
                    b.Navigation("Reports");

                    b.Navigation("Submissions");
                });

            modelBuilder.Entity("ProjectService.Models.Submission", b =>
                {
                    b.Navigation("Reports");
                });
#pragma warning restore 612, 618
        }
    }
}
