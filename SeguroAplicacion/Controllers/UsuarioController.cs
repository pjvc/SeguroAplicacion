using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SeguroAplicacion.Models;
using SeguroAplicacion.Models.ViewModels;

namespace SeguroAplicacion.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly SegurosContext _context;
        private object model;

        public UsuarioController(SegurosContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }
        public IActionResult Create()
        {
            ViewData["Nombre"] = new SelectList(_context.Usuarios, "Cedula", "Cliente","Telefono","Edad");
            return View();    
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario()
                {
                    Cliente = model.Name,
                    Cedula = model.Cedula,
                    Telefono = model.Telefono,
                    Edad = model.Edad,
                    
                };
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Nombre"] = new SelectList(_context.Usuarios, "Cedula", "Cliente", "Telefono", "Edad");
            return View();
        }
    }
}
