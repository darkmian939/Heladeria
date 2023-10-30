using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heladeria.Migrations
{
    /// <inheritdoc />
    public partial class initialmodelswihtoutvalidatios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimerNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SegundoNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "proovedors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompañia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreContacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TituloContacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proovedors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ordenCompras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    TotalAcumulado = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordenCompras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ordenCompras_clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProducto = table.Column<int>(type: "int", nullable: false),
                    ProovedorId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Package = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDiscontinued = table.Column<bool>(type: "bit", nullable: false),
                    OrdenCompraId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productos_ordenCompras_OrdenCompraId",
                        column: x => x.OrdenCompraId,
                        principalTable: "ordenCompras",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_productos_proovedors_ProovedorId",
                        column: x => x.ProovedorId,
                        principalTable: "proovedors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenarItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenarItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenarItems_ordenCompras_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "ordenCompras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenarItems_productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenarItems_OrdenId",
                table: "OrdenarItems",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenarItems_ProductoId",
                table: "OrdenarItems",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ordenCompras_ClienteId",
                table: "ordenCompras",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_productos_OrdenCompraId",
                table: "productos",
                column: "OrdenCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_productos_ProovedorId",
                table: "productos",
                column: "ProovedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenarItems");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "ordenCompras");

            migrationBuilder.DropTable(
                name: "proovedors");

            migrationBuilder.DropTable(
                name: "clientes");
        }
    }
}
