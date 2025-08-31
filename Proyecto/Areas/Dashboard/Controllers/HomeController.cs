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
        private readonly IInformacionEmpresaService _informacionEmpresaService;
        public HomeController(ILogger<HomeController> logger,ILibroService libroService, ICategoriaService categoriaService, IInformacionEmpresaService informacionEmpresaService)
        {
            _logger = logger;
            _libroService = libroService;
            _categoriaService = categoriaService;
            _informacionEmpresaService = informacionEmpresaService;
        }

        public async Task<IActionResult> Index()
        {
            var listadoLibros = await _libroService.ObtenerListadoLibrosAsync();
            var listadoInformacionEmpresa = await _informacionEmpresaService.ObtenerListadoInformacionEmpresaAsync(); 
            var viewModel = new LibroEInformacionEmpresaViewModel()
            {
                Libros = listadoLibros,
                InformacionesEmpresa = listadoInformacionEmpresa
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
