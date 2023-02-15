﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NpgsqlTypes;
using W4S.PostingService.Persistence;

#nullable disable

namespace W4S.PostingService.Persistence.Migrations
{
    [DbContext(typeof(PostingContext))]
    [Migration("20230215004511_Ratings")]
    partial class Ratings
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
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

                    b.Property<Guid?>("ReviewId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("WorkTimeOverlap")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("OfferId");

                    b.HasIndex("ReviewId");

                    b.HasIndex("StudentId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("W4S.PostingService.Domain.Entities.ApplicationReview", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Rating")
                        .HasColumnType("numeric");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId")
                        .IsUnique();

                    b.ToTable("ApplicationReviews", (string)null);
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
                            Id = new Guid("3cf0ccfc-3d7a-456b-9c94-39166906b1db"),
                            NIP = "7821160955",
                            Name = "Comarch"
                        });
                });

            modelBuilder.Entity("W4S.PostingService.Domain.Entities.JobOffer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Categories")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Mode")
                        .HasColumnType("integer");

                    b.Property<Guid>("RecruiterId")
                        .HasColumnType("uuid");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<NpgsqlTsVector>("SearchVector")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("tsvector")
                        .HasAnnotation("Npgsql:TsVectorConfig", "english")
                        .HasAnnotation("Npgsql:TsVectorProperties", new[] { "Role", "Description", "Title" });

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RecruiterId");

                    b.HasIndex("SearchVector");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("SearchVector"), "GIN");

                    b.ToTable("JobOffers");
                });

            modelBuilder.Entity("W4S.PostingService.Domain.Entities.OfferReview", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OfferId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Rating")
                        .HasColumnType("numeric");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OfferId");

                    b.HasIndex("SubjectId");

                    b.ToTable("OfferReviews", (string)null);
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
                        .HasColumnType("text");

                    b.Property<decimal>("Rating")
                        .HasColumnType("numeric");

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
                            Id = new Guid("c79f3320-8e6a-40a6-8e97-3797510dcdde"),
                            CompanyId = new Guid("3cf0ccfc-3d7a-456b-9c94-39166906b1db"),
                            EmailAddress = "noreply@company.et",
                            FirstName = "John",
                            PhoneNumber = "123456789",
                            Rating = 0m,
                            SecondName = "",
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
                        .HasColumnType("text");

                    b.Property<decimal>("Rating")
                        .HasColumnType("numeric");

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
                            Id = new Guid("95935e7f-14ca-40e4-b2fe-dc76897fd4d2"),
                            EmailAddress = "noreply@company.et",
                            FirstName = "John",
                            PhoneNumber = "123456789",
                            Rating = 0m,
                            SecondName = "",
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

                    b.HasOne("W4S.PostingService.Domain.Entities.ApplicationReview", "Review")
                        .WithMany()
                        .HasForeignKey("ReviewId");

                    b.HasOne("W4S.PostingService.Domain.Entities.Student", "Student")
                        .WithMany("Applications")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Offer");

                    b.Navigation("Review");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("W4S.PostingService.Domain.Entities.ApplicationReview", b =>
                {
                    b.HasOne("W4S.PostingService.Domain.Entities.Application", "Application")
                        .WithOne()
                        .HasForeignKey("W4S.PostingService.Domain.Entities.ApplicationReview", "SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");
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

            modelBuilder.Entity("W4S.PostingService.Domain.Entities.OfferReview", b =>
                {
                    b.HasOne("W4S.PostingService.Domain.Entities.JobOffer", "Offer")
                        .WithMany()
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("W4S.PostingService.Domain.Entities.JobOffer", null)
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Offer");
                });

            modelBuilder.Entity("W4S.PostingService.Domain.Entities.Recruiter", b =>
                {
                    b.HasOne("W4S.PostingService.Domain.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("W4S.PostingService.Domain.ValueType.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("RecruiterId")
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

                            b1.HasKey("RecruiterId");

                            b1.ToTable("Recruiters");

                            b1.WithOwner()
                                .HasForeignKey("RecruiterId");

                            b1.HasData(
                                new
                                {
                                    RecruiterId = new Guid("c79f3320-8e6a-40a6-8e97-3797510dcdde"),
                                    Building = "24",
                                    City = "Gliwice",
                                    Country = "Polandia",
                                    Region = "Silesia",
                                    Street = "Wrocławska"
                                });
                        });

                    b.Navigation("Address")
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
                                    StudentId = new Guid("95935e7f-14ca-40e4-b2fe-dc76897fd4d2"),
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
