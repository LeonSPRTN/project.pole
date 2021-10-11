﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using project.pole.Data;

namespace project.pole.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20211011191604_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("project.pole.Models.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Area")
                        .HasColumnType("longtext")
                        .HasColumnName("area");

                    b.Property<string>("City")
                        .HasColumnType("longtext")
                        .HasColumnName("city");

                    b.Property<long?>("EstimaetId")
                        .HasColumnType("bigint");

                    b.Property<string>("Flat")
                        .HasColumnType("longtext")
                        .HasColumnName("Flat");

                    b.Property<string>("House")
                        .HasColumnType("longtext")
                        .HasColumnName("house");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("Region")
                        .HasColumnType("longtext")
                        .HasColumnName("region");

                    b.Property<string>("Settlement")
                        .HasColumnType("longtext")
                        .HasColumnName("settlement");

                    b.Property<string>("Street")
                        .HasColumnType("longtext")
                        .HasColumnName("street");

                    b.HasKey("Id");

                    b.HasIndex("EstimaetId");

                    b.ToTable("customer");
                });

            modelBuilder.Entity("project.pole.Models.Estimate", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_created");

                    b.Property<string>("Path")
                        .HasColumnType("longtext")
                        .HasColumnName("path");

                    b.HasKey("Id");

                    b.ToTable("estimate");
                });

            modelBuilder.Entity("project.pole.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Login")
                        .HasColumnType("longtext")
                        .HasColumnName("login");

                    b.Property<string>("Password")
                        .HasColumnType("longtext")
                        .HasColumnName("password");

                    b.HasKey("Id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("project.pole.Models.Customer", b =>
                {
                    b.HasOne("project.pole.Models.Estimate", "Estimaet")
                        .WithMany()
                        .HasForeignKey("EstimaetId");

                    b.Navigation("Estimaet");
                });
#pragma warning restore 612, 618
        }
    }
}