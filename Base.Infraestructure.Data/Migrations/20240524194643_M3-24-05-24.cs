using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Infraestructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class M3240524 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPersona",
                table: "Reservaciones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RFC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AppUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowVersion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservaciones_IdPersona",
                table: "Reservaciones",
                column: "IdPersona");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservaciones_Personas_IdPersona",
                table: "Reservaciones",
                column: "IdPersona",
                principalTable: "Personas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservaciones_Personas_IdPersona",
                table: "Reservaciones");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Reservaciones_IdPersona",
                table: "Reservaciones");

            migrationBuilder.DropColumn(
                name: "IdPersona",
                table: "Reservaciones");
        }
    }
}
