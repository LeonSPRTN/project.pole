using Microsoft.EntityFrameworkCore.Migrations;

namespace project.pole.Migrations
{
    public partial class _17112021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "winter_coefficient",
                table: "object_work",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "winter_coefficient",
                table: "object_work",
                type: "double",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");
        }
    }
}
