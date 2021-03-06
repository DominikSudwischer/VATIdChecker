﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VATIdChecker.Data;

namespace VATIdChecker.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190419153410_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065");

            modelBuilder.Entity("VATIdChecker.Models.CompanyModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("VatIdentNo")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("ViesAddress")
                        .HasMaxLength(50);

                    b.Property<string>("ViesName")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });
#pragma warning restore 612, 618
        }
    }
}
