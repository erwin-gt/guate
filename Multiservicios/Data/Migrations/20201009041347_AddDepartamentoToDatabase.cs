using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Multiservicios.Data.Migrations
{
    public partial class AddDepartamentoToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Categoria = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Fecha_Creacion = table.Column<DateTime>(nullable: false),
                    Usuario_Creacion = table.Column<string>(nullable: true),
                    Fecha_Modificacion = table.Column<DateTime>(nullable: false),
                    Usuario_Modificacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Marca = table.Column<string>(nullable: false),
                    Tipo_Activo = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Fecha_Creacion = table.Column<DateTime>(nullable: false),
                    Usuario_Creacion = table.Column<string>(nullable: true),
                    Fecha_Modificacion = table.Column<DateTime>(nullable: false),
                    Usuario_Modificacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProveedor = table.Column<string>(nullable: false),
                    NombreContacto = table.Column<string>(nullable: true),
                    CorreoContacto = table.Column<string>(nullable: true),
                    TelefonoContacto = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AreaTrabajo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    DepartamentoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaTrabajo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AreaTrabajo_Departamento_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Puesto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    DepartamentoId = table.Column<int>(nullable: false),
                    AreaTrabajoId = table.Column<int>(nullable: false),
                    AreaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puesto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Puesto_AreaTrabajo_AreaId",
                        column: x => x.AreaId,
                        principalTable: "AreaTrabajo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Puesto_Departamento_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreaTrabajo_DepartamentoId",
                table: "AreaTrabajo",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Puesto_AreaId",
                table: "Puesto",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Puesto_DepartamentoId",
                table: "Puesto",
                column: "DepartamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Puesto");

            migrationBuilder.DropTable(
                name: "AreaTrabajo");

            migrationBuilder.DropTable(
                name: "Departamento");
        }
    }
}
