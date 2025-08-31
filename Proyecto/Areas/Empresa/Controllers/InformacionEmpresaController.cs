using Microsoft.AspNetCore.Mvc;
using Proyecto.Aplicacion.Interfaces;
using Proyecto.Dominio.Entidades;
using Proyecto.Dominio.Entidades.Enums;
using Proyecto.Dominio.Interfaces;
using Proyecto.ViewModels;

namespace Proyecto.Areas.Empresa.Controllers
{
    [Area("Empresa")]
    public class InformacionEmpresaController : Controller
    {
        private readonly IInformacionEmpresaService _informacionEmpresaService;
        private readonly IWebHostEnvironment _env;
        private readonly IUnitOfWork _unitOfWork;
        public InformacionEmpresaController(IInformacionEmpresaService informacionEmpresaService, IWebHostEnvironment env, IUnitOfWork unitOfWork)
        {
            _informacionEmpresaService = informacionEmpresaService;
            _env = env;
            _unitOfWork = unitOfWork;
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
        public async Task<IActionResult> Crear(InformacionEmpresaModel info, IFormFile? logoImagen, IFormFile? imagen1, IFormFile? imagen2, IFormFile? imagen3)
        {
            // Quitar validaciones de campos que se llenarán manualmente
            ModelState.Remove("LogoImagePath");
            ModelState.Remove("CarouselImage1Path");
            ModelState.Remove("CarouselImage2Path");
            ModelState.Remove("CarouselImage3Path");

            if (!ModelState.IsValid)
            {
                var errores = ModelState.Values.SelectMany(v => v.Errors)
                                           .Select(e => e.ErrorMessage).ToList();

                foreach (var error in errores)
                {
                    Console.WriteLine(error);
                }

                return View(info);
            }

            // IMAGENES
            ModelState.Remove("LogoImagePath");
            ModelState.Remove("CarouselImage1Path");
            ModelState.Remove("CarouselImage2Path");
            ModelState.Remove("CarouselImage3Path");

            if (logoImagen != null && logoImagen.Length > 0)
            {
                var uploadsFolder = Path.Combine(_env.WebRootPath, "images", "empresa");
                Directory.CreateDirectory(uploadsFolder);
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + logoImagen.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await logoImagen.CopyToAsync(fileStream); // usar el logo correcto
                }

                info.LogoImagePath = "/images/empresa/" + uniqueFileName; // asignar al campo correcto
            }
            else
            {
                ModelState.AddModelError("LogoImagePath", "La imagen de logo es obligatoria.");
                return View(info);
            }


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

        public async Task<IActionResult> CambiarEstadoNombre (int id, EstadoNombreEnum nuevoEstado)
        {
            await _informacionEmpresaService.CambiarEstadoNombreAsync(id, nuevoEstado);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CambiarEstadoDireccion(int id, EstadoDireccionEnum nuevoEstado)
        {
            await _informacionEmpresaService.CambiarEstadoDireccionAsync(id, nuevoEstado);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CambiarEstadoDescripcion(int id, EstadoGeneralEnum nuevoEstado)
        {
            await _informacionEmpresaService.CambiarEstadoDescripcionAsync(id, nuevoEstado);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CambiarEstadoTelefono(int id, EstadoGeneralEnum nuevoEstado)
        {
            await _informacionEmpresaService.CambiarEstadoTelefonoAsync(id, nuevoEstado);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CambiarEstadoCorreoElectronico(int id, EstadoGeneralEnum nuevoEstado)
        {
            await _informacionEmpresaService.CambiarEstadoCorreoElectronicoAsync(id, nuevoEstado);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CambiarEstadoIdentificacion(int id, EstadoGeneralEnum nuevoEstado)
        {
            await _informacionEmpresaService.CambiarEstadoIdentificacionAsync(id, nuevoEstado);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CambiarEstadoLogo(int id, EstadoGeneralEnum nuevoEstado)
        {
            await _informacionEmpresaService.CambiarEstadoLogoAsync(id, nuevoEstado);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CambiarEstadoCarouselImage1Path(int id, EstadoGeneralEnum nuevoEstado)
        {
            await _informacionEmpresaService.CambiarEstadoCarouselImage1PathAsync(id, nuevoEstado);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CambiarEstadoCarouselImage2Path(int id, EstadoGeneralEnum nuevoEstado)
        {
            await _informacionEmpresaService.CambiarEstadoCarouselImage2PathAsync(id, nuevoEstado);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CambiarEstadoCarouselImage3Path(int id, EstadoGeneralEnum nuevoEstado)
        {
            await _informacionEmpresaService.CambiarEstadoCarouselImage3PathAsync(id, nuevoEstado);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CambiarEstadoDescripcionCarousel1(int id, EstadoGeneralEnum nuevoEstado)
        {
            await _informacionEmpresaService.CambiarEstadoDescripcionCarousel1Async(id, nuevoEstado);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CambiarEstadoDescripcionCarousel2(int id, EstadoGeneralEnum nuevoEstado)
        {
            await _informacionEmpresaService.CambiarEstadoDescripcionCarousel2Async(id, nuevoEstado);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CambiarEstadoDescripcionCarousel3(int id, EstadoGeneralEnum nuevoEstado)
        {
            await _informacionEmpresaService.CambiarEstadoDescripcionCarousel3Async(id, nuevoEstado);
            return RedirectToAction("Index");
        }

    }
}
