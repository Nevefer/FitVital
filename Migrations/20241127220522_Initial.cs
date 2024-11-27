using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitVital.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Usuarios_UsuarioId",
                table: "Citas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Citas_NutricionistaId_UsuarioId",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_UsuarioId",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Citas");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Nutricionistas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_Id",
                table: "Citas",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Citas_NutricionistaId",
                table: "Citas",
                column: "NutricionistaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Citas_Id",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_NutricionistaId",
                table: "Citas");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Nutricionistas",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Citas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_NutricionistaId_UsuarioId",
                table: "Citas",
                columns: new[] { "NutricionistaId", "UsuarioId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Citas_UsuarioId",
                table: "Citas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Name",
                table: "Usuarios",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Usuarios_UsuarioId",
                table: "Citas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
