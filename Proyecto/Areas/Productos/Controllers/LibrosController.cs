using Microsoft.AspNetCore.Mvc;
using Proyecto.Aplicacion.Interfaces;
using Proyecto.Dominio.Entidades;
using Proyecto.Dominio.Entidades.DTOs;
using Proyecto.ViewModels;

namespace Proyecto.Areas.Productos.Controllers
{
    [Area("Productos")]
    public class LibrosController : Controller
    {
        private readonly ILibroService _libroService;
        private readonly ICategoriaService _categoriaService;
        private readonly IWebHostEnvironment _env;
        public LibrosController(ILibroService libroService, ICategoriaService categoriaService, IWebHostEnvironment env)
        {
            _libroService = libroService;
            _categoriaService = categoriaService;
            _env = env;
        }
        // GET: LibrosController
        public async Task<IActionResult> Index()
        {
            var libros = await _libroService.ObtenerListadoLibrosAsync();
            var viewModel = new ListadoLibroViewModel()
            {
                Libros = libros
            };
            return View(viewModel);
        }

        // GET: LibrosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LibrosController/Create
        public async Task<IActionResult> Crear()
        {
            var model = new LibrosModel
            {
                CategoriasList = await _categoriaService.ObtenerListadoDeCategoriasAsync()
            };
            return View(model);
        }

        // POST: LibrosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(LibrosModel libros, IFormFile? imagen)
        {
           if (!ModelState.IsValid)
            {
                var errores = ModelState.Values.SelectMany(v => v.Errors)
                                       .Select(e => e.ErrorMessage)
                                       .ToList();

                // solo para ver en consola/logs
                foreach (var error in errores)
                {
                    Console.WriteLine(error);
                }

                libros.CategoriasList = await _categoriaService.ObtenerListadoDeCategoriasAsync();
                return View(libros);

            }

            // IMAGEN 

           ModelState.Remove("ImagePath");

            if (imagen != null && imagen.Length > 0)
            {
                var uploads = Path.Combine(_env.WebRootPath, "images");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imagen.FileName);
                var filePath = Path.Combine(uploads, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imagen.CopyToAsync(stream);
                }

                // Guardamos la ruta relativa
                libros.ImagePath = "/images/" + fileName;
            }
            else
            {
                // Si no hay imagen, ponemos una por defecto
                libros.ImagePath = "/images/default.png";
            }
        

            await _libroService.CrearLibroAsync(libros);
            return RedirectToAction("Index");
        }

        // GET: LibrosController/Edit/5
        public async Task<IActionResult> Editar(int id)
        {
            var libro = await _libroService.ObtenerLibroPorIdAsync(id);

            if (libro == null)
            {
                return NotFound();
            }

            var categorias = await _categoriaService.ObtenerListadoDeCategoriasAsync();
   
            var libroDTO = _libroService.ConvertToDTO(libro);
            libroDTO.CategoriasList = categorias;
            return View(libroDTO);
        }

        // POST: LibrosController/Edit/5
        [HttpPost, ActionName("Editar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(LibrosModel libro, IFormFile? imagen, int id)
        {
            if(!ModelState.IsValid)
            {
                var dto = _libroService.ConvertToDTO(libro);
                return View(dto);
            }
            ModelState.Remove("ImagePath");

            if (imagen != null && imagen.Length > 0)
            {
                var uploads = Path.Combine(_env.WebRootPath, "images");
                if (!Directory.Exists(uploads))
                    Directory.CreateDirectory(uploads);

                var fileName = Guid.NewGuid() + Path.GetExtension(imagen.FileName);
                var filePath = Path.Combine(uploads, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imagen.CopyToAsync(stream);
                }

                libro.ImagePath = "/images/" + fileName;
            }
            else
            {
                // Mantener la imagen existente si no se sube ninguna
                Console.WriteLine("Imagen recibida: " + (imagen != null ? imagen.FileName : "NULL"));
                var libroAnterior = await _libroService.ObtenerLibroPorIdAsync(id);
                libro.ImagePath = libroAnterior.ImagePath;
            }

            await _libroService.ActualizarLibroModelAsync(libro);
            return RedirectToAction("Index");
        }

        // GET: LibrosController/Delete/5
        public async Task<IActionResult> Eliminar(int id)
        {
            var libro = await _libroService.ObtenerLibroPorIdAsync(id);
            if (libro == null)
            {
                return NotFound();
            }

            var libroDTO = _libroService.ConvertToDTO(libro);
            return View(libroDTO);
        }

        // POST: LibrosController/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmacion(int id, IFormCollection collection)
        {
            var libro = await _libroService.ObtenerLibroPorIdAsync(id);

            if (libro == null)
            {
                return NotFound();
            }

            await _libroService.EliminarLibroAsync(id);
            return RedirectToAction("Index");
        }
    }
}
