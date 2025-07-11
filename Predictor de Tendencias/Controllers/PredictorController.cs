using System.Diagnostics;
using Application.ENUM;
using Application.Interface;
using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace Predictor_de_Tendencias.Controllers
{
    public class PredictorController : Controller
    {
        private readonly ILogger<PredictorController> _logger;




        public PredictorController(ILogger<PredictorController> logger)
        {
            _logger = logger;
           
        }

        public IActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Calcular(EntradaListViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Index", vm);

                }
                EntradaListViewModelDTO entradaListViewModelDTO = new EntradaListViewModelDTO
                {
                    EntradaList = vm.EntradaList
            .Select(e => new EntradaDTO
            {
                Fecha = e.Fecha,
                Valor = e.Valor
            })
            .ToArray()
                };

                IPredictores predictor = ObtenerModoPrediccion.obtenerModo();
                var resultado = predictor.Calcular(entradaListViewModelDTO.EntradaList);
                ViewBag.ModoActual = ModoPrediccionService.Instance.ModoActual;

                return View("Results", resultado);
            }
            catch (Exception ex)
            {
                return RedirectToRoute(new { controller = "Predictor", action = "Index", message = "Hubo un error en el calculo", messageType = "alert-danger" });
            }
        }

        public IActionResult Results( )
        {

            return View();
        }
    }
}
