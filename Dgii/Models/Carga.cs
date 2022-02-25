using Microsoft.AspNetCore.Http;

namespace Dgii.Models
{
    public class Carga
    {
        public int Id { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
