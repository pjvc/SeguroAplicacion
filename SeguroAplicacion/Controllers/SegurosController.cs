using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeguroAplicacion.Models;
using SeguroAplicacion.Models.ViewModels;

namespace SeguroAplicacion.Controllers
{
    public class SegurosController : Controller
    {
        private readonly SegurosContext _context;
        private object model;

        public SegurosController(SegurosContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Seguros.ToListAsync());
        }
        public IActionResult Create()
        {
            ViewData["NombreSeguro"] = new SelectList(_context.Seguros, "NombreSeguro", "CodigoSeguro", "SumaAsegurada", "Prima");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(SegurosViewModel model)
        {
            if (ModelState.IsValid)
            {
                var seguro = new Seguro()
                {
                    NombreSeguro = model.Name,
                    CodigoSeguro = model.CodigoSeguro,
                    SumaAsegurada = model.SumaAsegurada,
                    Prima = model.Prima,

                };
                _context.Add(seguro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Nombre"] = new SelectList(_context.Seguros, "NombreSeguro", "CodigoSeguro", "SumaAsegurada", "Prima");
            return View();
        }
       
    }
}
