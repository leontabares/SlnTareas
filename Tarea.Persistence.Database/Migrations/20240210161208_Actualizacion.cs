using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tarea.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class Actualizacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Tarea",
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: new Guid("094d0686-a07a-4b44-bf37-48108e1f76d9"));

            migrationBuilder.DeleteData(
                schema: "Tarea",
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: new Guid("fc87c8f0-7ef8-40ab-be4e-2682885fb5cc"));

            migrationBuilder.AddColumn<bool>(
                name: "Finalizada",
                schema: "Tarea",
                table: "Tareas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                schema: "Tarea",
                table: "Categorias",
                columns: new[] { "IdCategoria", "Descripcion" },
                values: new object[,]
                {
                    { new Guid("674fe0f7-538a-4f79-8520-2daf7fdb4df3"), "Prioritario" },
                    { new Guid("8e151dbe-8e80-4a30-88d8-0f4ed406a3d5"), "No Prioritario" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Tarea",
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: new Guid("674fe0f7-538a-4f79-8520-2daf7fdb4df3"));

            migrationBuilder.DeleteData(
                schema: "Tarea",
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: new Guid("8e151dbe-8e80-4a30-88d8-0f4ed406a3d5"));

            migrationBuilder.DropColumn(
                name: "Finalizada",
                schema: "Tarea",
                table: "Tareas");

            migrationBuilder.InsertData(
                schema: "Tarea",
                table: "Categorias",
                columns: new[] { "IdCategoria", "Descripcion" },
                values: new object[,]
                {
                    { new Guid("094d0686-a07a-4b44-bf37-48108e1f76d9"), "Prioritario" },
                    { new Guid("fc87c8f0-7ef8-40ab-be4e-2682885fb5cc"), "No Prioritario" }
                });
        }
    }
}
