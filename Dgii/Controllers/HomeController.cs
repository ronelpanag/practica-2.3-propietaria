using Dgii.Contracts;
using Dgii.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dgii.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFacturaService _service;

        public HomeController(IFacturaService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(new Carga());
        }

        [HttpPost]
        public async Task<IActionResult> Index(Carga model)
        {
            var result = await _service.Create(model.FormFile);

            var data = await _service.GetById(result);

            return View("CargaRealizada", data);
        }

        public IActionResult CrearLayoutXml()
        {
            var file = _service.GetXml();

            var stream = System.IO.File.OpenRead(file);

            return File(stream, "text/xml", "606.xml");
        }

        public async Task<IActionResult> CrearLayoutJson()
        {
            var file = await _service.GetJson();

            var stream = System.IO.File.OpenRead(file);

            return File(stream, "text/json", "606.json");
        }
    }
}
