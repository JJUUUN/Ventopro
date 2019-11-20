﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcMovie.Data;

namespace MvcMovie.Migrations
{
    [DbContext(typeof(MvcMovieContext))]
    [Migration("20191113105517_a9")]
    partial class a9
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MvcMovie.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Rating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("MvcMovie.Models.Product", b =>
                {
                    b.Property<string>("p_code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("p_amount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("p_brandname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("p_comprice")
                        .HasColumnType("int");

                    b.Property<int>("p_customerprice")
                        .HasColumnType("int");

                    b.Property<string>("p_location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("p_many")
                        .HasColumnType("int");

                    b.Property<int>("p_measure")
                        .HasColumnType("int");

                    b.Property<string>("p_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("p_code");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("MvcMovie.Models.Sell", b =>
                {
                    b.Property<string>("s_code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Productp_code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SellDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("p_code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("s_amount")
                        .HasColumnType("int");

                    b.Property<string>("s_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("s_code");

                    b.HasIndex("Productp_code");

                    b.ToTable("Sell");
                });

            modelBuilder.Entity("MvcMovie.Models.Sell", b =>
                {
                    b.HasOne("MvcMovie.Models.Product", "Product")
                        .WithMany("Sell")
                        .HasForeignKey("Productp_code");
                });
#pragma warning restore 612, 618
        }
    }
}
