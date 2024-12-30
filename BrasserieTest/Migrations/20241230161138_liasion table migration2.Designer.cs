﻿// <auto-generated />
using System;
using BrasserieTest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BrasserieTest.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241230161138_liasion table migration2")]
    partial class liasiontablemigration2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BrasserieTest.Models.Entities.Beer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("alcohol_content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("breweryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("breweryId");

                    b.ToTable("Beers");
                });

            modelBuilder.Entity("BrasserieTest.Models.Entities.Brewery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BreweryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brewerys");
                });

            modelBuilder.Entity("BrasserieTest.Models.Entities.Wholesaler", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Wholesalers");
                });

            modelBuilder.Entity("BrasserieTest.Models.Entities.WholesalerBeer", b =>
                {
                    b.Property<Guid>("IdBeer")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdWholesaler")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("IdBeer", "IdWholesaler");

                    b.HasIndex("IdWholesaler");

                    b.ToTable("WholesalersBeers");
                });

            modelBuilder.Entity("BrasserieTest.Models.Entities.Beer", b =>
                {
                    b.HasOne("BrasserieTest.Models.Entities.Brewery", "brewery")
                        .WithMany("beers")
                        .HasForeignKey("breweryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("brewery");
                });

            modelBuilder.Entity("BrasserieTest.Models.Entities.WholesalerBeer", b =>
                {
                    b.HasOne("BrasserieTest.Models.Entities.Beer", "Beer")
                        .WithMany("WholesalerBeers")
                        .HasForeignKey("IdBeer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BrasserieTest.Models.Entities.Wholesaler", "Wholesaler")
                        .WithMany("WholesalerBeers")
                        .HasForeignKey("IdWholesaler")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Beer");

                    b.Navigation("Wholesaler");
                });

            modelBuilder.Entity("BrasserieTest.Models.Entities.Beer", b =>
                {
                    b.Navigation("WholesalerBeers");
                });

            modelBuilder.Entity("BrasserieTest.Models.Entities.Brewery", b =>
                {
                    b.Navigation("beers");
                });

            modelBuilder.Entity("BrasserieTest.Models.Entities.Wholesaler", b =>
                {
                    b.Navigation("WholesalerBeers");
                });
#pragma warning restore 612, 618
        }
    }
}
