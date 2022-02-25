namespace Dgii.Models
{
    public class Detalle
    {
        public string Identificacion { get; set; } = "";
        public int Tipo { get; set; }
        public int TipoComprado { get; set; }
        public string Ncf { get; set; } = "";
        public string Documento { get; set; } = "";
        public int FechaComprobante { get; set; }
        public int FechaPago { get; set; }
        public decimal MontoServicios { get; set; }
        public decimal MontoBienes { get; set; }
        public decimal TotalFacturado { get; set; }
        public decimal ItbisFacturado { get; set; }
        public decimal ItbisRetenido { get; set; }
        public decimal ItbisProporcionado { get; set; }
        public decimal ItbisCosto { get; set; }
        public decimal ItbisPorAdelantar { get; set; }
        public decimal ItbisPercibido { get; set; }
        public int TipoIsr { get; set; }
        public decimal MontoIsr { get; set; }
        public decimal IsrPercibido { get; set; }
        public decimal Isc { get; set; }
        public decimal OtrosImpuestos { get; set; }
        public decimal MontoPropina { get; set; }
        public int FormaPago { get; set; }

    }
}
