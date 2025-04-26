using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_VitalPets_PIV.Data;
using Proyecto_VitalPets_PIV.Models;

namespace Proyecto_VitalPets_PIV.Controllers
{
    public class VeterinarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VeterinarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Listado de veterinarios
        public IActionResult Index()
        {
            var veterinarios = _context.Veterinarios.ToList();
            return View("List", veterinarios);
        }

        // Crear nuevo veterinario
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Veterinario veterinario)
        {
            if (ModelState.IsValid)
            {
                _context.Veterinarios.Add(veterinario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(veterinario);
        }

        // Editar veterinario
        public IActionResult Edit(int id)
        {
            var veterinario = _context.Veterinarios.Find(id);
            if (veterinario == null) return NotFound();
            return View(veterinario);
        }

        [HttpPost]
        public IActionResult Edit(Veterinario veterinario)
        {
            if (ModelState.IsValid)
            {
                _context.Veterinarios.Update(veterinario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(veterinario);
        }

        // Ver detalles de un veterinario
        public IActionResult Details(int id)
        {
            var veterinario = _context.Veterinarios.FirstOrDefault(v => v.Id == id);
            if (veterinario == null) return NotFound();
            return View(veterinario);
        }

        // Eliminar veterinario
        public IActionResult Delete(int id)
        {
            var veterinario = _context.Veterinarios.Find(id);
            if (veterinario == null) return NotFound();
            return View(veterinario);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var veterinario = _context.Veterinarios.Find(id);
            _context.Veterinarios.Remove(veterinario);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

