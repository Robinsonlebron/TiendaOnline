using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaOnline.Data;
using TiendaOnline.Models;

namespace TiendaOnline.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypesController : Controller
    {
        public ApplicationDbContext db;

        public ProductTypesController(ApplicationDbContext _db)
        {
            db = _db;
        }
        public ActionResult Index()
        {
            return View(db.ProductTypes.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                db.ProductTypes.Add(productTypes);
                await db.SaveChangesAsync();
                TempData["save"]="El tipo de producto ha sido guardado exitosamente";
                return RedirectToAction(actionName:nameof(Index));
            }
            return View(productTypes);
        }

        public IActionResult Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();

            }
            var productType = db.ProductTypes.Find(id);
            if(productType==null)
            {
                return NotFound();
            }
            return View(productType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                db.Update(productTypes);
                await db.SaveChangesAsync();
                TempData["save"] = "El tipo de producto ha sido editado exitosamente";
                return RedirectToAction(actionName: nameof(Index));
            }
            return View(productTypes);
        }


        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var productType = db.ProductTypes.Find(id);
            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(ProductTypes productTypes)
        {
            
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var productType = db.ProductTypes.Find(id);
            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Delete(int? id, ProductTypes productTypes)
        {
            if(id==null)
            {
                return NotFound();
            }
            if(id!=productTypes.Id)
            {
                return NotFound();
            }

            var productType = db.ProductTypes.Find(id);
            if (productType==null)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                db.Remove(productType);
                await db.SaveChangesAsync();
                TempData["save"] = "El tipo de producto ha sido borrado exitosamente";
                return RedirectToAction(actionName: nameof(Index));
            }
            return View(productType);
            
        }


    }
}