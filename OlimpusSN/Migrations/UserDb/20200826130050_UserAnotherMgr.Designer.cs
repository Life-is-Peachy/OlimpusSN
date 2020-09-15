﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OlimpusSN.Models;

namespace OlimpusSN.Migrations.UserDb
{
    [DbContext(typeof(UserDbContext))]
    [Migration("20200826130050_UserAnotherMgr")]
    partial class UserAnotherMgr
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OlimpusSN.Models.InfoCommon", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AboutMe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Birthplace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Country")
                        .HasColumnType("int");

                    b.Property<int>("Married")
                        .HasColumnType("int");

                    b.Property<string>("Occupation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Political")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Religious")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebSite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InfoCommon");
                });

            modelBuilder.Entity("OlimpusSN.Models.InfoEducation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PeriodOfEducation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhereEducated")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InfoEducation");
                });

            modelBuilder.Entity("OlimpusSN.Models.InfoEmployement", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PeriodOfEmployement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhereEmployemented")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InfoEmployement");
                });

            modelBuilder.Entity("OlimpusSN.Models.InfoHobbies", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FavBooks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FavGames")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FavMovies")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FavMusic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FavTV")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FavWriters")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hobbies")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherInterests")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InfoHobbies");
                });

            modelBuilder.Entity("OlimpusSN.Models.PersonSummary", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("InfoCommonId")
                        .HasColumnType("bigint");

                    b.Property<long>("InfoComonId")
                        .HasColumnType("bigint");

                    b.Property<long>("InfoEducationId")
                        .HasColumnType("bigint");

                    b.Property<long>("InfoEmployementId")
                        .HasColumnType("bigint");

                    b.Property<long>("InfoHobbiesId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("InfoCommonId");

                    b.HasIndex("InfoEducationId");

                    b.HasIndex("InfoEmployementId");

                    b.HasIndex("InfoHobbiesId");

                    b.ToTable("InfoSummary");
                });

            modelBuilder.Entity("OlimpusSN.Models.PersonSummary", b =>
                {
                    b.HasOne("OlimpusSN.Models.InfoCommon", "InfoCommon")
                        .WithMany()
                        .HasForeignKey("InfoCommonId");

                    b.HasOne("OlimpusSN.Models.InfoEducation", "InfoEducation")
                        .WithMany()
                        .HasForeignKey("InfoEducationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OlimpusSN.Models.InfoEmployement", "InfoEmployement")
                        .WithMany()
                        .HasForeignKey("InfoEmployementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OlimpusSN.Models.InfoHobbies", "InfoHobbies")
                        .WithMany()
                        .HasForeignKey("InfoHobbiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
