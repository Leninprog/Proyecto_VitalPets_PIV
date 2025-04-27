using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_VitalPets_PIV.Data;
using Proyecto_VitalPets_PIV.Models;

//Commit de prueba 

namespace Proyecto_VitalPets_PIV.Controllers
{
    public class CitaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CitaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var citas = _context.Citas.Include(c => c.Mascota).ToList();
            return View("List", citas);
        }

        public IActionResult Create()
        {
            ViewBag.Mascotas = _context.Mascotas.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cita cita)
        {
            if (ModelState.IsValid)
            {
                _context.Citas.Add(cita);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Mascotas = _context.Mascotas.ToList();
            return View(cita);
        }

        public IActionResult Edit(int id)
        {
            var cita = _context.Citas.Find(id);
            if (cita == null) return NotFound();
            ViewBag.Mascotas = _context.Mascotas.ToList();
            return View(cita);
        }

        [HttpPost]
        public IActionResult Edit(Cita cita)
        {
            if (ModelState.IsValid)
            {
                _context.Citas.Update(cita);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Mascotas = _context.Mascotas.ToList();
            return View(cita);
        }

        public IActionResult Details(int id)
        {
            var cita = _context.Citas.Include(c => c.Mascota).FirstOrDefault(c => c.Id == id);
            if (cita == null) return NotFound();
            return View(cita);
        }

        public IActionResult Delete(int id)
        {
            var cita = _context.Citas.Include(c => c.Mascota).FirstOrDefault(c => c.Id == id);
            if (cita == null) return NotFound();
            return View(cita);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var cita = _context.Citas.Find(id);
            _context.Citas.Remove(cita);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

