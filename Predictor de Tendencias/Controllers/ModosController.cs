using System.Diagnostics;
using Application.ENUM;
using Application.Interface;
using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace Predictor_de_Tendencias.Controllers
{
    public class ModosController : Controller
    {
        private readonly ILogger<ModosController> _logger;
     



        public ModosController(ILogger<ModosController> logger)
        {
            _logger = logger;
        }

        

        public IActionResult Modos()
        {
            ModoPrediccionViewModel modoPrediccion = new()
            {
                ModoActual = ModoPrediccionService.Instance.ModoActual
            };
          
            return View(modoPrediccion);
        }

        [HttpPost]
        public IActionResult Modos(int modo)
        {
            if (Enum.IsDefined(typeof(ModoPrediccionENUM), modo))
            {
                ModoPrediccionService.Instance.EstablecerModo((ModoPrediccionENUM)modo);
            }

            return RedirectToAction("Modos");
        }

        
    }
}
