using Microsoft.AspNetCore.Mvc;
using Proyecto.Aplicacion.Interfaces;
using Proyecto.Dominio.Entidades;
using Proyecto.Dominio.Entidades.DTOs;
using Proyecto.ViewModels;

namespace Proyecto.Areas.Productos.Controllers
{
    [Area("Productos")]
    public class CategoriasController : Controller
    {
        private readonly ICategoriaService _categoriaService; 

        public CategoriasController(ICategoriaService categoriaService)
        {
            
            _categoriaService = categoriaService; 
        }


        // GET: CategoriasController
        public async Task<IActionResult> Index()
        {
            var categorias = await _categoriaService.ObtenerListadoDeCategoriasAsync();
            var viewModel = new ListadoCategoriaViewModel
            {
               Categorias = categorias
            };
            return View(viewModel);
        }

        // GET: CategoriasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoriasController/Create
        public ActionResult Crear()
        {
            return View();
        }

        // POST: CategoriasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(CategoriaModel categoria)
        {
            if (ModelState.IsValid)
            {
                await _categoriaService.CrearCategoriaAsync(categoria);
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // GET: CategoriasController/Edit/5
        public async Task<IActionResult> Editar(int id)
        { 
            
            var categoria = await _categoriaService.ObtenerCategoriaPorIdAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            var categoriaDTO = _categoriaService.ConvertToDTO(categoria);
           
            return View(categoriaDTO);
        }

        // POST: CategoriasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(CategoriaDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto); // <- Devuelves el mismo DTO si hay errores
            }

            // Convertimos el DTO a Model
            var model = _categoriaService.ConvertToModel(dto);

            await _categoriaService.ActualizarCategoriaModelAsync(model);
            return RedirectToAction("Index");
        }


        // GET: CategoriasController/Delete/5
        public async Task<IActionResult> Eliminar(int id)
        {
            var categoria = await _categoriaService.ObtenerCategoriaPorIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            var categoriaDTO = _categoriaService.ConvertToDTO(categoria);
            return View(categoriaDTO);
        }

        // POST: CategoriasController/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmacion(int id, IFormCollection collection)
        {
            var categoria = await _categoriaService.ObtenerCategoriaPorIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            await _categoriaService.EliminarCategoriaAsync(id);
            return RedirectToAction("Index");
        }
    }
}
