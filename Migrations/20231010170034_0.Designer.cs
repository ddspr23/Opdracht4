﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Opdracht4.core;

#nullable disable

namespace Opdracht4.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20231010170034_0")]
    partial class _0
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Opdracht4.core.Attractie", b =>
                {
                    b.Property<int>("AttractieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AttractieID");

                    b.ToTable("attractie", (string)null);
                });

            modelBuilder.Entity("Opdracht4.core.Gast", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AttractieID")
                        .HasColumnType("int");

                    b.Property<int?>("BegeleiderID")
                        .HasColumnType("int");

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<DateTime>("EersteBezoek")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("GeboorteDatum")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.HasIndex("AttractieID");

                    b.HasIndex("BegeleiderID");

                    b.ToTable("gast", (string)null);
                });

            modelBuilder.Entity("Opdracht4.core.Medewerker", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("medewerker", (string)null);
                });

            modelBuilder.Entity("Opdracht4.core.Onderhoud", b =>
                {
                    b.Property<int>("OnderhoudID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MedewerkerID")
                        .HasColumnType("int");

                    b.Property<string>("Probleem")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("OnderhoudID");

                    b.HasIndex("MedewerkerID");

                    b.ToTable("onderhoud", (string)null);
                });

            modelBuilder.Entity("Opdracht4.core.Reservering", b =>
                {
                    b.Property<int>("ReserveringID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AttractieID")
                        .HasColumnType("int");

                    b.Property<int>("GastID")
                        .HasColumnType("int");

                    b.HasKey("ReserveringID");

                    b.HasIndex("AttractieID");

                    b.HasIndex("GastID");

                    b.ToTable("reservering", (string)null);
                });

            modelBuilder.Entity("Opdracht4.core.Gast", b =>
                {
                    b.HasOne("Opdracht4.core.Attractie", "Attractie")
                        .WithMany()
                        .HasForeignKey("AttractieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Opdracht4.core.Gast", "Begeleider")
                        .WithMany()
                        .HasForeignKey("BegeleiderID");

                    b.Navigation("Attractie");

                    b.Navigation("Begeleider");
                });

            modelBuilder.Entity("Opdracht4.core.Onderhoud", b =>
                {
                    b.HasOne("Opdracht4.core.Medewerker", "coordinator")
                        .WithMany()
                        .HasForeignKey("MedewerkerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Opdracht4.core.DateTimeBereik", "_dtb", b1 =>
                        {
                            b1.Property<int>("OnderhoudID")
                                .HasColumnType("int");

                            b1.Property<DateTime>("Begin")
                                .HasColumnType("datetime(6)");

                            b1.Property<DateTime?>("End")
                                .HasColumnType("datetime(6)");

                            b1.HasKey("OnderhoudID");

                            b1.ToTable("onderhoud");

                            b1.WithOwner()
                                .HasForeignKey("OnderhoudID");
                        });

                    b.Navigation("_dtb")
                        .IsRequired();

                    b.Navigation("coordinator");
                });

            modelBuilder.Entity("Opdracht4.core.Reservering", b =>
                {
                    b.HasOne("Opdracht4.core.Attractie", "_attr")
                        .WithMany()
                        .HasForeignKey("AttractieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Opdracht4.core.Gast", "_gast")
                        .WithMany()
                        .HasForeignKey("GastID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Opdracht4.core.DateTimeBereik", "_dtb", b1 =>
                        {
                            b1.Property<int>("ReserveringID")
                                .HasColumnType("int");

                            b1.Property<DateTime>("Begin")
                                .HasColumnType("datetime(6)");

                            b1.Property<DateTime?>("End")
                                .HasColumnType("datetime(6)");

                            b1.HasKey("ReserveringID");

                            b1.ToTable("reservering");

                            b1.WithOwner()
                                .HasForeignKey("ReserveringID");
                        });

                    b.Navigation("_attr");

                    b.Navigation("_dtb")
                        .IsRequired();

                    b.Navigation("_gast");
                });
#pragma warning restore 612, 618
        }
    }
}
