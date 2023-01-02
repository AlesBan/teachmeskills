﻿// <auto-generated />
using System;
using DZ_12_17_TSK03;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DZ_12_17_TSK03.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230102135258_createdb")]
    partial class createdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("DZ_12_17_TSK03.Models.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("caa30ba3-db91-492d-8d33-8bf4a984d854"),
                            Name = "AmogusDepartment"
                        },
                        new
                        {
                            Id = new Guid("85ccd314-2969-4bcd-9ffd-fc973c04c1d8"),
                            Name = "ImposterDepartment"
                        },
                        new
                        {
                            Id = new Guid("b5828a73-67a6-4808-ab64-85a85a5d4e76"),
                            Name = "NormalDepartment"
                        });
                });

            modelBuilder.Entity("DZ_12_17_TSK03.Models.SupportRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RequestDescription")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("RequestTheme")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid>("SpecialistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("SpecialistId");

                    b.ToTable("SupportRequests");
                });

            modelBuilder.Entity("DZ_12_17_TSK03.Models.SupportSpecialist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("SupportSpecialists");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f445e6de-8cec-43a5-8b10-f0b4b13d1285"),
                            DepartmentId = new Guid("1053db82-bb9f-4440-bb35-6a5d8869c338"),
                            Name = "Ales"
                        },
                        new
                        {
                            Id = new Guid("77822d0e-fcb3-4d29-90da-7fc959094014"),
                            DepartmentId = new Guid("9b1101f3-94e9-41ad-9ea4-8915295e9500"),
                            Name = "Martin"
                        },
                        new
                        {
                            Id = new Guid("0eb57f05-17c2-4424-a707-3a1e7bef9404"),
                            DepartmentId = new Guid("1dc56bd1-e92e-4349-ac4e-1dd31b45b002"),
                            Name = "Arseniy"
                        },
                        new
                        {
                            Id = new Guid("f3cfb186-2a14-42fe-a0bd-ca896fe1a237"),
                            DepartmentId = new Guid("52949349-72d9-4988-9a7f-ced44271b693"),
                            Name = "Amogus"
                        },
                        new
                        {
                            Id = new Guid("98081bbb-0dc2-447c-8a6d-6a6db4fd3448"),
                            DepartmentId = new Guid("62640f86-fcab-4c23-83a8-98fe5bb0355a"),
                            Name = "Abobus"
                        },
                        new
                        {
                            Id = new Guid("186f6ada-621e-4f8f-91b7-a63402dec208"),
                            DepartmentId = new Guid("f8185ab7-1342-4fd7-816a-0a31c75ad122"),
                            Name = "Autobus"
                        },
                        new
                        {
                            Id = new Guid("388f177f-816c-46a6-a180-f3f2f00fa270"),
                            DepartmentId = new Guid("217211c3-1e29-43cc-a99c-844abf379c07"),
                            Name = "Ivan"
                        },
                        new
                        {
                            Id = new Guid("e9e8c7e7-0ac8-409d-bff9-edcf482f06a2"),
                            DepartmentId = new Guid("5583d899-16ef-4036-b326-87d75b1f87f1"),
                            Name = "Dima"
                        },
                        new
                        {
                            Id = new Guid("ddb16822-26a1-4d25-b47c-5e18d75350eb"),
                            DepartmentId = new Guid("1b3616d0-2498-4cf2-a028-06272471f732"),
                            Name = "OLeg"
                        });
                });

            modelBuilder.Entity("DZ_12_17_TSK03.Models.SupportRequest", b =>
                {
                    b.HasOne("DZ_12_17_TSK03.Models.SupportSpecialist", "Specialist")
                        .WithMany("SupportRequests")
                        .HasForeignKey("SpecialistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Specialist");
                });

            modelBuilder.Entity("DZ_12_17_TSK03.Models.SupportSpecialist", b =>
                {
                    b.HasOne("DZ_12_17_TSK03.Models.Department", "Department")
                        .WithMany("SupportSpecialists")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("DZ_12_17_TSK03.Models.Department", b =>
                {
                    b.Navigation("SupportSpecialists");
                });

            modelBuilder.Entity("DZ_12_17_TSK03.Models.SupportSpecialist", b =>
                {
                    b.Navigation("SupportRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
