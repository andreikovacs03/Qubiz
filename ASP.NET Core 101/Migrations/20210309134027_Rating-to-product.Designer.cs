﻿// <auto-generated />
using ASP.NET_Core_101.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ASP.NET_Core_101.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20210309134027_Rating-to-product")]
    partial class Ratingtoproduct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ASP.NET_Core_101.Models.Product", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Maker")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ASP.NET_Core_101.Models.Rating", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProductId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("ASP.NET_Core_101.Models.Rating", b =>
                {
                    b.HasOne("ASP.NET_Core_101.Models.Product", null)
                        .WithMany("Star")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("ASP.NET_Core_101.Models.Product", b =>
                {
                    b.Navigation("Star");
                });
#pragma warning restore 612, 618
        }
    }
}
