using Microsoft.EntityFrameworkCore.Migrations;

namespace project.pole.Migrations
{
    public partial class EstimateFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_estimate_object_ObjectId",
                table: "estimate");

            migrationBuilder.RenameColumn(
                name: "Path",
                table: "estimate",
                newName: "path");

            migrationBuilder.RenameColumn(
                name: "ObjectId",
                table: "estimate",
                newName: "object_id");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "estimate",
                newName: "date_created");

            migrationBuilder.RenameIndex(
                name: "IX_estimate_ObjectId",
                table: "estimate",
                newName: "IX_estimate_object_id");

            migrationBuilder.AddForeignKey(
                name: "FK_estimate_object_object_id",
                table: "estimate",
                column: "object_id",
                principalTable: "object",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_estimate_object_object_id",
                table: "estimate");

            migrationBuilder.RenameColumn(
                name: "path",
                table: "estimate",
                newName: "Path");

            migrationBuilder.RenameColumn(
                name: "object_id",
                table: "estimate",
                newName: "ObjectId");

            migrationBuilder.RenameColumn(
                name: "date_created",
                table: "estimate",
                newName: "DateCreated");

            migrationBuilder.RenameIndex(
                name: "IX_estimate_object_id",
                table: "estimate",
                newName: "IX_estimate_ObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_estimate_object_ObjectId",
                table: "estimate",
                column: "ObjectId",
                principalTable: "object",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
