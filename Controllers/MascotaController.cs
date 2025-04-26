using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_VitalPets_PIV.Data;
using Proyecto_VitalPets_PIV.Models;

namespace Proyecto_VitalPets_PIV.Controllers
{
    public class MascotaController : Controller
    {
        //Acceso al contexto de base de datos
        private readonly ApplicationDbContext _context;

        public MascotaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lista todas las mascotas junto con su dueño
        public IActionResult Index()
        {
            var mascotas = _context.Mascotas.Include(item => item.Usuario).ToList();
            return View("List", mascotas);
        }

        // Muestra los detalles de una mascota específica
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var mascota = _context.Mascotas
                .Include(m => m.Usuario) // Incluye datos del dueño
                .FirstOrDefault(m => m.Id == id);

            if (mascota == null) return NotFound();

            return View(mascota);
        }

        // Muestra el formulario para crear una nueva mascota
        public IActionResult Create()
        {
            ViewBag.Usuarios = _context.Usuarios.ToList(); // Lista de usuarios para seleccionar al dueño
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Mascota mascota)
        {
            if (ModelState.IsValid) // Verifica que todos los campos sean válidos
            {
                _context.Add(mascota);       // Agrega la nueva mascota a la base de datos
                _context.SaveChanges();      // Guarda los cambios
                return RedirectToAction(nameof(Index)); // Redirige al listado
            }

            ViewBag.Usuarios = _context.Usuarios.ToList(); // Si hay error, se vuelve a cargar la lista de usuarios
            return View(mascota);
        }

        // Muestra el formulario para editar una mascota existente
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var mascota = _context.Mascotas.Find(id);
            if (mascota == null) return NotFound();

            ViewBag.Usuarios = _context.Usuarios.ToList(); // Lista de usuarios para editar el dueño
            return View(mascota);
        }

        // Procesa el formulario de edición
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Mascota mascota)
        {
            if (id != mascota.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(mascota);    // Actualiza los datos de la mascota
                _context.SaveChanges();      // Guarda cambios
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Usuarios = _context.Usuarios.ToList(); // Si hay error, vuelve a cargar usuarios
            return View(mascota);
        }

        // Muestra una confirmación antes de eliminar una mascota
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var mascota = _context.Mascotas
                .Include(m => m.Usuario)
                .FirstOrDefault(m => m.Id == id);

            if (mascota == null) return NotFound();

            return View(mascota);
        }

        // Confirma y elimina la mascota de la base de datos
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var mascota = _context.Mascotas.Find(id);
            _context.Mascotas.Remove(mascota); // Elimina la mascota
            _context.SaveChanges();            // Guarda cambios
            return RedirectToAction(nameof(Index));
        }
    }
}
