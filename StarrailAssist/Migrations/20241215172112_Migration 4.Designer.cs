﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StarrailAssist.Data;

#nullable disable

namespace StarrailAssist.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241215172112_Migration 4")]
    partial class Migration4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StarrailAssist.Models.Entities.Character", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LCEight")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LCFive")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LCFour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LCNine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LCOne")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LCSeven")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LCSix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LCTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LCThree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LCTwo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("StarrailAssist.Models.Entities.LightCone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LightCones");
                });
#pragma warning restore 612, 618
        }
    }
}
