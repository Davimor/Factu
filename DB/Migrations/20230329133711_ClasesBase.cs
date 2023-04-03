using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class ClasesBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "BaseImponible",
                table: "Factura",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Factura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFactura",
                table: "Factura",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Retenciones",
                table: "Factura",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalFactura",
                table: "Factura",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalImpuesto",
                table: "Factura",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IdFiscal = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Concepto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    importe = table.Column<double>(type: "float", nullable: false),
                    iva = table.Column<double>(type: "float", nullable: false),
                    retencion = table.Column<double>(type: "float", nullable: false),
                    FacturaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concepto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Concepto_Factura_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "Factura",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TipoContacto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoContacto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tratamiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tratamiento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoId = table.Column<int>(type: "int", nullable: false),
                    valor = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EnvioFactura = table.Column<bool>(type: "bit", maxLength: 200, nullable: false),
                    TratamientoId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacto_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contacto_TipoContacto_TipoId",
                        column: x => x.TipoId,
                        principalTable: "TipoContacto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contacto_Tratamiento_TratamientoId",
                        column: x => x.TratamientoId,
                        principalTable: "Tratamiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Factura_ClienteId",
                table: "Factura",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Concepto_FacturaId",
                table: "Concepto",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_ClienteId",
                table: "Contacto",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_TipoId",
                table: "Contacto",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_TratamientoId",
                table: "Contacto",
                column: "TratamientoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Cliente_ClienteId",
                table: "Factura",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Cliente_ClienteId",
                table: "Factura");

            migrationBuilder.DropTable(
                name: "Concepto");

            migrationBuilder.DropTable(
                name: "Contacto");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "TipoContacto");

            migrationBuilder.DropTable(
                name: "Tratamiento");

            migrationBuilder.DropIndex(
                name: "IX_Factura_ClienteId",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "BaseImponible",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "FechaFactura",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "Retenciones",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "TotalFactura",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "TotalImpuesto",
                table: "Factura");
        }
    }
}
