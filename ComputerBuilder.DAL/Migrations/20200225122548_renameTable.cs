using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerBuilder.DAL.Migrations
{
    public partial class renameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildItem");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "manufacturers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "hardwareTypes",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ManyBuildsToManyHwItems",
                columns: table => new
                {
                    HardwareItemId = table.Column<int>(nullable: false),
                    ComputerBuildId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManyBuildsToManyHwItems", x => new { x.ComputerBuildId, x.HardwareItemId });
                    table.ForeignKey(
                        name: "FK_ManyBuildsToManyHwItems_computerBuilds_ComputerBuildId",
                        column: x => x.ComputerBuildId,
                        principalTable: "computerBuilds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManyBuildsToManyHwItems_hardwareItems_HardwareItemId",
                        column: x => x.HardwareItemId,
                        principalTable: "hardwareItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManyBuildsToManyHwItems_HardwareItemId",
                table: "ManyBuildsToManyHwItems",
                column: "HardwareItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManyBuildsToManyHwItems");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "manufacturers",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "hardwareTypes",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "BuildItem",
                columns: table => new
                {
                    ComputerBuildId = table.Column<int>(type: "integer", nullable: false),
                    HardwareItemId = table.Column<int>(type: "integer", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_BuildItem_HardwareItemId",
                table: "BuildItem",
                column: "HardwareItemId");
        }
    }
}
