﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

namespace Repository.Migrations
{
    [DbContext(typeof(AplicationContext))]
    [Migration("20200301195002_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Car", b =>
                {
                    b.Property<Guid>("CarId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand");

                    b.Property<Guid>("ChassisIdF");

                    b.Property<Guid>("EngineIdF");

                    b.HasKey("CarId");

                    b.HasIndex("ChassisIdF");

                    b.HasIndex("EngineIdF");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Domain.CarUser", b =>
                {
                    b.Property<Guid>("CarId");

                    b.Property<Guid>("UserId");

                    b.HasKey("CarId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("CarUser");
                });

            modelBuilder.Entity("Domain.Chassis", b =>
                {
                    b.Property<Guid>("ChassisId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CodeNumber");

                    b.Property<string>("Description");

                    b.HasKey("ChassisId");

                    b.ToTable("Chassiss");
                });

            modelBuilder.Entity("Domain.Engine", b =>
                {
                    b.Property<Guid>("EngineId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CylindersNumber");

                    b.Property<string>("Description");

                    b.HasKey("EngineId");

                    b.ToTable("Engines");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Car", b =>
                {
                    b.HasOne("Domain.Chassis")
                        .WithMany("Cars")
                        .HasForeignKey("ChassisIdF")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Engine")
                        .WithMany("Cars")
                        .HasForeignKey("EngineIdF")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.CarUser", b =>
                {
                    b.HasOne("Domain.Car", "Car")
                        .WithMany("CarUsers")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.User", "User")
                        .WithMany("CarsUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
