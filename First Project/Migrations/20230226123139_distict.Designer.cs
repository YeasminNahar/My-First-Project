﻿// <auto-generated />
using System;
using First_Project.Datacontext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace First_Project.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230226123139_distict")]
    partial class distict
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("First_Project.Data.ClassInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameBn");

                    b.Property<string>("NameEn");

                    b.Property<DateTime?>("createdAt");

                    b.Property<string>("createdBy")
                        .HasMaxLength(250);

                    b.Property<int?>("isDelete");

                    b.Property<DateTime?>("updatedAt");

                    b.Property<string>("updatedBy")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("classInfos");
                });

            modelBuilder.Entity("First_Project.Data.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameBN");

                    b.Property<string>("NameEN");

                    b.Property<DateTime?>("createdAt");

                    b.Property<string>("createdBy")
                        .HasMaxLength(250);

                    b.Property<int?>("isDelete");

                    b.Property<DateTime?>("updatedAt");

                    b.Property<string>("updatedBy")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("genders");
                });

            modelBuilder.Entity("First_Project.Data.Master.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("countryCode")
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<string>("countryName")
                        .HasColumnType("NVARCHAR(120)");

                    b.Property<string>("countryNameBn")
                        .HasColumnType("NVARCHAR(120)");

                    b.Property<DateTime?>("createdAt");

                    b.Property<string>("createdBy")
                        .HasMaxLength(250);

                    b.Property<string>("isActive")
                        .HasColumnType("NVARCHAR(10)");

                    b.Property<int?>("isDelete");

                    b.Property<string>("latitude")
                        .HasColumnType("NVARCHAR(120)");

                    b.Property<string>("longitude")
                        .HasColumnType("NVARCHAR(120)");

                    b.Property<string>("shortName")
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<DateTime?>("updatedAt");

                    b.Property<string>("updatedBy")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("countries");
                });

            modelBuilder.Entity("First_Project.Data.Master.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("createdAt");

                    b.Property<string>("createdBy")
                        .HasMaxLength(250);

                    b.Property<string>("districtCode")
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<string>("districtName")
                        .HasColumnType("NVARCHAR(120)");

                    b.Property<string>("districtNameBn")
                        .HasColumnType("NVARCHAR(120)");

                    b.Property<int>("divisionId");

                    b.Property<string>("isActive")
                        .HasColumnType("NVARCHAR(10)");

                    b.Property<int?>("isDelete");

                    b.Property<string>("latitude")
                        .HasColumnType("NVARCHAR(120)");

                    b.Property<string>("longitude")
                        .HasColumnType("NVARCHAR(120)");

                    b.Property<string>("shortName")
                        .HasColumnType("NVARCHAR(120)");

                    b.Property<DateTime?>("updatedAt");

                    b.Property<string>("updatedBy")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("divisionId");

                    b.ToTable("districts");
                });

            modelBuilder.Entity("First_Project.Data.Master.Division", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("countryId");

                    b.Property<DateTime?>("createdAt");

                    b.Property<string>("createdBy")
                        .HasMaxLength(250);

                    b.Property<string>("divisionCode")
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<string>("divisionName")
                        .HasColumnType("NVARCHAR(120)");

                    b.Property<string>("divisionNameBn");

                    b.Property<string>("isActive")
                        .HasColumnType("NVARCHAR(10)");

                    b.Property<int?>("isDelete");

                    b.Property<string>("latitude")
                        .HasColumnType("NVARCHAR(120)");

                    b.Property<string>("longitude")
                        .HasColumnType("NVARCHAR(120)");

                    b.Property<string>("shortName")
                        .HasColumnType("NVARCHAR(120)");

                    b.Property<DateTime?>("updatedAt");

                    b.Property<string>("updatedBy")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("countryId");

                    b.ToTable("divisions");
                });

            modelBuilder.Entity("First_Project.Data.Master.Occupation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("createdAt");

                    b.Property<string>("createdBy")
                        .HasMaxLength(250);

                    b.Property<int?>("isDelete");

                    b.Property<string>("occupationName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(180)");

                    b.Property<string>("occupationShortName")
                        .HasColumnType("NVARCHAR(120)");

                    b.Property<int?>("shortOrder");

                    b.Property<DateTime?>("updatedAt");

                    b.Property<string>("updatedBy")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("occupations");
                });

            modelBuilder.Entity("First_Project.Data.Master.Religion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("createdAt");

                    b.Property<string>("createdBy")
                        .HasMaxLength(250);

                    b.Property<int?>("isDelete");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(150)");

                    b.Property<string>("shortName")
                        .HasColumnType("NVARCHAR(120)");

                    b.Property<DateTime?>("updatedAt");

                    b.Property<string>("updatedBy")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("religions");
                });

            modelBuilder.Entity("First_Project.Data.Master.Thana", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("createdAt");

                    b.Property<string>("createdBy")
                        .HasMaxLength(250);

                    b.Property<int?>("districtId");

                    b.Property<string>("isActive")
                        .HasColumnType("NVARCHAR(10)");

                    b.Property<int?>("isDelete");

                    b.Property<string>("latitude")
                        .HasColumnType("NVARCHAR(120)");

                    b.Property<string>("longitude")
                        .HasColumnType("NVARCHAR(120)");

                    b.Property<string>("shortName")
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("thanaCode")
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<string>("thanaName")
                        .HasColumnType("NVARCHAR(120)");

                    b.Property<string>("thanaNameBn")
                        .HasColumnType("NVARCHAR(120)");

                    b.Property<DateTime?>("updatedAt");

                    b.Property<string>("updatedBy")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("districtId");

                    b.ToTable("thanas");
                });

            modelBuilder.Entity("First_Project.Data.Resultsheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Grade");

                    b.Property<string>("Subject");

                    b.Property<int>("TotalMarks");

                    b.Property<DateTime?>("createdAt");

                    b.Property<string>("createdBy")
                        .HasMaxLength(250);

                    b.Property<int?>("isDelete");

                    b.Property<int?>("studentInfoId");

                    b.Property<DateTime?>("updatedAt");

                    b.Property<string>("updatedBy")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("studentInfoId");

                    b.ToTable("resultsheets");
                });

            modelBuilder.Entity("First_Project.Data.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameBN");

                    b.Property<string>("NameEN");

                    b.Property<DateTime?>("createdAt");

                    b.Property<string>("createdBy")
                        .HasMaxLength(250);

                    b.Property<int?>("isDelete");

                    b.Property<DateTime?>("updatedAt");

                    b.Property<string>("updatedBy")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("sections");
                });

            modelBuilder.Entity("First_Project.Data.StudentInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Name");

                    b.Property<string>("Roll");

                    b.Property<int?>("classInfoId");

                    b.Property<DateTime?>("createdAt");

                    b.Property<string>("createdBy")
                        .HasMaxLength(250);

                    b.Property<int?>("genderId");

                    b.Property<int?>("isActive");

                    b.Property<int?>("isDelete");

                    b.Property<int?>("sectionId");

                    b.Property<DateTime?>("updatedAt");

                    b.Property<string>("updatedBy")
                        .HasMaxLength(250);

                    b.Property<string>("url");

                    b.HasKey("Id");

                    b.HasIndex("classInfoId");

                    b.HasIndex("genderId");

                    b.HasIndex("sectionId");

                    b.ToTable("studentInfos");
                });

            modelBuilder.Entity("First_Project.Data.Master.District", b =>
                {
                    b.HasOne("First_Project.Data.Master.Division", "division")
                        .WithMany()
                        .HasForeignKey("divisionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("First_Project.Data.Master.Division", b =>
                {
                    b.HasOne("First_Project.Data.Master.Country", "country")
                        .WithMany()
                        .HasForeignKey("countryId");
                });

            modelBuilder.Entity("First_Project.Data.Master.Thana", b =>
                {
                    b.HasOne("First_Project.Data.Master.District", "district")
                        .WithMany()
                        .HasForeignKey("districtId");
                });

            modelBuilder.Entity("First_Project.Data.Resultsheet", b =>
                {
                    b.HasOne("First_Project.Data.StudentInfo", "studentInfo")
                        .WithMany()
                        .HasForeignKey("studentInfoId");
                });

            modelBuilder.Entity("First_Project.Data.StudentInfo", b =>
                {
                    b.HasOne("First_Project.Data.ClassInfo", "classInfo")
                        .WithMany()
                        .HasForeignKey("classInfoId");

                    b.HasOne("First_Project.Data.Gender", "gender")
                        .WithMany()
                        .HasForeignKey("genderId");

                    b.HasOne("First_Project.Data.Section", "section")
                        .WithMany()
                        .HasForeignKey("sectionId");
                });
#pragma warning restore 612, 618
        }
    }
}