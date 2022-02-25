using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dgii.Migrations
{
    public partial class create_table_registros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCarga = table.Column<int>(nullable: false),
                    FechaCarga = table.Column<DateTime>(nullable: false),
                    Formato = table.Column<int>(nullable: false),
                    Identificacion = table.Column<string>(nullable: true),
                    CantidadRegistros = table.Column<int>(nullable: false),
                    Periodo = table.Column<int>(nullable: false),
                    IdentificacionProveedor = table.Column<string>(nullable: true),
                    Tipo = table.Column<int>(nullable: false),
                    TipoComprado = table.Column<int>(nullable: false),
                    Ncf = table.Column<string>(nullable: true),
                    Documento = table.Column<string>(nullable: true),
                    FechaComprobante = table.Column<int>(nullable: false),
                    FechaPago = table.Column<int>(nullable: false),
                    MontoServicios = table.Column<decimal>(nullable: false),
                    MontoBienes = table.Column<decimal>(nullable: false),
                    TotalFacturado = table.Column<decimal>(nullable: false),
                    ItbisFacturado = table.Column<decimal>(nullable: false),
                    ItbisRetenido = table.Column<decimal>(nullable: false),
                    ItbisProporcionado = table.Column<decimal>(nullable: false),
                    ItbisCosto = table.Column<decimal>(nullable: false),
                    ItbisPorAdelantar = table.Column<decimal>(nullable: false),
                    ItbisPercibido = table.Column<decimal>(nullable: false),
                    TipoIsr = table.Column<int>(nullable: false),
                    MontoIsr = table.Column<decimal>(nullable: false),
                    IsrPercibido = table.Column<decimal>(nullable: false),
                    Isc = table.Column<decimal>(nullable: false),
                    OtrosImpuestos = table.Column<decimal>(nullable: false),
                    MontoPropina = table.Column<decimal>(nullable: false),
                    FormaPago = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registros");
        }
    }
}
