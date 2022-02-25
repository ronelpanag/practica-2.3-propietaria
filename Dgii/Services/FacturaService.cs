using Dgii.Contracts;
using Dgii.Data;
using Dgii.DataClasses;
using Dgii.Helpers;
using Dgii.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Dgii.Services
{
    public class FacturaService : IFacturaService
    {
        private readonly ApplicationDbContext _context;

        public FacturaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Reporte> GetById(int id)
        {
            var factura = await _context.Registros
                .Where(x => x.IdCarga == id)
                .Select(x => new Reporte
                {
                    IdCarga = x.IdCarga,
                    CantidadRegistros = x.CantidadRegistros,
                    Identificacion = x.Identificacion,
                    Formato = x.Formato,
                    Periodo = x.Periodo
                })
                .FirstOrDefaultAsync();

            var detalles = await _context.Registros
                .Where(x => x.IdCarga == id)
                .Select(x => new Detalle
                {
                    Documento = x.Documento,
                    FechaComprobante = x.FechaComprobante,
                    FechaPago = x.FechaPago,
                    FormaPago = x.FormaPago,
                    Identificacion = x.IdentificacionProveedor,
                    Isc = x.Isc,
                    ItbisFacturado = x.ItbisFacturado,
                    IsrPercibido = x.IsrPercibido,
                    ItbisCosto = x.ItbisCosto,
                    ItbisPercibido = x.ItbisPercibido,
                    ItbisPorAdelantar = x.ItbisPorAdelantar,
                    ItbisProporcionado = x.ItbisProporcionado,
                    ItbisRetenido = x.ItbisRetenido,
                    TipoIsr = x.TipoIsr,
                    MontoBienes = x.MontoBienes,
                    MontoIsr = x.MontoIsr,
                    MontoPropina = x.MontoPropina,
                    MontoServicios = x.MontoServicios,
                    Ncf = x.Ncf,
                    OtrosImpuestos = x.OtrosImpuestos,
                    Tipo = x.Tipo,
                    TipoComprado = x.TipoComprado,
                    TotalFacturado = x.TotalFacturado
                })
                .ToListAsync();

            factura.Detalles = detalles;

            return factura;
        }

        public string GetXml()
        {
            var factura = new Reporte();

            var serializer = new XmlSerializer(typeof(Reporte));

            string path = $"{Configuration.Ruta}\\606.xml";

            if (File.Exists(path))
            {
                File.Delete(path);
            }
            
            var file = File.Create(path);

            serializer.Serialize(file, factura);

            file.Close();

            return path;
        }

        public async Task<string> GetJson()
        {
            var reporte = new Reporte();

            var options = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            var json = JsonConvert.SerializeObject(reporte, options);

            string path = $"{Configuration.Ruta}\\606.json";

            if (File.Exists(path))
            {
                File.Delete(path);
            }
            
            using (var file = File.Create(path))
            {
                file.Close();

                await File.AppendAllTextAsync(path, json);
            }

            return path;
        }

        public async Task<int> Create(IFormFile archivo)
        {
            var serializer = new XmlSerializer(typeof(Reporte));

            var registros = (Reporte)serializer.Deserialize(archivo.OpenReadStream());

            var result = await SaveRecords(registros);

            return result;
        }

        private async Task<int> SaveRecords(Reporte factura)
        {
            var hasRecords = await _context.Registros.AnyAsync();

            var ultimoIdCarga = 0;

            if (hasRecords)
                ultimoIdCarga = await _context.Registros.Select(x => x.IdCarga).MaxAsync();

            var registros = factura.Detalles
                .Where(x => !string.IsNullOrEmpty(x.Ncf))
                .Select(x => new Registro 
                {
                    IdCarga = ultimoIdCarga + 1,
                    CantidadRegistros = factura.CantidadRegistros,
                    Identificacion = factura.Identificacion,
                    Formato = factura.Formato,
                    Periodo = factura.Periodo,

                    Documento = x.Documento,
                    FechaComprobante = x.FechaComprobante,
                    FechaPago = x.FechaPago,
                    FormaPago = x.FormaPago,
                    IdentificacionProveedor = x.Identificacion,
                    Isc = x.Isc,
                    ItbisFacturado = x.ItbisFacturado,
                    IsrPercibido = x.IsrPercibido,
                    ItbisCosto = x.ItbisCosto,
                    ItbisPercibido = x.ItbisPercibido,
                    ItbisPorAdelantar = x.ItbisPorAdelantar,
                    ItbisProporcionado = x.ItbisProporcionado,
                    ItbisRetenido = x.ItbisRetenido,
                    TipoIsr = x.TipoIsr,
                    MontoBienes = x.MontoBienes,
                    MontoIsr = x.MontoIsr,
                    MontoPropina = x.MontoPropina,
                    MontoServicios = x.MontoServicios,
                    Ncf = x.Ncf,
                    OtrosImpuestos = x.OtrosImpuestos,
                    Tipo = x.Tipo,
                    TipoComprado = x.TipoComprado,
                    TotalFacturado = x.TotalFacturado
                })
                .ToList();

            await _context.Registros.AddRangeAsync(registros);
            await _context.SaveChangesAsync();

            return registros.FirstOrDefault().IdCarga;
        }
    }
}
