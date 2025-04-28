using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_VitalPets_PIV.Data;
using Proyecto_VitalPets_PIV.Models;

namespace Proyecto_VitalPets_PIV.Controllers
{
    public class MascotaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MascotaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Listar todas las mascotas con su dueño
        public IActionResult Index()
        {
            var mascotas = _context.Mascotas.Include(m => m.Usuario).ToList();
            return View("List", mascotas);
        }

        // Ver detalles de una mascota
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var mascota = _context.Mascotas
                .Include(m => m.Usuario)
                .FirstOrDefault(m => m.Id == id);

            if (mascota == null) return NotFound();

            return View(mascota);
        }

        // Mostrar formulario para crear mascota
        public IActionResult Create()
        {
            ViewBag.Usuarios = _context.Usuarios.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mascota);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Usuarios = _context.Usuarios.ToList();
            return View(mascota);
        }

        // Mostrar formulario para editar mascota
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var mascota = _context.Mascotas.Find(id);
            if (mascota == null) return NotFound();

            ViewBag.Usuarios = _context.Usuarios.ToList(); 
            return View(mascota);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Mascota mascota)
        {
            if (id != mascota.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(mascota);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Usuarios = _context.Usuarios.ToList();
            return View(mascota);
        }

        // Mostrar confirmación para eliminar mascota
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var mascota = _context.Mascotas
                .Include(m => m.Usuario)
                .FirstOrDefault(m => m.Id == id);

            if (mascota == null) return NotFound();

            return View(mascota);
        }

        // Confirmar y eliminar mascota
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var mascota = _context.Mascotas.Find(id);
            _context.Mascotas.Remove(mascota);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
