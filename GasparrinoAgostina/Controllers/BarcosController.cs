using Microsoft.AspNetCore.Mvc;
using GasparrinoAgostina.Models;
using GasparrinoAgostina.Services;

namespace GasparrinoAgostina.Controllers
{
    public class BarcosController : Controller
    {
        private IRegistrarBarcosService _barcosService;

        public BarcosController(IRegistrarBarcosService barcosService)
        {
            _barcosService = barcosService;
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarBarco(BarcoModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _barcosService.RegistrarBarco(model.MapearAEntidad());

            return RedirectToAction("Listado");

        }

        public ActionResult Listado()
        {
            var barcos = _barcosService.obtenerLista();

            var BarcosModelLista = BarcoModel.MapearAListaModel(barcos);

            return View(BarcosModelLista);
        }
    }
    
}
