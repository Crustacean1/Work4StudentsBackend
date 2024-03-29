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
    [Migration("20230214220608_profiles_studentSchedules")]
    partial class profilesstudentSchedules
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

                    b.Property<string>("Building")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Education")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Experience")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<byte[]>("PhotoFile")
                        .HasMaxLength(5242880)
                        .HasColumnType("bytea");

                    b.Property<decimal>("Rating")
                        .HasColumnType("numeric");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ShortDescription")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Profiles");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Profiles.StudentSchedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("End")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("StudentProfileId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StudentProfileId");

                    b.ToTable("StudentSchedule");
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
                            Id = new Guid("930cf773-5b4a-4c66-89fa-5b1225adc5fa"),
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
                            Id = new Guid("4a2d363d-0412-47ee-b993-bcf3da104e55"),
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
                            Id = new Guid("7172c284-148e-49c6-940e-0cecf7f9e512"),
                            EmailDomainId = new Guid("4a2d363d-0412-47ee-b993-bcf3da104e55"),
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
                            Id = new Guid("1279857c-6eeb-4f2d-87c2-487c75562d53"),
                            Description = "Student"
                        },
                        new
                        {
                            Id = new Guid("a3a9ffa6-c14a-4ce6-bb3e-52136dacb554"),
                            Description = "Employer"
                        },
                        new
                        {
                            Id = new Guid("8c0ada49-8685-473c-a7fb-a7ff808d8246"),
                            Description = "Administrator"
                        });
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Users.User", b =>
                {
                    b.HasBaseType("W4S.RegistrationMicroservice.Data.Entities.Entity");

                    b.Property<string>("Building")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

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

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<string>("SecondName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Profiles.EmployerProfile", b =>
                {
                    b.HasBaseType("W4S.RegistrationMicroservice.Data.Entities.Profiles.Profile");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("EmployerId")
                        .HasColumnType("uuid");

                    b.Property<string>("PositionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasIndex("EmployerId");

                    b.ToTable("EmployerProfiles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5d5992bd-b095-4fdb-8a90-5479d9dfda0f"),
                            Building = "2a",
                            City = "Gliwice",
                            Country = "Poland",
                            Description = "My company is the best.",
                            Education = "Bachelor in Milfology",
                            EmailAddress = "someEmployer@gmail.com",
                            Experience = "5 years as Milfhunter",
                            PhoneNumber = "2137",
                            Rating = 0.0m,
                            Region = "Silesia",
                            ShortDescription = "My company...",
                            Street = "Akademicka",
                            CompanyName = "Empty firm in Poland",
                            EmployerId = new Guid("52d5f876-7f6d-4441-989a-d509973f829d"),
                            PositionName = "Majster HR"
                        });
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Profiles.StudentProfile", b =>
                {
                    b.HasBaseType("W4S.RegistrationMicroservice.Data.Entities.Profiles.Profile");

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
                            Id = new Guid("a94ee216-8b97-4a27-82d7-00e3418bceda"),
                            Building = "2a",
                            City = "Gliwice",
                            Country = "Poland",
                            Description = "My university is the best.",
                            Education = "Silesian University of Science, Informatics",
                            EmailAddress = "someEmployer@gmail.com",
                            Experience = "20 years in Unity",
                            PhoneNumber = "+2137",
                            Rating = 0.0m,
                            Region = "Silesia",
                            ShortDescription = "My university...",
                            Street = "Akademicka",
                            StudentId = new Guid("7caf3c71-2e75-4de6-8fc3-99ffe2e8d5b5")
                        });
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Users.Administrator", b =>
                {
                    b.HasBaseType("W4S.RegistrationMicroservice.Data.Entities.Users.User");

                    b.ToTable("Administrators");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0f6b8c35-69af-444e-8c33-afc4973772c0"),
                            Building = "2a",
                            City = "Gliwice",
                            Country = "Poland",
                            EmailAddress = "someAdmin@gmail.com",
                            Name = "Admin",
                            PasswordHash = "61646d696e31323334",
                            PhoneNumber = "2137",
                            Region = "Silesia",
                            RoleId = new Guid("8c0ada49-8685-473c-a7fb-a7ff808d8246"),
                            SecondName = "Adminsky",
                            Street = "Akademicka",
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
                            Id = new Guid("52d5f876-7f6d-4441-989a-d509973f829d"),
                            Building = "2a",
                            City = "Gliwice",
                            Country = "Poland",
                            EmailAddress = "someEmployer@gmail.com",
                            Name = "Adam",
                            PasswordHash = "61646d696e",
                            PhoneNumber = "2137",
                            Region = "Silesia",
                            RoleId = new Guid("a3a9ffa6-c14a-4ce6-bb3e-52136dacb554"),
                            SecondName = "Szef",
                            Street = "Akademicka",
                            Surname = "Małysz",
                            CompanyId = new Guid("930cf773-5b4a-4c66-89fa-5b1225adc5fa"),
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
                            Id = new Guid("7caf3c71-2e75-4de6-8fc3-99ffe2e8d5b5"),
                            Building = "2a",
                            City = "Gliwice",
                            Country = "Poland",
                            EmailAddress = "student.debil@polsl.pl",
                            Name = "John",
                            PasswordHash = "61646d696e",
                            PhoneNumber = "+2137",
                            Region = "Silesia",
                            RoleId = new Guid("1279857c-6eeb-4f2d-87c2-487c75562d53"),
                            SecondName = "Karol",
                            Street = "Akademicka",
                            Surname = "Pavulon",
                            UniversityId = new Guid("7172c284-148e-49c6-940e-0cecf7f9e512")
                        });
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Profiles.StudentSchedule", b =>
                {
                    b.HasOne("W4S.RegistrationMicroservice.Data.Entities.Profiles.StudentProfile", "StudentProfile")
                        .WithMany("Avaiability")
                        .HasForeignKey("StudentProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudentProfile");
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

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Profiles.StudentProfile", b =>
                {
                    b.Navigation("Avaiability");
                });
#pragma warning restore 612, 618
        }
    }
}
