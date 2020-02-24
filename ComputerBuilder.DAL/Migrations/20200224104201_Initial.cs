using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ComputerBuilder.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "computerBuilds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TotalCost = table.Column<double>(nullable: false),
                    BuildDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_computerBuilds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hardwareTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hardwareTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hardwareItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Cost = table.Column<double>(nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    ManufacturerId = table.Column<int>(nullable: false),
                    HardwareTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hardwareItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hardwareItems_hardwareTypes_HardwareTypeId",
                        column: x => x.HardwareTypeId,
                        principalTable: "hardwareTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hardwareItems_manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuildItem",
                columns: table => new
                {
                    HardwareItemId = table.Column<int>(nullable: false),
                    ComputerBuildId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildItem", x => new { x.ComputerBuildId, x.HardwareItemId });
                    table.ForeignKey(
                        name: "FK_BuildItem_computerBuilds_ComputerBuildId",
                        column: x => x.ComputerBuildId,
                        principalTable: "computerBuilds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildItem_hardwareItems_HardwareItemId",
                        column: x => x.HardwareItemId,
                        principalTable: "hardwareItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "compatibilityProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    PropertyType = table.Column<string>(nullable: true),
                    HardwareItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compatibilityProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_compatibilityProperties_hardwareItems_HardwareItemId",
                        column: x => x.HardwareItemId,
                        principalTable: "hardwareItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildItem_HardwareItemId",
                table: "BuildItem",
                column: "HardwareItemId");

            migrationBuilder.CreateIndex(
                name: "IX_compatibilityProperties_HardwareItemId",
                table: "compatibilityProperties",
                column: "HardwareItemId");

            migrationBuilder.CreateIndex(
                name: "IX_hardwareItems_HardwareTypeId",
                table: "hardwareItems",
                column: "HardwareTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_hardwareItems_ManufacturerId",
                table: "hardwareItems",
                column: "ManufacturerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildItem");

            migrationBuilder.DropTable(
                name: "compatibilityProperties");

            migrationBuilder.DropTable(
                name: "computerBuilds");

            migrationBuilder.DropTable(
                name: "hardwareItems");

            migrationBuilder.DropTable(
                name: "hardwareTypes");

            migrationBuilder.DropTable(
                name: "manufacturers");
        }
    }
}
