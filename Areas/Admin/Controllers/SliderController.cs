using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using TiendaOnline.Areas.Admin.Model;
using TiendaOnline.Data;
using TiendaOnline.Models;

namespace TiendaOnline.Areas.Admin.Controllers
{ 
   [Area("Admin")]
    public class SliderController : Controller
    {
        public ApplicationDbContext db;
        public IHostingEnvironment env;

        public SliderController(ApplicationDbContext _db, IHostingEnvironment _env)
        {
            db = _db;
            env = _env;
        }
        public IActionResult Index()
        {
            return View(db.Slider.ToList());
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Slider sl ,IFormFile image)
        {
           
            if (ModelState.IsValid)
            {
                if (image != null)
                {

                    var name = Path.Combine(env.WebRootPath + "/Slider", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    sl.image = "Slider/" + image.FileName;
                   
                }

              
                db.Slider.Add(sl);
                await db.SaveChangesAsync();
                TempData["save"] = "Imagen guardada exitosamente";
                return RedirectToAction(actionName: nameof(Index));
            }
            return View(sl);
        }


       


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var slide = db.Slider.Find(id);
            if (slide == null)
            {
                return NotFound();
            }
            return View(slide);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, Slider slide)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (id != slide.Id)
            {
                return NotFound();
            }

            var sl = db.Slider.Find(id);
            if (sl == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                db.Remove(sl);
                await db.SaveChangesAsync();
                TempData["save"] = "La foto ha sido borrado exitosamente";
                return RedirectToAction(actionName: nameof(Index));
            }
            return View(sl);

        }



        
    }
}