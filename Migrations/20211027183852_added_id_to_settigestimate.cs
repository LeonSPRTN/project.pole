using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace project.pole.Migrations
{
    public partial class added_id_to_settigestimate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "budget",
                table: "object_work",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "building_area",
                table: "object_work",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "inteco",
                table: "object_work",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "moscow_coefficient",
                table: "object_work",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "pit_depth",
                table: "object_work",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "plot_area",
                table: "object_work",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "track",
                table: "object_work",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "winter_coefficient",
                table: "object_work",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "without_coefficient",
                table: "object_work",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "without_radon",
                table: "object_work",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "setting_estimate",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    budget_coefficient = table.Column<int>(type: "int", nullable: false),
                    inteco_coefficient = table.Column<int>(type: "int", nullable: false),
                    inflation_rate = table.Column<int>(type: "int", nullable: false),
                    nds = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_setting_estimate", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "setting_estimate");

            migrationBuilder.DropColumn(
                name: "budget",
                table: "object_work");

            migrationBuilder.DropColumn(
                name: "building_area",
                table: "object_work");

            migrationBuilder.DropColumn(
                name: "inteco",
                table: "object_work");

            migrationBuilder.DropColumn(
                name: "moscow_coefficient",
                table: "object_work");

            migrationBuilder.DropColumn(
                name: "pit_depth",
                table: "object_work");

            migrationBuilder.DropColumn(
                name: "plot_area",
                table: "object_work");

            migrationBuilder.DropColumn(
                name: "track",
                table: "object_work");

            migrationBuilder.DropColumn(
                name: "winter_coefficient",
                table: "object_work");

            migrationBuilder.DropColumn(
                name: "without_coefficient",
                table: "object_work");

            migrationBuilder.DropColumn(
                name: "without_radon",
                table: "object_work");
        }
    }
}
