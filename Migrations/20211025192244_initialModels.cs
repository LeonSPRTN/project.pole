using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace project.pole.Migrations
{
    public partial class initialModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customer_estimate_EstimaetId",
                table: "customer");

            migrationBuilder.DropIndex(
                name: "IX_customer_EstimaetId",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "EstimaetId",
                table: "customer");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "estimate",
                newName: "id");

            migrationBuilder.AddColumn<long>(
                name: "ObjectWorkId",
                table: "estimate",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "object_work",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    city = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    street = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    house = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    body = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_object_work", x => x.id);
                    table.ForeignKey(
                        name: "FK_object_work_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_estimate_ObjectWorkId",
                table: "estimate",
                column: "ObjectWorkId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_object_work_CustomerId",
                table: "object_work",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_estimate_object_work_ObjectWorkId",
                table: "estimate",
                column: "ObjectWorkId",
                principalTable: "object_work",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_estimate_object_work_ObjectWorkId",
                table: "estimate");

            migrationBuilder.DropTable(
                name: "object_work");

            migrationBuilder.DropIndex(
                name: "IX_estimate_ObjectWorkId",
                table: "estimate");

            migrationBuilder.DropColumn(
                name: "ObjectWorkId",
                table: "estimate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "estimate",
                newName: "Id");

            migrationBuilder.AddColumn<long>(
                name: "EstimaetId",
                table: "customer",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_customer_EstimaetId",
                table: "customer",
                column: "EstimaetId");

            migrationBuilder.AddForeignKey(
                name: "FK_customer_estimate_EstimaetId",
                table: "customer",
                column: "EstimaetId",
                principalTable: "estimate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
