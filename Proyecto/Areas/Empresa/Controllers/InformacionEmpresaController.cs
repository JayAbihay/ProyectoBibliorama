using Microsoft.AspNetCore.Mvc;
using Proyecto.Aplicacion.Interfaces;
using Proyecto.Dominio.Entidades;
using Proyecto.ViewModels;

namespace Proyecto.Areas.Empresa.Controllers
{
    [Area("Empresa")]
    public class InformacionEmpresaController : Controller
    {
        private readonly IInformacionEmpresaService _informacionEmpresaService;
        private readonly IWebHostEnvironment _env;
        public InformacionEmpresaController(IInformacionEmpresaService informacionEmpresaService, IWebHostEnvironment env)
        {
            _informacionEmpresaService = informacionEmpresaService;
            _env = env;
        }
        // GET: InformacionEmpresaController
        public async Task<IActionResult> Index()
        {
            var infos = await _informacionEmpresaService.ObtenerListadoInformacionEmpresaAsync();

            var viewModel = new ListadoInformacionEmpresaViewModel()
            {
                InformacionEmpresaListado = infos
            };
            return View(viewModel);
        }

        // GET: InformacionEmpresaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InformacionEmpresaController/Create
        public ActionResult Crear()
        {
            return View();
        }

        // POST: InformacionEmpresaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(InformacionEmpresaModel info, IFormFile? imagen1, IFormFile? imagen2, IFormFile? imagen3)
        {

            if (!ModelState.IsValid)
            {
                var errores = ModelState.Values.SelectMany(v => v.Errors)
                                       .Select(e => e.ErrorMessage).ToList();

                                        // solo para ver en consola/logs
                foreach (var error in errores)
                {
                    Console.WriteLine(error);
                }

                return View(info);
            }

            // IMAGENES

            ModelState.Remove("CarouselImage1Path");
            ModelState.Remove("CarouselImage2Path");
            ModelState.Remove("CarouselImage3Path");

            if (imagen1 != null && imagen1.Length > 0)
            {
                var uploadsFolder = Path.Combine(_env.WebRootPath, "images", "empresa");
                Directory.CreateDirectory(uploadsFolder); // Asegura que el directorio exista
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + imagen1.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imagen1.CopyTo(fileStream);
                }

                info.CarouselImage1Path = "/images/empresa/" + uniqueFileName;
            }
            else
            {
                ModelState.AddModelError("CarouselImage1Path", "La imagen 1 es obligatoria.");
                return View(info);
            }

            if (imagen2 != null && imagen2.Length > 0)
            {
                var uploadsFolder = Path.Combine(_env.WebRootPath, "images", "empresa");
                Directory.CreateDirectory(uploadsFolder); // Asegura que el directorio exista
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + imagen2.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imagen2.CopyTo(fileStream);
                }

                info.CarouselImage2Path = "/images/empresa/" + uniqueFileName;
            }
            else
            {
                ModelState.AddModelError("CarouselImage2Path", "La imagen 2 es obligatoria.");
                return View(info);
            }

            if (imagen3 != null && imagen3.Length > 0)
            {
                var uploadsFolder = Path.Combine(_env.WebRootPath, "images", "empresa");
                Directory.CreateDirectory(uploadsFolder); // Asegura que el directorio exista
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + imagen3.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imagen3.CopyTo(fileStream);
                }

                info.CarouselImage3Path = "/images/empresa/" + uniqueFileName;
            }
            else
            {
                ModelState.AddModelError("CarouselImage3Path", "La imagen 3 es obligatoria.");
                return View(info);
            }

            await _informacionEmpresaService.CrearInfosAsync(info);
            return RedirectToAction("Index");
        }

        // GET: InformacionEmpresaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InformacionEmpresaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InformacionEmpresaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InformacionEmpresaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
