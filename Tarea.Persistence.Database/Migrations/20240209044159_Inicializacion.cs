using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tarea.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class Inicializacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Tarea");

            migrationBuilder.CreateTable(
                name: "Categorias",
                schema: "Tarea",
                columns: table => new
                {
                    IdCategoria = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Tareas",
                schema: "Tarea",
                columns: table => new
                {
                    IdTarea = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoriaIdCategoria = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tareas", x => x.IdTarea);
                    table.ForeignKey(
                        name: "FK_Tareas_Categorias_CategoriaIdCategoria",
                        column: x => x.CategoriaIdCategoria,
                        principalSchema: "Tarea",
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria");
                });

            migrationBuilder.InsertData(
                schema: "Tarea",
                table: "Categorias",
                columns: new[] { "IdCategoria", "Descripcion" },
                values: new object[,]
                {
                    { new Guid("094d0686-a07a-4b44-bf37-48108e1f76d9"), "Prioritario" },
                    { new Guid("fc87c8f0-7ef8-40ab-be4e-2682885fb5cc"), "No Prioritario" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_IdCategoria",
                schema: "Tarea",
                table: "Categorias",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_CategoriaIdCategoria",
                schema: "Tarea",
                table: "Tareas",
                column: "CategoriaIdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_IdTarea",
                schema: "Tarea",
                table: "Tareas",
                column: "IdTarea");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tareas",
                schema: "Tarea");

            migrationBuilder.DropTable(
                name: "Categorias",
                schema: "Tarea");
        }
    }
}
