using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TiendaOnline.Data;
using TiendaOnline.Models;

namespace TiendaOnline.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductoController : Controller
    {
        public ApplicationDbContext db;
        public IHostingEnvironment env;

        public ProductoController(ApplicationDbContext _db, IHostingEnvironment _env)
        {
            db = _db;
            env = _env;
        }
        public IActionResult Index()
        {
            return View(db.Productos.Include(c => c.ProductTypes).Include(f => f.specialTag).ToList());
        }

        //POST INDEX ACTION
        [HttpPost]
        public IActionResult Index(int? BajaCantidad, int?  altaCantidad)
        {
            var product = db.Productos.Include(env => env.ProductTypes).Include(env => env.specialTag).Where(env => env.Price>=BajaCantidad&&env.Price<=altaCantidad).ToList();

            if (BajaCantidad == null || altaCantidad == null)
            {
                product = db.Productos.Include(env => env.ProductTypes).Include(env => env.specialTag).ToList();
            }
            return View(product);
        }

        public IActionResult Create()
        {
            ViewData["ProductTypeId"] = new SelectList(db.ProductTypes.ToList(), "Id", "ProductType");
            ViewData["specialTagId"] = new SelectList(db.specialTags.ToList(), "Id", "specialTag");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Producto prod, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                var BuscarProducto = db.Productos.FirstOrDefault(env => env.Name == prod.Name);
                if (BuscarProducto != null)
                {
                    ViewBag.message = "Este producto ya existe";
                    ViewData["ProductTypeId"] = new SelectList(db.ProductTypes.ToList(), "Id", "ProductType");
                    ViewData["specialTagId"] = new SelectList(db.specialTags.ToList(), "Id", "specialTag");
                    return View(prod);
                }
                if (image != null)
                {
                  
                    var name = Path.Combine(env.WebRootPath + "/Imagen", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    prod.image = "Imagen/" + image.FileName;
                }
                if (image == null)
                {
                    prod.image = "Imagen/nofoto.jpg";
                }
               
                db.Productos.Add(prod);
                await db.SaveChangesAsync();
                TempData["save"] = "El producto ha sido guardado exitosamente";
                return RedirectToAction(actionName: nameof(Index));
            }
            return View(prod);
        }

        //editar get
        public IActionResult Edit(int? id)
        {
            ViewData["ProductTypeId"] = new SelectList(db.ProductTypes.ToList(), "Id", "ProductType");
            ViewData["specialTagId"] = new SelectList(db.specialTags.ToList(), "Id", "specialTag");
            if (id == null)
            {
                return NotFound();

            }
            var product = db.Productos.Include(c => c.ProductTypes).Include(f => f.specialTag).FirstOrDefault(c => c.Id== id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Producto produ, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    if (image != null)
                    {
                        var name = Path.Combine(env.WebRootPath + "/Imagen", Path.GetFileName(image.FileName));
                        await image.CopyToAsync(new FileStream(name, FileMode.Create));
                        produ.image = "Imagen/" + image.FileName;
                    }
                    if (image == null)
                    {
                        produ.image = "Imagen/nofoto.jpg";
                    }
                    db.Update(produ);
                    await db.SaveChangesAsync();
                    TempData["save"] = "El producto ha sido editado exitosamente";
                    return RedirectToAction(actionName: nameof(Index));
                }
            }
            return View(produ);
        }
        public IActionResult Details(int? id)
        {
            ViewData["ProductTypeId"] = new SelectList(db.ProductTypes.ToList(), "Id", "ProductType");
            ViewData["specialTagId"] = new SelectList(db.specialTags.ToList(), "Id", "specialTag");
            if (id == null)
            {
                return NotFound();

            }
            var product = db.Productos.Include(c => c.ProductTypes).Include(f => f.specialTag).FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(Producto product)
        {

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var product = db.Productos.Include(c => c.ProductTypes).Include(f => f.specialTag).Where(c=>c.Id==id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteProduc(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = db.Productos.FirstOrDefault(c => c.Id==id);
            if (product == null)
            {
                return NotFound();
            }

                db.Productos.Remove(product);
                await db.SaveChangesAsync();
                TempData["save"] = "El producto ha sido borrado exitosamente";
                return RedirectToAction(actionName: nameof(Index));
            

        }



    }
}