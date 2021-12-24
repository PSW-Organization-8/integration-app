using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IntegrationAPI.Migrations
{
    public partial class tendering : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MedicationConsumption",
                columns: table => new
                {
                    MedicineID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MedicineName = table.Column<string>(type: "text", nullable: true),
                    DateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Quantity = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationConsumption", x => x.MedicineID);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdFromPharmacy = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Text = table.Column<string>(type: "text", nullable: true),
                    DateRange_Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DateRange_End = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Posted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Read = table.Column<bool>(type: "boolean", nullable: false),
                    ContentNotification = table.Column<string>(type: "text", nullable: true),
                    FileName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Objection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PharmacyName = table.Column<string>(type: "text", nullable: true),
                    TextObjection = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ApiKey = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    Port = table.Column<string>(type: "text", nullable: true),
                    ComunicateWithGrpc = table.Column<bool>(type: "boolean", nullable: false),
                    Sftp = table.Column<bool>(type: "boolean", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Base64Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyOffers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OfferIdInPharmacy = table.Column<long>(type: "bigint", nullable: false),
                    PharmacyId = table.Column<long>(type: "bigint", nullable: false),
                    TenderId = table.Column<long>(type: "bigint", nullable: false),
                    TenderIdInHospital = table.Column<long>(type: "bigint", nullable: false),
                    PharmacyName = table.Column<string>(type: "text", nullable: true),
                    TimePosted = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyOffers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Response",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObjectionId = table.Column<string>(type: "text", nullable: true),
                    TextResponse = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Response", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    HospitalName = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsAceptedOffer = table.Column<bool>(type: "boolean", nullable: false),
                    WinnerOfferId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Floors",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    BuildingID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Floors_Buildings_BuildingID",
                        column: x => x.BuildingID,
                        principalTable: "Buildings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyOfferComponents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MedicationName = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    PharmacyOfferId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyOfferComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PharmacyOfferComponents_PharmacyOffers_PharmacyOfferId",
                        column: x => x.PharmacyOfferId,
                        principalTable: "PharmacyOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenderMedications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MedicationName = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    TenderId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderMedications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenderMedications_Tenders_TenderId",
                        column: x => x.TenderId,
                        principalTable: "Tenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    FloorID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rooms_Floors_FloorID",
                        column: x => x.FloorID,
                        principalTable: "Floors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    RoomID = table.Column<long>(type: "bigint", nullable: true),
                    Amount = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Equipments_Rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MoveEquipments",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    equipmentID = table.Column<long>(type: "bigint", nullable: true),
                    destinationRoomID = table.Column<long>(type: "bigint", nullable: true),
                    relocationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    duration = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoveEquipments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MoveEquipments_Equipments_equipmentID",
                        column: x => x.equipmentID,
                        principalTable: "Equipments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MoveEquipments_Rooms_destinationRoomID",
                        column: x => x.destinationRoomID,
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "MedicationConsumption",
                columns: new[] { "MedicineID", "DateTime", "MedicineName", "Quantity" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 11, 11, 1, 0, 0, 0, DateTimeKind.Local), "Brufen", 32.0 },
                    { 2L, new DateTime(2021, 11, 11, 1, 0, 0, 0, DateTimeKind.Local), "Vitamin C", 16.0 },
                    { 3L, new DateTime(2021, 11, 11, 1, 0, 0, 0, DateTimeKind.Local), "Brufen", 56.0 }
                });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "Id", "ContentNotification", "FileName", "Read", "Title" },
                values: new object[] { 1L, "Ovde ce da bude tekst nekog izvestaja", "MedicationSpecifiation.pdf", true, "Izvestaj" });

            migrationBuilder.InsertData(
                table: "Objection",
                columns: new[] { "Id", "PharmacyName", "TextObjection" },
                values: new object[] { 1L, "Apoteka1", "Lose usluge" });

            migrationBuilder.InsertData(
                table: "Pharmacies",
                columns: new[] { "Id", "ApiKey", "Base64Image", "ComunicateWithGrpc", "Name", "Notes", "Port", "Sftp", "Url" },
                values: new object[,]
                {
                    { 1L, "fds15d4fs6", null, false, "Apoteka1", null, "18013", false, "http://localhost" },
                    { 2L, "fds15d4fs6", null, true, "Apoteka2", null, "4111", true, "localhost" },
                    { 3L, "fds15d4fs6", null, true, "Apoteka3", null, "18013", true, "http://localhost" }
                });

            migrationBuilder.InsertData(
                table: "Response",
                columns: new[] { "Id", "ObjectionId", "TextResponse" },
                values: new object[] { 1L, "1", "Nije tacno" });

            migrationBuilder.InsertData(
                table: "Tenders",
                columns: new[] { "Id", "EndDate", "HospitalName", "IsAceptedOffer", "Name", "StartDate", "WinnerOfferId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 12, 28, 10, 41, 40, 313, DateTimeKind.Local).AddTicks(4265), "Bolnica1", false, "Hitno", new DateTime(2021, 12, 25, 10, 41, 40, 313, DateTimeKind.Local).AddTicks(2073), 0L },
                    { 2L, new DateTime(2021, 12, 30, 10, 41, 40, 313, DateTimeKind.Local).AddTicks(5655), "Bolnica1", false, "Veoma hitno", new DateTime(2021, 12, 25, 10, 41, 40, 313, DateTimeKind.Local).AddTicks(5633), 0L }
                });

            migrationBuilder.InsertData(
                table: "TenderMedications",
                columns: new[] { "Id", "MedicationName", "Quantity", "TenderId" },
                values: new object[,]
                {
                    { 1L, "brufen", 1, 1L },
                    { 2L, "ventolin", 1, 1L },
                    { 3L, "brufen", 1, 2L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_RoomID",
                table: "Equipments",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Floors_BuildingID",
                table: "Floors",
                column: "BuildingID");

            migrationBuilder.CreateIndex(
                name: "IX_MoveEquipments_destinationRoomID",
                table: "MoveEquipments",
                column: "destinationRoomID");

            migrationBuilder.CreateIndex(
                name: "IX_MoveEquipments_equipmentID",
                table: "MoveEquipments",
                column: "equipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyOfferComponents_PharmacyOfferId",
                table: "PharmacyOfferComponents",
                column: "PharmacyOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_FloorID",
                table: "Rooms",
                column: "FloorID");

            migrationBuilder.CreateIndex(
                name: "IX_TenderMedications_TenderId",
                table: "TenderMedications",
                column: "TenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicationConsumption");

            migrationBuilder.DropTable(
                name: "MoveEquipments");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Objection");

            migrationBuilder.DropTable(
                name: "Pharmacies");

            migrationBuilder.DropTable(
                name: "PharmacyOfferComponents");

            migrationBuilder.DropTable(
                name: "Response");

            migrationBuilder.DropTable(
                name: "TenderMedications");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "PharmacyOffers");

            migrationBuilder.DropTable(
                name: "Tenders");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Floors");

            migrationBuilder.DropTable(
                name: "Buildings");
        }
    }
}
