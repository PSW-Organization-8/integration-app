// <auto-generated />
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

            modelBuilder.Entity("IntegrationClassLib.Pharmacy.Model.Notification", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ContentNotification")
                        .HasColumnType("text");

                    b.Property<string>("FileName")
                        .HasColumnType("text");

                    b.Property<bool>("Read")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Notification");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ContentNotification = "Ovde ce da bude tekst nekog izvestaja",
                            FileName = "MedicationSpecifiation.pdf",
                            Read = true,
                            Title = "Izvestaj"
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

                    b.Property<string>("EmailAddress")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<string>("Port")
                        .HasColumnType("text");

                    b.Property<bool>("Sftp")
                        .HasColumnType("boolean");

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
                            EmailAddress = "psworganisation8+Apoteka1@outlook.com",
                            Name = "Apoteka1",
                            Port = "18013",
                            Sftp = false,
                            Url = "http://localhost"
                        },
                        new
                        {
                            Id = 2L,
                            ApiKey = "fds15d4fs6",
                            ComunicateWithGrpc = true,
                            EmailAddress = "psworganisation8+Apoteka2@outlook.com",
                            Name = "Apoteka2",
                            Port = "4111",
                            Sftp = true,
                            Url = "localhost"
                        },
                        new
                        {
                            Id = 3L,
                            ApiKey = "fds15d4fs6",
                            ComunicateWithGrpc = true,
                            EmailAddress = "psworganisation8+Apoteka3@outlook.com",
                            Name = "Apoteka3",
                            Port = "18013",
                            Sftp = true,
                            Url = "http://localhost"
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

            modelBuilder.Entity("IntegrationClassLib.Tendering.Model.PharmacyOffer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("OfferIdInPharmacy")
                        .HasColumnType("bigint");

                    b.Property<long>("PharmacyId")
                        .HasColumnType("bigint");

                    b.Property<string>("PharmacyName")
                        .HasColumnType("text");

                    b.Property<long>("TenderId")
                        .HasColumnType("bigint");

                    b.Property<long>("TenderIdInHospital")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("TimePosted")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("PharmacyOffers");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            OfferIdInPharmacy = 1L,
                            PharmacyId = 1L,
                            PharmacyName = "Apoteka1",
                            TenderId = 1L,
                            TenderIdInHospital = 1L,
                            TimePosted = new DateTime(2022, 1, 18, 15, 7, 18, 901, DateTimeKind.Local).AddTicks(1651)
                        },
                        new
                        {
                            Id = 2L,
                            OfferIdInPharmacy = 2L,
                            PharmacyId = 2L,
                            PharmacyName = "Apoteka2",
                            TenderId = 1L,
                            TenderIdInHospital = 1L,
                            TimePosted = new DateTime(2022, 1, 18, 15, 7, 18, 901, DateTimeKind.Local).AddTicks(2200)
                        });
                });

            modelBuilder.Entity("IntegrationClassLib.Tendering.Model.PharmacyOfferComponent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("MedicationName")
                        .HasColumnType("text");

                    b.Property<long>("PharmacyOfferId")
                        .HasColumnType("bigint");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PharmacyOfferId");

                    b.ToTable("PharmacyOfferComponents");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            MedicationName = "brufen",
                            PharmacyOfferId = 1L,
                            Price = 120.0,
                            Quantity = 123L
                        },
                        new
                        {
                            Id = 2L,
                            MedicationName = "ventolin",
                            PharmacyOfferId = 1L,
                            Price = 222.0,
                            Quantity = 321L
                        },
                        new
                        {
                            Id = 3L,
                            MedicationName = "brufen",
                            PharmacyOfferId = 2L,
                            Price = 500.0,
                            Quantity = 455L
                        });
                });

            modelBuilder.Entity("IntegrationClassLib.Tendering.Model.Tender", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("HospitalName")
                        .HasColumnType("text");

                    b.Property<bool>("IsAceptedOffer")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<long>("WinnerOfferId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Tenders");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            HospitalName = "Bolnica1",
                            IsAceptedOffer = true,
                            Name = "Hitno",
                            WinnerOfferId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            HospitalName = "Bolnica1",
                            IsAceptedOffer = false,
                            Name = "Veoma hitno",
                            WinnerOfferId = 0L
                        });
                });

            modelBuilder.Entity("IntegrationClassLib.Tendering.Model.TenderMedication", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("MedicationName")
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<long>("TenderId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TenderId");

                    b.ToTable("TenderMedications");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            MedicationName = "brufen",
                            Quantity = 1,
                            TenderId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            MedicationName = "ventolin",
                            Quantity = 1,
                            TenderId = 1L
                        },
                        new
                        {
                            Id = 3L,
                            MedicationName = "brufen",
                            Quantity = 1,
                            TenderId = 2L
                        });
                });

            modelBuilder.Entity("IntegrationClassLib.Parthership.Model.News", b =>
                {
                    b.OwnsOne("IntegrationClassLib.Model.DateRange", "DateRange", b1 =>
                        {
                            b1.Property<long>("NewsId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<DateTime?>("End")
                                .HasColumnType("timestamp without time zone");

                            b1.Property<DateTime>("Start")
                                .HasColumnType("timestamp without time zone");

                            b1.HasKey("NewsId");

                            b1.ToTable("News");

                            b1.WithOwner()
                                .HasForeignKey("NewsId");
                        });

                    b.Navigation("DateRange");
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

            modelBuilder.Entity("IntegrationClassLib.Tendering.Model.PharmacyOfferComponent", b =>
                {
                    b.HasOne("IntegrationClassLib.Tendering.Model.PharmacyOffer", null)
                        .WithMany("Components")
                        .HasForeignKey("PharmacyOfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IntegrationClassLib.Tendering.Model.Tender", b =>
                {
                    b.OwnsOne("IntegrationClassLib.Model.DateRange", "DateRange", b1 =>
                        {
                            b1.Property<long>("TenderId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<DateTime?>("End")
                                .HasColumnType("timestamp without time zone");

                            b1.Property<DateTime>("Start")
                                .HasColumnType("timestamp without time zone");

                            b1.HasKey("TenderId");

                            b1.ToTable("Tenders");

                            b1.WithOwner()
                                .HasForeignKey("TenderId");

                            b1.HasData(
                                new
                                {
                                    TenderId = 1L,
                                    End = new DateTime(2022, 1, 21, 15, 7, 18, 899, DateTimeKind.Local).AddTicks(877),
                                    Start = new DateTime(2022, 1, 18, 15, 7, 18, 898, DateTimeKind.Local).AddTicks(8226)
                                },
                                new
                                {
                                    TenderId = 2L,
                                    End = new DateTime(2022, 1, 23, 15, 7, 18, 900, DateTimeKind.Local).AddTicks(4449),
                                    Start = new DateTime(2022, 1, 18, 15, 7, 18, 900, DateTimeKind.Local).AddTicks(4395)
                                });
                        });

                    b.Navigation("DateRange");
                });

            modelBuilder.Entity("IntegrationClassLib.Tendering.Model.TenderMedication", b =>
                {
                    b.HasOne("IntegrationClassLib.Tendering.Model.Tender", null)
                        .WithMany("TenderMedications")
                        .HasForeignKey("TenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IntegrationClassLib.Tendering.Model.PharmacyOffer", b =>
                {
                    b.Navigation("Components");
                });

            modelBuilder.Entity("IntegrationClassLib.Tendering.Model.Tender", b =>
                {
                    b.Navigation("TenderMedications");
                });
#pragma warning restore 612, 618
        }
    }
}
