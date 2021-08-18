﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using project.pole.Data;

namespace project.pole.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("project.pole.Models.Estimate", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_created");

                    b.Property<long>("ObjectId")
                        .HasColumnType("bigint")
                        .HasColumnName("object_id");

                    b.Property<string>("Path")
                        .HasColumnType("longtext")
                        .HasColumnName("path");

                    b.HasKey("Id");

                    b.HasIndex("ObjectId");

                    b.ToTable("estimate");
                });

            modelBuilder.Entity("project.pole.Models.Object", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Building")
                        .HasColumnType("longtext")
                        .HasColumnName("building");

                    b.Property<string>("City")
                        .HasColumnType("longtext")
                        .HasColumnName("city");

                    b.Property<string>("District")
                        .HasColumnType("longtext")
                        .HasColumnName("district");

                    b.Property<string>("Name")
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("Region")
                        .HasColumnType("longtext")
                        .HasColumnName("region");

                    b.Property<string>("Street")
                        .HasColumnType("longtext")
                        .HasColumnName("street");

                    b.HasKey("Id");

                    b.ToTable("object");
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

            modelBuilder.Entity("project.pole.Models.Estimate", b =>
                {
                    b.HasOne("project.pole.Models.Object", "Object")
                        .WithMany("Estimaet")
                        .HasForeignKey("ObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Object");
                });

            modelBuilder.Entity("project.pole.Models.Object", b =>
                {
                    b.Navigation("Estimaet");
                });
#pragma warning restore 612, 618
        }
    }
}
