﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Multiservicios.Data.Migrations
{
    public partial class AddMarcasToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Tipo_Activo = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Fecha_Creacion = table.Column<DateTime>(nullable: false),
                    Usuario_Creacion = table.Column<string>(nullable: true),
                    Fecha_Modificacion = table.Column<DateTime>(nullable: false),
                    Usuario_Modificacion = table.Column<string>(nullable: true),
                    CategoriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Marcas_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Marcas_CategoriaId",
                table: "Marcas",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}
