using Dgii.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Dgii.Contracts
{
    public interface IFacturaService
    {
        Task<Reporte> GetById(int id);
        string GetXml();
        Task<string> GetJson();
        Task<int> Create(IFormFile archivo);
    }
}
