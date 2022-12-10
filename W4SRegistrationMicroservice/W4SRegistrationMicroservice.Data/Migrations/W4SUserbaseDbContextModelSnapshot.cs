﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using W4SRegistrationMicroservice.Data.DbContexts;

#nullable disable

namespace W4SRegistrationMicroservice.Data.Migrations
{
    [DbContext(typeof(W4SUserbaseDbContext))]
    partial class W4SUserbaseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("W4SRegistrationMicroservice.Data.Entities.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("NIP")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("W4SRegistrationMicroservice.Data.Entities.Universities.Domain", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("EmailDomain")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("UniversitiesDomains");
                });

            modelBuilder.Entity("W4SRegistrationMicroservice.Data.Entities.Universities.University", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("EmailDomainId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("EmailDomainId");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("W4SRegistrationMicroservice.Data.Entities.Users.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("W4SRegistrationMicroservice.Data.Entities.Users.User_Settings.Roles", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("W4SRegistrationMicroservice.Data.Entities.Users.Administrator", b =>
                {
                    b.HasBaseType("W4SRegistrationMicroservice.Data.Entities.Users.User");

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("W4SRegistrationMicroservice.Data.Entities.Users.Employer", b =>
                {
                    b.HasBaseType("W4SRegistrationMicroservice.Data.Entities.Users.User");

                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<string>("PositionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("CompanyId");

                    b.ToTable("Employers");
                });

            modelBuilder.Entity("W4SRegistrationMicroservice.Data.Entities.Users.Student", b =>
                {
                    b.HasBaseType("W4SRegistrationMicroservice.Data.Entities.Users.User");

                    b.Property<long>("UniversityId")
                        .HasColumnType("bigint");

                    b.HasIndex("UniversityId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("W4SRegistrationMicroservice.Data.Entities.Universities.University", b =>
                {
                    b.HasOne("W4SRegistrationMicroservice.Data.Entities.Universities.Domain", "EmailDomain")
                        .WithMany()
                        .HasForeignKey("EmailDomainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmailDomain");
                });

            modelBuilder.Entity("W4SRegistrationMicroservice.Data.Entities.Users.User", b =>
                {
                    b.HasOne("W4SRegistrationMicroservice.Data.Entities.Users.User_Settings.Roles", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("W4SRegistrationMicroservice.Data.Entities.Users.Administrator", b =>
                {
                    b.HasOne("W4SRegistrationMicroservice.Data.Entities.Users.User", null)
                        .WithOne()
                        .HasForeignKey("W4SRegistrationMicroservice.Data.Entities.Users.Administrator", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("W4SRegistrationMicroservice.Data.Entities.Users.Employer", b =>
                {
                    b.HasOne("W4SRegistrationMicroservice.Data.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("W4SRegistrationMicroservice.Data.Entities.Users.User", null)
                        .WithOne()
                        .HasForeignKey("W4SRegistrationMicroservice.Data.Entities.Users.Employer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("W4SRegistrationMicroservice.Data.Entities.Users.Student", b =>
                {
                    b.HasOne("W4SRegistrationMicroservice.Data.Entities.Users.User", null)
                        .WithOne()
                        .HasForeignKey("W4SRegistrationMicroservice.Data.Entities.Users.Student", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("W4SRegistrationMicroservice.Data.Entities.Universities.University", "University")
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