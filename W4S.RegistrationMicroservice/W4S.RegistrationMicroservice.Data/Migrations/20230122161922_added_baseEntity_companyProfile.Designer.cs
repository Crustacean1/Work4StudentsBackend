﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using W4S.RegistrationMicroservice.Data.DbContexts;

#nullable disable

namespace W4S.RegistrationMicroservice.Data.Migrations
{
    [DbContext(typeof(UserbaseDbContext))]
    [Migration("20230122161922_added_baseEntity_companyProfile")]
    partial class addedbaseEntitycompanyProfile
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Entity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Entities");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Profiles.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<Guid>("EntityId")
                        .HasColumnType("uuid");

                    b.Property<byte[]>("Image")
                        .HasMaxLength(5242880)
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("Profiles");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Users.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("RatingValue")
                        .HasColumnType("numeric");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Company", b =>
                {
                    b.HasBaseType("W4S.RegistrationMicroservice.Data.Entities.Entity");

                    b.Property<string>("NIP")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("da7110ab-5dea-4bdf-b43a-5ba4df109ef0"),
                            NIP = "5283121250",
                            Name = "Empty firm in Poland"
                        });
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Domain", b =>
                {
                    b.HasBaseType("W4S.RegistrationMicroservice.Data.Entities.Entity");

                    b.Property<string>("EmailDomain")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.ToTable("UniversitiesDomains");

                    b.HasData(
                        new
                        {
                            Id = new Guid("28e3fba5-6950-4ea6-af77-14f214ad5ac0"),
                            EmailDomain = "@polsl.pl"
                        });
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.University", b =>
                {
                    b.HasBaseType("W4S.RegistrationMicroservice.Data.Entities.Entity");

                    b.Property<Guid>("EmailDomainId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasIndex("EmailDomainId");

                    b.ToTable("Universities");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e47ff4f4-1a4c-4959-9e79-107cfd6cff50"),
                            EmailDomainId = new Guid("28e3fba5-6950-4ea6-af77-14f214ad5ac0"),
                            Name = "Politechnika Śląska"
                        });
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Users.Role", b =>
                {
                    b.HasBaseType("W4S.RegistrationMicroservice.Data.Entities.Entity");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f0a976e5-4942-44a7-a4e5-bf1890ffda6d"),
                            Description = "Student"
                        },
                        new
                        {
                            Id = new Guid("a6de2522-dd2b-4e16-a5c1-6a76dd1a5ab1"),
                            Description = "Employer"
                        },
                        new
                        {
                            Id = new Guid("bad026f2-09aa-445d-b1bf-620ca9d48949"),
                            Description = "Administrator"
                        });
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Users.User", b =>
                {
                    b.HasBaseType("W4S.RegistrationMicroservice.Data.Entities.Entity");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<string>("SecondName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Profiles.CompanyProfile", b =>
                {
                    b.HasBaseType("W4S.RegistrationMicroservice.Data.Entities.Profiles.Profile");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanyProfiles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d3b15d3c-f906-47d5-b9d3-d14de7f9454c"),
                            Description = "Greatest company there is.",
                            EntityId = new Guid("da7110ab-5dea-4bdf-b43a-5ba4df109ef0"),
                            Image = new byte[] { 0, 0, 0, 0 },
                            CompanyId = new Guid("da7110ab-5dea-4bdf-b43a-5ba4df109ef0")
                        });
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Profiles.EmployerProfile", b =>
                {
                    b.HasBaseType("W4S.RegistrationMicroservice.Data.Entities.Profiles.Profile");

                    b.Property<Guid>("EmployerId")
                        .HasColumnType("uuid");

                    b.HasIndex("EmployerId");

                    b.ToTable("EmployerProfiles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3c3ab5ea-9230-4c35-acac-dfba74865ee7"),
                            Description = "My company is the best.",
                            EntityId = new Guid("99a7e609-bc6e-4229-9c36-5fd413329a2d"),
                            Image = new byte[] { 0, 0, 0, 0 },
                            EmployerId = new Guid("99a7e609-bc6e-4229-9c36-5fd413329a2d")
                        });
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Profiles.StudentProfile", b =>
                {
                    b.HasBaseType("W4S.RegistrationMicroservice.Data.Entities.Profiles.Profile");

                    b.Property<decimal>("Rating")
                        .HasColumnType("numeric");

                    b.Property<byte[]>("ResumeFile")
                        .HasMaxLength(5242880)
                        .HasColumnType("bytea");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentProfiles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b62ba221-2f57-4c58-920a-08d1e7def693"),
                            Description = "My university is the best.",
                            EntityId = new Guid("0a49ca2b-deca-477e-b598-e1a1ce8cfd57"),
                            Image = new byte[] { 0, 0, 0, 0 },
                            Rating = 0m,
                            StudentId = new Guid("0a49ca2b-deca-477e-b598-e1a1ce8cfd57")
                        });
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Users.Administrator", b =>
                {
                    b.HasBaseType("W4S.RegistrationMicroservice.Data.Entities.Users.User");

                    b.ToTable("Administrators");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ac2200c2-b3e1-4ef9-bde7-6d77fa525f2b"),
                            EmailAddress = "someAdmin@gmail.com",
                            Name = "Admin",
                            PasswordHash = "61646d696e31323334",
                            PhoneNumber = "2137",
                            RoleId = new Guid("bad026f2-09aa-445d-b1bf-620ca9d48949"),
                            SecondName = "Adminsky",
                            Surname = "Administator"
                        });
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Users.Employer", b =>
                {
                    b.HasBaseType("W4S.RegistrationMicroservice.Data.Entities.Users.User");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<string>("PositionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasIndex("CompanyId");

                    b.ToTable("Employers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("99a7e609-bc6e-4229-9c36-5fd413329a2d"),
                            EmailAddress = "someEmployer@gmail.com",
                            Name = "Adam",
                            PasswordHash = "61646d696e",
                            PhoneNumber = "2137",
                            RoleId = new Guid("a6de2522-dd2b-4e16-a5c1-6a76dd1a5ab1"),
                            SecondName = "Szef",
                            Surname = "Małysz",
                            CompanyId = new Guid("da7110ab-5dea-4bdf-b43a-5ba4df109ef0"),
                            PositionName = "Majster HR"
                        });
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Users.Student", b =>
                {
                    b.HasBaseType("W4S.RegistrationMicroservice.Data.Entities.Users.User");

                    b.Property<Guid>("UniversityId")
                        .HasColumnType("uuid");

                    b.HasIndex("UniversityId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0a49ca2b-deca-477e-b598-e1a1ce8cfd57"),
                            EmailAddress = "student.debil@polsl.pl",
                            Name = "John",
                            PasswordHash = "61646d696e",
                            PhoneNumber = "+2137",
                            RoleId = new Guid("f0a976e5-4942-44a7-a4e5-bf1890ffda6d"),
                            SecondName = "Karol",
                            Surname = "Pavulon",
                            UniversityId = new Guid("e47ff4f4-1a4c-4959-9e79-107cfd6cff50")
                        });
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Users.Rating", b =>
                {
                    b.HasOne("W4S.RegistrationMicroservice.Data.Entities.Users.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.University", b =>
                {
                    b.HasOne("W4S.RegistrationMicroservice.Data.Entities.Domain", "EmailDomain")
                        .WithMany()
                        .HasForeignKey("EmailDomainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmailDomain");
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Users.Role", b =>
                {
                    b.HasOne("W4S.RegistrationMicroservice.Data.Entities.Entity", null)
                        .WithOne()
                        .HasForeignKey("W4S.RegistrationMicroservice.Data.Entities.Users.Role", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Users.User", b =>
                {
                    b.HasOne("W4S.RegistrationMicroservice.Data.Entities.Entity", null)
                        .WithOne()
                        .HasForeignKey("W4S.RegistrationMicroservice.Data.Entities.Users.User", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("W4S.RegistrationMicroservice.Data.Entities.Users.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Profiles.CompanyProfile", b =>
                {
                    b.HasOne("W4S.RegistrationMicroservice.Data.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Profiles.EmployerProfile", b =>
                {
                    b.HasOne("W4S.RegistrationMicroservice.Data.Entities.Users.Employer", "Employer")
                        .WithMany()
                        .HasForeignKey("EmployerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("W4S.RegistrationMicroservice.Data.Entities.Profiles.Profile", null)
                        .WithOne()
                        .HasForeignKey("W4S.RegistrationMicroservice.Data.Entities.Profiles.EmployerProfile", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employer");
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Profiles.StudentProfile", b =>
                {
                    b.HasOne("W4S.RegistrationMicroservice.Data.Entities.Profiles.Profile", null)
                        .WithOne()
                        .HasForeignKey("W4S.RegistrationMicroservice.Data.Entities.Profiles.StudentProfile", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("W4S.RegistrationMicroservice.Data.Entities.Users.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Users.Administrator", b =>
                {
                    b.HasOne("W4S.RegistrationMicroservice.Data.Entities.Users.User", null)
                        .WithOne()
                        .HasForeignKey("W4S.RegistrationMicroservice.Data.Entities.Users.Administrator", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Users.Employer", b =>
                {
                    b.HasOne("W4S.RegistrationMicroservice.Data.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("W4S.RegistrationMicroservice.Data.Entities.Users.User", null)
                        .WithOne()
                        .HasForeignKey("W4S.RegistrationMicroservice.Data.Entities.Users.Employer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Users.Student", b =>
                {
                    b.HasOne("W4S.RegistrationMicroservice.Data.Entities.Users.User", null)
                        .WithOne()
                        .HasForeignKey("W4S.RegistrationMicroservice.Data.Entities.Users.Student", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("W4S.RegistrationMicroservice.Data.Entities.University", "University")
                        .WithMany()
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });
#pragma warning restore 612, 618
        }
    }
}
