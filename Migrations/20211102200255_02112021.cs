using Microsoft.EntityFrameworkCore.Migrations;

namespace project.pole.Migrations
{
    public partial class _02112021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_object_work_customer_CustomerId",
                table: "object_work");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "object_work",
                newName: "customer_id");

            migrationBuilder.RenameIndex(
                name: "IX_object_work_CustomerId",
                table: "object_work",
                newName: "IX_object_work_customer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_object_work_customer_customer_id",
                table: "object_work",
                column: "customer_id",
                principalTable: "customer",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_object_work_customer_customer_id",
                table: "object_work");

            migrationBuilder.RenameColumn(
                name: "customer_id",
                table: "object_work",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_object_work_customer_id",
                table: "object_work",
                newName: "IX_object_work_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_object_work_customer_CustomerId",
                table: "object_work",
                column: "CustomerId",
                principalTable: "customer",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
