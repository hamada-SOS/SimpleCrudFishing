using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fishingCompany.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigaration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "boats",
                columns: table => new
                {
                    BoatID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Capacity = table.Column<float>(type: "float", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_boats", x => x.BoatID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "fishermen",
                columns: table => new
                {
                    FishermanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HireDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fishermen", x => x.FishermanID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "fishingTrips",
                columns: table => new
                {
                    TripID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BoatID = table.Column<int>(type: "int", nullable: false),
                    TripDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Destination = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fishingTrips", x => x.TripID);
                    table.ForeignKey(
                        name: "FK_fishingTrips_boats_BoatID",
                        column: x => x.BoatID,
                        principalTable: "boats",
                        principalColumn: "BoatID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "catches",
                columns: table => new
                {
                    CatchID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TripID = table.Column<int>(type: "int", nullable: false),
                    FishingTripTripID = table.Column<int>(type: "int", nullable: true),
                    FishType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Weight = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catches", x => x.CatchID);
                    table.ForeignKey(
                        name: "FK_catches_fishingTrips_FishingTripTripID",
                        column: x => x.FishingTripTripID,
                        principalTable: "fishingTrips",
                        principalColumn: "TripID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sales",
                columns: table => new
                {
                    SaleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CatchID = table.Column<int>(type: "int", nullable: false),
                    MarketName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SaleDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales", x => x.SaleID);
                    table.ForeignKey(
                        name: "FK_sales_catches_CatchID",
                        column: x => x.CatchID,
                        principalTable: "catches",
                        principalColumn: "CatchID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_catches_FishingTripTripID",
                table: "catches",
                column: "FishingTripTripID");

            migrationBuilder.CreateIndex(
                name: "IX_fishingTrips_BoatID",
                table: "fishingTrips",
                column: "BoatID");

            migrationBuilder.CreateIndex(
                name: "IX_sales_CatchID",
                table: "sales",
                column: "CatchID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fishermen");

            migrationBuilder.DropTable(
                name: "sales");

            migrationBuilder.DropTable(
                name: "catches");

            migrationBuilder.DropTable(
                name: "fishingTrips");

            migrationBuilder.DropTable(
                name: "boats");
        }
    }
}
