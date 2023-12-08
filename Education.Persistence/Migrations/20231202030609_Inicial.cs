using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Persistence.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CursoId);
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Descripcion", "FechaCreacion", "FechaPublicacion", "Precio", "Titulo" },
                values: new object[] { new Guid("0d26ba72-1972-4d42-99a9-ce4afd96ba99"), "Curso de Unit Test para NET Core", new DateTime(2023, 12, 1, 22, 6, 9, 32, DateTimeKind.Local).AddTicks(5206), new DateTime(2025, 12, 1, 22, 6, 9, 32, DateTimeKind.Local).AddTicks(5207), 100m, "Master en UNIT Test con CQRS " });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Descripcion", "FechaCreacion", "FechaPublicacion", "Precio", "Titulo" },
                values: new object[] { new Guid("3b49c270-9835-463d-b94d-ba6fc4c71ff7"), "Curso de C# Basico", new DateTime(2023, 12, 1, 22, 6, 9, 32, DateTimeKind.Local).AddTicks(5093), new DateTime(2025, 12, 1, 22, 6, 9, 32, DateTimeKind.Local).AddTicks(5107), 56m, "C# desde cero hasta avanzado" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Descripcion", "FechaCreacion", "FechaPublicacion", "Precio", "Titulo" },
                values: new object[] { new Guid("b28110a1-6d00-441e-bd72-bb52696ff08e"), "Curso de Java", new DateTime(2023, 12, 1, 22, 6, 9, 32, DateTimeKind.Local).AddTicks(5192), new DateTime(2025, 12, 1, 22, 6, 9, 32, DateTimeKind.Local).AddTicks(5193), 25m, "Master en Java Spring desde las raices" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
