﻿// <auto-generated />
using System;
using IntegrationClassLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IntegrationAPI.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("IntegrationClassLib.Parthership.Model.News", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DurationEnd")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DurationStart")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("IdFromPharmacy")
                        .HasColumnType("bigint");

                    b.Property<bool>("Posted")
                        .HasColumnType("boolean");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("News");
                });

            modelBuilder.Entity("IntegrationClassLib.Parthership.Model.Objection", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("PharmacyName")
                        .HasColumnType("text");

                    b.Property<string>("TextObjection")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Objection");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            PharmacyName = "Apoteka1",
                            TextObjection = "Lose usluge"
                        });
                });

            modelBuilder.Entity("IntegrationClassLib.Parthership.Model.Response", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ObjectionId")
                        .HasColumnType("text");

                    b.Property<string>("TextResponse")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Response");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ObjectionId = "1",
                            TextResponse = "Nije tacno"
                        });
                });

            modelBuilder.Entity("IntegrationClassLib.Pharmacy.Model.MedicationConsumption", b =>
                {
                    b.Property<long>("MedicineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("MedicineName")
                        .HasColumnType("text");

                    b.Property<double>("Quantity")
                        .HasColumnType("double precision");

                    b.HasKey("MedicineID");

                    b.ToTable("MedicationConsumption");

                    b.HasData(
                        new
                        {
                            MedicineID = 1L,
                            DateTime = new DateTime(2021, 11, 11, 1, 0, 0, 0, DateTimeKind.Local),
                            MedicineName = "Brufen",
                            Quantity = 32.0
                        },
                        new
                        {
                            MedicineID = 2L,
                            DateTime = new DateTime(2021, 11, 11, 1, 0, 0, 0, DateTimeKind.Local),
                            MedicineName = "Vitamin C",
                            Quantity = 16.0
                        },
                        new
                        {
                            MedicineID = 3L,
                            DateTime = new DateTime(2021, 11, 11, 1, 0, 0, 0, DateTimeKind.Local),
                            MedicineName = "Brufen",
                            Quantity = 56.0
                        });
                });

            modelBuilder.Entity("IntegrationClassLib.Pharmacy.Model.Pharmacy", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ApiKey")
                        .HasColumnType("text");

                    b.Property<string>("Base64Image")
                        .HasColumnType("text");

                    b.Property<bool>("ComunicateWithGrpc")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<string>("Port")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Pharmacies");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ApiKey = "fds15d4fs6",
                            ComunicateWithGrpc = false,
                            Name = "Apoteka1",
                            Port = "18013",
                            Url = "http://localhost"
                        },
                        new
                        {
                            Id = 2L,
                            ApiKey = "fds15d4fs6",
                            ComunicateWithGrpc = true,
                            Name = "Apoteka2",
                            Port = "4111",
                            Url = "localhost"
                        });
                });

            modelBuilder.Entity("IntegrationClassLib.SharedModel.Building", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("IntegrationClassLib.SharedModel.Equipment", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<long?>("RoomID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("RoomID");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("IntegrationClassLib.SharedModel.Floor", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("BuildingID")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("BuildingID");

                    b.ToTable("Floors");
                });

            modelBuilder.Entity("IntegrationClassLib.SharedModel.MoveEquipment", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("destinationRoomID")
                        .HasColumnType("bigint");

                    b.Property<string>("duration")
                        .HasColumnType("text");

                    b.Property<long?>("equipmentID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("relocationTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ID");

                    b.HasIndex("destinationRoomID");

                    b.HasIndex("equipmentID");

                    b.ToTable("MoveEquipments");
                });

            modelBuilder.Entity("IntegrationClassLib.SharedModel.Room", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("FloorID")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("FloorID");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("IntegrationClassLib.SharedModel.Equipment", b =>
                {
                    b.HasOne("IntegrationClassLib.SharedModel.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomID");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("IntegrationClassLib.SharedModel.Floor", b =>
                {
                    b.HasOne("IntegrationClassLib.SharedModel.Building", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingID");

                    b.Navigation("Building");
                });

            modelBuilder.Entity("IntegrationClassLib.SharedModel.MoveEquipment", b =>
                {
                    b.HasOne("IntegrationClassLib.SharedModel.Room", "destinationRoom")
                        .WithMany()
                        .HasForeignKey("destinationRoomID");

                    b.HasOne("IntegrationClassLib.SharedModel.Equipment", "equipment")
                        .WithMany()
                        .HasForeignKey("equipmentID");

                    b.Navigation("destinationRoom");

                    b.Navigation("equipment");
                });

            modelBuilder.Entity("IntegrationClassLib.SharedModel.Room", b =>
                {
                    b.HasOne("IntegrationClassLib.SharedModel.Floor", "Floor")
                        .WithMany()
                        .HasForeignKey("FloorID");

                    b.Navigation("Floor");
                });
#pragma warning restore 612, 618
        }
    }
}
