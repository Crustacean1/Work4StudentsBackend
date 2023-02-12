﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using W4S.PostingService.Persistence;

#nullable disable

namespace W4S.PostingService.Persistence.Migrations
{
    [DbContext(typeof(PostingContext))]
    [Migration("20230212132234_Remove address from company")]
    partial class Removeaddressfromcompany
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("W4S.PostingService.Domain.Entities.Application", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LastChanged")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OfferId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Proximity")
                        .HasColumnType("numeric");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("WorkTimeOverlap")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("OfferId");

                    b.HasIndex("StudentId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("W4S.PostingService.Domain.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("NIP")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8db7c987-8a09-4904-9c95-bda5dfe55f2f"),
                            NIP = "7821160955",
                            Name = "Comarch"
                        });
                });

            modelBuilder.Entity("W4S.PostingService.Domain.Entities.JobOffer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RecruiterId")
                        .HasColumnType("uuid");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RecruiterId");

                    b.ToTable("JobOffers");
                });

            modelBuilder.Entity("W4S.PostingService.Domain.Entities.Recruiter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SecondName")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Recruiters");

                    b.HasData(
                        new
                        {
                            Id = new Guid("935b10a7-f02d-4e8e-a9e6-729f3e38afe7"),
                            CompanyId = new Guid("8db7c987-8a09-4904-9c95-bda5dfe55f2f"),
                            EmailAddress = "noreply@company.et",
                            FirstName = "John",
                            PhoneNumber = "123456789",
                            Surname = "Smith"
                        });
                });

            modelBuilder.Entity("W4S.PostingService.Domain.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SecondName")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Applicants");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e49f7268-2dd6-4f4b-9709-c828373ae6b7"),
                            EmailAddress = "noreply@company.et",
                            FirstName = "John",
                            PhoneNumber = "123456789",
                            Surname = "Smith"
                        });
                });

            modelBuilder.Entity("W4S.PostingService.Domain.Entities.Application", b =>
                {
                    b.HasOne("W4S.PostingService.Domain.Entities.JobOffer", "Offer")
                        .WithMany("Applications")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("W4S.PostingService.Domain.Entities.Student", "Student")
                        .WithMany("Applications")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Offer");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("W4S.PostingService.Domain.Entities.JobOffer", b =>
                {
                    b.HasOne("W4S.PostingService.Domain.Entities.Recruiter", "Recruiter")
                        .WithMany("Offers")
                        .HasForeignKey("RecruiterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("W4S.PostingService.Domain.ValueType.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("JobOfferId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Building")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Region")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("JobOfferId");

                            b1.ToTable("JobOffers");

                            b1.WithOwner()
                                .HasForeignKey("JobOfferId");
                        });

                    b.OwnsMany("W4S.PostingService.Domain.Models.Schedule", "WorkingHours", b1 =>
                        {
                            b1.Property<Guid>("JobOfferId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<DateTime>("End")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<DateTime>("Start")
                                .HasColumnType("timestamp with time zone");

                            b1.HasKey("JobOfferId", "Id");

                            b1.ToTable("JobOffers_WorkingHours");

                            b1.WithOwner()
                                .HasForeignKey("JobOfferId");
                        });

                    b.OwnsOne("W4S.PostingService.Domain.Models.PayRange", "PayRange", b1 =>
                        {
                            b1.Property<Guid>("JobOfferId")
                                .HasColumnType("uuid");

                            b1.Property<decimal>("Max")
                                .HasColumnType("numeric");

                            b1.Property<decimal>("Min")
                                .HasColumnType("numeric");

                            b1.HasKey("JobOfferId");

                            b1.ToTable("JobOffers");

                            b1.WithOwner()
                                .HasForeignKey("JobOfferId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("PayRange")
                        .IsRequired();

                    b.Navigation("Recruiter");

                    b.Navigation("WorkingHours");
                });

            modelBuilder.Entity("W4S.PostingService.Domain.Entities.Recruiter", b =>
                {
                    b.HasOne("W4S.PostingService.Domain.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("W4S.PostingService.Domain.Entities.Student", b =>
                {
                    b.OwnsOne("W4S.PostingService.Domain.ValueType.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("StudentId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Building")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Region")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("StudentId");

                            b1.ToTable("Applicants");

                            b1.WithOwner()
                                .HasForeignKey("StudentId");

                            b1.HasData(
                                new
                                {
                                    StudentId = new Guid("e49f7268-2dd6-4f4b-9709-c828373ae6b7"),
                                    Building = "Boilding",
                                    City = "Gliwice",
                                    Country = "Polandia",
                                    Region = "Silesia",
                                    Street = "Street"
                                });
                        });

                    b.OwnsMany("W4S.PostingService.Domain.Models.Schedule", "Availability", b1 =>
                        {
                            b1.Property<Guid>("StudentId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<DateTime>("End")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<DateTime>("Start")
                                .HasColumnType("timestamp with time zone");

                            b1.HasKey("StudentId", "Id");

                            b1.ToTable("Applicants_Availability");

                            b1.WithOwner()
                                .HasForeignKey("StudentId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Availability");
                });

            modelBuilder.Entity("W4S.PostingService.Domain.Entities.JobOffer", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("W4S.PostingService.Domain.Entities.Recruiter", b =>
                {
                    b.Navigation("Offers");
                });

            modelBuilder.Entity("W4S.PostingService.Domain.Entities.Student", b =>
                {
                    b.Navigation("Applications");
                });
#pragma warning restore 612, 618
        }
    }
}
