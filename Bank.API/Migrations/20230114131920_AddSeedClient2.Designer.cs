﻿// <auto-generated />
using System;
using Bank.API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bank.API.Migrations
{
    [DbContext(typeof(BankContext))]
    [Migration("20230114131920_AddSeedClient2")]
    partial class AddSeedClient2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bank.API.Models.Inquiries.Inquiry", b =>
                {
                    b.Property<int>("InquiryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InquiryID"));

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("InstallmentsNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("InquiryID");

                    b.HasIndex("ClientId");

                    b.ToTable("Inquiries");
                });

            modelBuilder.Entity("Bank.API.Models.Offers.Offer", b =>
                {
                    b.Property<int>("OfferID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OfferID"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocumentLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DocumentLinkValidDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InquiryID")
                        .HasColumnType("int");

                    b.Property<double>("MonthlyInstallment")
                        .HasColumnType("float");

                    b.Property<double>("Percentage")
                        .HasColumnType("float");

                    b.Property<int>("RequestedPeriodInMonth")
                        .HasColumnType("int");

                    b.Property<double>("RequestedValue")
                        .HasColumnType("float");

                    b.Property<Guid?>("ReviewerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("StatusID")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("OfferID");

                    b.HasIndex("ReviewerId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("Bank.API.Models.Users.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("GovernmentDocumentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("JobDetailsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GovernmentDocumentId");

                    b.HasIndex("JobDetailsId");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("37846734-172e-4149-8cec-6f43d1eb3f60"),
                            Email = "klient.jeden@example.com",
                            GovernmentDocumentId = new Guid("9150ebd7-dd84-4c97-bf58-62f1c3611545"),
                            JobDetailsId = new Guid("46b087f9-5c71-401f-a5cf-021274463715"),
                            Name = "Klient",
                            Surname = "Jeden"
                        },
                        new
                        {
                            Id = new Guid("37846734-172e-4149-8cec-6f43d1eb3f06"),
                            Email = "klient.dwa@example.com",
                            GovernmentDocumentId = new Guid("9150ebd7-dd84-4c97-bf58-62f1c3611554"),
                            JobDetailsId = new Guid("46b087f9-5c71-401f-a5cf-021274463751"),
                            Name = "Klient",
                            Surname = "Dwa"
                        });
                });

            modelBuilder.Entity("Bank.API.Models.Users.ClientInfo.GovernmentDocument", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GovernmentDocument");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9150ebd7-dd84-4c97-bf58-62f1c3611545"),
                            Description = "Driver License",
                            Name = "Driver License",
                            Number = "number",
                            TypeId = 1
                        },
                        new
                        {
                            Id = new Guid("9150ebd7-dd84-4c97-bf58-62f1c3611554"),
                            Description = "Passport",
                            Name = "Passport",
                            Number = "number",
                            TypeId = 2
                        });
                });

            modelBuilder.Entity("Bank.API.Models.Users.ClientInfo.JobDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("JobDetails");

                    b.HasData(
                        new
                        {
                            Id = new Guid("46b087f9-5c71-401f-a5cf-021274463715"),
                            Description = "Director",
                            Name = "Director",
                            StartDate = new DateTime(2022, 8, 14, 14, 19, 20, 366, DateTimeKind.Local).AddTicks(112),
                            TypeId = 30
                        },
                        new
                        {
                            Id = new Guid("46b087f9-5c71-401f-a5cf-021274463751"),
                            Description = "Agent",
                            EndDate = new DateTime(2023, 1, 13, 14, 19, 20, 366, DateTimeKind.Local).AddTicks(235),
                            Name = "Agent",
                            StartDate = new DateTime(2021, 10, 14, 14, 19, 20, 366, DateTimeKind.Local).AddTicks(231),
                            TypeId = 37
                        });
                });

            modelBuilder.Entity("Bank.API.Models.Users.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                            Email = "pracownik.jeden01@gmail.com",
                            Name = "pracownik",
                            Surname = "jeden"
                        });
                });

            modelBuilder.Entity("Bank.API.Models.Inquiries.Inquiry", b =>
                {
                    b.HasOne("Bank.API.Models.Users.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Bank.API.Models.Offers.Offer", b =>
                {
                    b.HasOne("Bank.API.Models.Users.Employee", "Reviewer")
                        .WithMany()
                        .HasForeignKey("ReviewerId");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("Bank.API.Models.Users.Client", b =>
                {
                    b.HasOne("Bank.API.Models.Users.ClientInfo.GovernmentDocument", "GovernmentDocument")
                        .WithMany()
                        .HasForeignKey("GovernmentDocumentId");

                    b.HasOne("Bank.API.Models.Users.ClientInfo.JobDetails", "JobDetails")
                        .WithMany()
                        .HasForeignKey("JobDetailsId");

                    b.Navigation("GovernmentDocument");

                    b.Navigation("JobDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
