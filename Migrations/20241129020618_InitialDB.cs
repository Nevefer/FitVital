using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitVital.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administradors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EjercicioUsuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EjercicioUsuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nutricionistas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutricionistas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ejercicios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdministradorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EjercicioUsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ejercicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ejercicios_Administradors_AdministradorId",
                        column: x => x.AdministradorId,
                        principalTable: "Administradors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ejercicios_EjercicioUsuarios_EjercicioUsuarioId",
                        column: x => x.EjercicioUsuarioId,
                        principalTable: "EjercicioUsuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdministradorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EjercicioUsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Administradors_AdministradorId",
                        column: x => x.AdministradorId,
                        principalTable: "Administradors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_EjercicioUsuarios_EjercicioUsuarioId",
                        column: x => x.EjercicioUsuarioId,
                        principalTable: "EjercicioUsuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NutricionistaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citas_Nutricionistas_NutricionistaId",
                        column: x => x.NutricionistaId,
                        principalTable: "Nutricionistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administradors_Id",
                table: "Administradors",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Citas_Id",
                table: "Citas",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Citas_NutricionistaId",
                table: "Citas",
                column: "NutricionistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_UsuarioId",
                table: "Citas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Ejercicios_AdministradorId",
                table: "Ejercicios",
                column: "AdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ejercicios_EjercicioUsuarioId",
                table: "Ejercicios",
                column: "EjercicioUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Ejercicios_Id",
                table: "Ejercicios",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EjercicioUsuarios_Id",
                table: "EjercicioUsuarios",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nutricionistas_Name",
                table: "Nutricionistas",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_AdministradorId",
                table: "Usuarios",
                column: "AdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EjercicioUsuarioId",
                table: "Usuarios",
                column: "EjercicioUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Id",
                table: "Usuarios",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Ejercicios");

            migrationBuilder.DropTable(
                name: "Nutricionistas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Administradors");

            migrationBuilder.DropTable(
                name: "EjercicioUsuarios");
        }
    }
}
