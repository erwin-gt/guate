using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Multiservicios.Data;
using Multiservicios.Models;
using Multiservicios.Models.ViewModels;

namespace Multiservicios.Areas.Inventario.Controllers
{
    [Area("Inventario")]
    public class ActivoController : Controller
    {

        private readonly ApplicationDbContext _db;

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public ActivoItemViewModel ActivoItemVm { get; set; }

        public ActivoController(ApplicationDbContext db)
        {
            _db = db;
            ActivoItemVm = new ActivoItemViewModel()
            {
                Categoria = _db.Categoria,
                Marca = _db.Marca,
                Proveedor = _db.Proveedor,
                Activo = new Models.Activo()
            };
        }

        // GET INDEX

        public async Task<IActionResult> Index()
        {
            var activoItems = await _db.Activo.Include(s => s.Marca).Include(s => s.Categoria).Include(s => s.Proveedor).ToListAsync();
            return View(activoItems);
        }

        //GET CREAR

        public IActionResult Create()
        {
            

          
            return View(ActivoItemVm);


        }

        //POST - CREAR
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Activo_Categoria_Marca_ProveedorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var doesActivoExists = _db.Activo.Include(s => s.Marca).Include(s => s.Categoria).Include(s => s.Proveedor).Where(s => s.Nombre == model.Activo.Nombre && s.Marca.Id == model.Activo.MarcaId && s.Categoria.Id == model.Activo.CategoriaId && s.Proveedor.id == model.Activo.ProveedorId);
                if (doesActivoExists.Count() > 0)
                {
                    //Error
                    //////////////////////////
                    StatusMessage = "Error: La marca: " + doesActivoExists.First().Marca.Nombre + " ya existe, ingrese una marca diferente";
                }
                else
                {
                    _db.Activo.Add(model.Activo);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            Activo_Categoria_Marca_ProveedorViewModel modelVm = new Activo_Categoria_Marca_ProveedorViewModel()
            {
                CategoriaList = await _db.Categoria.ToListAsync(),
                MarcaList = await _db.Marca.ToListAsync(),
                ProveedorList = await _db.Proveedor.ToListAsync(),
                Activo = model.Activo,
                ActivoList = await _db.Activo.OrderBy(p => p.Nombre).Select(p => p.Nombre).ToListAsync(),
                StatusMessage = StatusMessage

            };
            return View(modelVm);
        }
        
                

        //GET - EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var AreaTrabajo = await _db.AreaTrabajo.SingleOrDefaultAsync(m => m.Id == id);

            if (AreaTrabajo == null)
            {
                return NotFound();
            }

            DepartamentoAndAreaTrabajoViewModel model = new DepartamentoAndAreaTrabajoViewModel()
            {
                DepartamentoList = await _db.Departamento.ToListAsync(),
                AreaTrabajo = AreaTrabajo,
                AreaTrabajoList = await _db.AreaTrabajo.OrderBy(p => p.Nombre).Select(p => p.Nombre).Distinct().ToListAsync()
            };

            return View(model);

        }




    }
}
