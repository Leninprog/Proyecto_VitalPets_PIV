using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_VitalPets_PIV.Data;
using Proyecto_VitalPets_PIV.Models;

namespace Proyecto_VitalPets_PIV.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Listado de usuarios
        public IActionResult Index()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                usuarios = _context.Usuarios.ToList();
            }
            catch (Exception)
            {
                // No hacemos nada, simplemente devolvemos una lista vacía si hay error
            }
            return View("List", usuarios);
        }

        // Crear nuevo usuario
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Usuario usuario)
        {
            if (!string.IsNullOrEmpty(usuario.Nombre) &&
                !string.IsNullOrEmpty(usuario.Correo) &&
                !string.IsNullOrEmpty(usuario.Contraseña))
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // Editar usuario
        public IActionResult Edit(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null) return NotFound();
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Usuario usuario)
        {
            if (!string.IsNullOrEmpty(usuario.Nombre) &&
                !string.IsNullOrEmpty(usuario.Correo) &&
                !string.IsNullOrEmpty(usuario.Contraseña))
            {
                _context.Usuarios.Update(usuario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // Ver detalles de un usuario
        public IActionResult Details(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null) return NotFound();
            return View(usuario);
        }

        // Eliminar usuario
        public IActionResult Delete(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null) return NotFound();
            return View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
