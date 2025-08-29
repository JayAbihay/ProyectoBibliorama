using Microsoft.AspNetCore.Mvc;
using Proyecto.Aplicacion.Interfaces;
using Proyecto.Models;
using Proyecto.ViewModels;
using System.Diagnostics;

namespace Proyecto.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILibroService _libroService;
        private readonly ICategoriaService _categoriaService;

        public HomeController(ILogger<HomeController> logger,ILibroService libroService, ICategoriaService categoriaService)
        {
            _logger = logger;
            _libroService = libroService;
            _categoriaService = categoriaService;
        }

        public async Task<IActionResult> Index()
        {
            var listadoLibros = await _libroService.ObtenerListadoLibrosAsync();

            var viewModel = new ListadoLibroViewModel()
            {
                Libros = listadoLibros
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
