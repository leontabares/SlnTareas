﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tarea.Persistence.Database;

#nullable disable

namespace Tarea.Persistence.Database.Migrations
{
    [DbContext(typeof(TareaDbContext))]
    [Migration("20240209044159_Inicializacion")]
    partial class Inicializacion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Tarea")
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tareas.Domain.Categoria", b =>
                {
                    b.Property<Guid>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCategoria");

                    b.HasIndex("IdCategoria");

                    b.ToTable("Categorias", "Tarea");

                    b.HasData(
                        new
                        {
                            IdCategoria = new Guid("094d0686-a07a-4b44-bf37-48108e1f76d9"),
                            Descripcion = "Prioritario"
                        },
                        new
                        {
                            IdCategoria = new Guid("fc87c8f0-7ef8-40ab-be4e-2682885fb5cc"),
                            Descripcion = "No Prioritario"
                        });
                });

            modelBuilder.Entity("Tareas.Domain.Tarea", b =>
                {
                    b.Property<Guid>("IdTarea")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoriaIdCategoria")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.HasKey("IdTarea");

                    b.HasIndex("CategoriaIdCategoria");

                    b.HasIndex("IdTarea");

                    b.ToTable("Tareas", "Tarea");
                });

            modelBuilder.Entity("Tareas.Domain.Tarea", b =>
                {
                    b.HasOne("Tareas.Domain.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaIdCategoria");

                    b.Navigation("Categoria");
                });
#pragma warning restore 612, 618
        }
    }
}