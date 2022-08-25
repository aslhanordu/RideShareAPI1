﻿// <auto-generated />
using System;
using AdessoRideShareAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdessoRideShareAPI.Migrations
{
    [DbContext(typeof(RideShareDbContext))]
    [Migration("20220825163405_rideshare")]
    partial class rideshare
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AdessoRideShareAPI.Model.TravelModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime?>("date")
                        .HasColumnType("datetime2");

                    b.Property<int>("emptyNumberSeat")
                        .HasColumnType("int");

                    b.Property<string>("explaining")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("from")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<int>("numberSeat")
                        .HasColumnType("int");

                    b.Property<string>("to")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("travel");
                });
#pragma warning restore 612, 618
        }
    }
}
