using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tarea.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class Actualizacion2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tareas_Categorias_CategoriaIdCategoria",
                schema: "Tarea",
                table: "Tareas");

            migrationBuilder.DropIndex(
                name: "IX_Tareas_CategoriaIdCategoria",
                schema: "Tarea",
                table: "Tareas");

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
                name: "CategoriaIdCategoria",
                schema: "Tarea",
                table: "Tareas");

            migrationBuilder.AddColumn<Guid>(
                name: "Categoria",
                schema: "Tarea",
                table: "Tareas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                schema: "Tarea",
                table: "Categorias",
                columns: new[] { "IdCategoria", "Descripcion" },
                values: new object[,]
                {
                    { new Guid("6f85d7a8-3202-4fef-98ab-0b42bd1c84b9"), "Prioritario" },
                    { new Guid("ddd7863c-ed3d-4bb4-b13f-db0021f33655"), "No Prioritario" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Tarea",
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: new Guid("6f85d7a8-3202-4fef-98ab-0b42bd1c84b9"));

            migrationBuilder.DeleteData(
                schema: "Tarea",
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: new Guid("ddd7863c-ed3d-4bb4-b13f-db0021f33655"));

            migrationBuilder.DropColumn(
                name: "Categoria",
                schema: "Tarea",
                table: "Tareas");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoriaIdCategoria",
                schema: "Tarea",
                table: "Tareas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "Tarea",
                table: "Categorias",
                columns: new[] { "IdCategoria", "Descripcion" },
                values: new object[,]
                {
                    { new Guid("674fe0f7-538a-4f79-8520-2daf7fdb4df3"), "Prioritario" },
                    { new Guid("8e151dbe-8e80-4a30-88d8-0f4ed406a3d5"), "No Prioritario" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_CategoriaIdCategoria",
                schema: "Tarea",
                table: "Tareas",
                column: "CategoriaIdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Tareas_Categorias_CategoriaIdCategoria",
                schema: "Tarea",
                table: "Tareas",
                column: "CategoriaIdCategoria",
                principalSchema: "Tarea",
                principalTable: "Categorias",
                principalColumn: "IdCategoria");
        }
    }
}
