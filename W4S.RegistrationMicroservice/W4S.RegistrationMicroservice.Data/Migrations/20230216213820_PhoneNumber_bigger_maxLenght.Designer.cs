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
    [Migration("20230216213820_PhoneNumber_bigger_maxLenght")]
    partial class PhoneNumberbiggermaxLenght
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

                    b.Property<string>("EmailAddress")
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
                            Id = new Guid("289a090d-91e5-46ff-a4e6-933571d6733b"),
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
                            Id = new Guid("e406e74f-c1c3-48de-9caa-8734cc046537"),
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
                            Id = new Guid("33217a56-ca8a-4e15-aae5-dc7f223dbae9"),
                            EmailDomainId = new Guid("e406e74f-c1c3-48de-9caa-8734cc046537"),
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
                            Id = new Guid("d3dba7a5-e7e4-45b9-a268-7ca10f159ac9"),
                            Description = "Student"
                        },
                        new
                        {
                            Id = new Guid("1c1987a5-d5af-43e6-97d9-7cc886c08f61"),
                            Description = "Employer"
                        },
                        new
                        {
                            Id = new Guid("7adc31ec-b4a2-43d7-aafb-3d81bf543741"),
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
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

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
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Profiles.StudentProfile", b =>
                {
                    b.HasBaseType("W4S.RegistrationMicroservice.Data.Entities.Profiles.Profile");

                    b.Property<string>("Education")
                        .HasColumnType("text");

                    b.Property<string>("Experience")
                        .HasColumnType("text");

                    b.Property<byte[]>("ResumeFile")
                        .HasMaxLength(5242880)
                        .HasColumnType("bytea");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentProfiles");
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Users.Administrator", b =>
                {
                    b.HasBaseType("W4S.RegistrationMicroservice.Data.Entities.Users.User");

                    b.ToTable("Administrators");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3440b5e3-94d0-4fa2-b138-4b60fe79942b"),
                            Building = "2a",
                            City = "Gliwice",
                            Country = "Poland",
                            EmailAddress = "someAdmin@gmail.com",
                            Name = "Admin",
                            PasswordHash = "61646d696e31323334",
                            PhoneNumber = "2137",
                            Region = "Silesia",
                            RoleId = new Guid("7adc31ec-b4a2-43d7-aafb-3d81bf543741"),
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
                });

            modelBuilder.Entity("W4S.RegistrationMicroservice.Data.Entities.Users.Student", b =>
                {
                    b.HasBaseType("W4S.RegistrationMicroservice.Data.Entities.Users.User");

                    b.Property<Guid>("UniversityId")
                        .HasColumnType("uuid");

                    b.HasIndex("UniversityId");

                    b.ToTable("Students");
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
