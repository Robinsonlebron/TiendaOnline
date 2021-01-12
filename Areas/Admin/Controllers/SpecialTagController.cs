using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TiendaOnline.Data;
using TiendaOnline.Models;

namespace TiendaOnline.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialTagController : Controller
    {
       
        public ApplicationDbContext db;

        public SpecialTagController(ApplicationDbContext _db)
        {
            db = _db;
        }
        public ActionResult Index()
        {
            return View(db.specialTags.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecialTag speciaTag)
        {
            if (ModelState.IsValid)
            {
                db.specialTags.Add(speciaTag);
                await db.SaveChangesAsync();
                TempData["save"] = "La Etiqueta de producto ha sido guardada exitosamente";
                return RedirectToAction(actionName: nameof(Index));
            }
            return View(speciaTag);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var specialtag = db.specialTags.Find(id);
            if (specialtag == null)
            {
                return NotFound();
            }
            return View(specialtag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SpecialTag ST)
        {
            if (ModelState.IsValid)
            {
                db.Update(ST);
                await db.SaveChangesAsync();
                TempData["save"] = "La etiqueta de producto ha sido editada exitosamente";
                return RedirectToAction(actionName: nameof(Index));
            }
            return View(ST);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var st = db.specialTags.Find(id);
            if (st == null)
            {
                return NotFound();
            }
            return View(st);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(SpecialTag ST)
        {

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var st = db.specialTags.Find(id);
            if (st == null)
            {
                return NotFound();
            }
            return View(st);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, SpecialTag ST)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (id != ST.Id)
            {
                return NotFound();
            }

            var spe = db.specialTags.Find(id);
            if (spe == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                db.Remove(spe);
                await db.SaveChangesAsync();
                TempData["save"] = "La etiqueta de producto ha sido borrada exitosamente";
                return RedirectToAction(actionName: nameof(Index));
            }
            return View(spe);

        }
    }
}