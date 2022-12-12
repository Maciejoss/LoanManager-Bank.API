﻿// <auto-generated />
using System;
using Bank.API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bank.API.Migrations
{
    [DbContext(typeof(BankContext))]
    partial class BankContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("af7b72a4-6b47-4c68-9713-3ad75bbe0577"),
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
