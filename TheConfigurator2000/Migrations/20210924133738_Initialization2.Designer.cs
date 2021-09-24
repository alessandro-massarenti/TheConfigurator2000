﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheConfigurator2000.Context;

namespace TheConfigurator2000.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210924133738_Initialization2")]
    partial class Initialization2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProductQuotation", b =>
                {
                    b.Property<Guid>("ProductsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("QuotationsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("createdDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("sysdatetimeoffset()");

                    b.HasKey("ProductsId", "QuotationsId");

                    b.HasIndex("QuotationsId");

                    b.ToTable("ProductQuotation");
                });

            modelBuilder.Entity("TheConfigurator2000.Classes.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTimeOffset>("createdDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("sysdatetimeoffset()");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("TheConfigurator2000.Classes.ProductQuotation", b =>
                {
                    b.Property<DateTimeOffset>("createdDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("sysdatetimeoffset()");

                    b.ToTable("ProductQuotations");
                });

            modelBuilder.Entity("TheConfigurator2000.Classes.Quotation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("createdDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("sysdatetimeoffset()");

                    b.HasKey("Id");

                    b.ToTable("Quotations");
                });

            modelBuilder.Entity("ProductQuotation", b =>
                {
                    b.HasOne("TheConfigurator2000.Classes.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheConfigurator2000.Classes.Quotation", null)
                        .WithMany()
                        .HasForeignKey("QuotationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
