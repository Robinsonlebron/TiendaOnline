using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TiendaOnline.Data;

namespace TiendaOnline.Areas.Admin.Controllers
    {[Area("Admin")]
    public class CumpleañosController : Controller
    {
        ApplicationDbContext db;

        public CumpleañosController(ApplicationDbContext _db)
        {
           db = _db;
        }

        public IActionResult Enero()
        {
            return View(db.user.Where(c=>c.datebirth.Month==01).ToList());
        }
        public IActionResult Febrero()
        {
            return View(db.user.Where(c => c.datebirth.Month == 02).ToList());
        }
        public IActionResult Marzo()
        {
            return View(db.user.Where(c => c.datebirth.Month == 03).ToList());
        }
        public IActionResult Abril()
        {
            return View(db.user.Where(c => c.datebirth.Month == 04).ToList());
        }
        public IActionResult Mayo()
        {
            return View(db.user.Where(c => c.datebirth.Month == 05).ToList());
        }
        public IActionResult Junio()
        {
            return View(db.user.Where(c => c.datebirth.Month == 06).ToList());
        }
        public IActionResult Julio()
        {
            return View(db.user.Where(c => c.datebirth.Month == 07).ToList());
        }
        public IActionResult Agosto()
        {
            return View(db.user.Where(c => c.datebirth.Month == 08).ToList());
        }
        public IActionResult Septiembre()
        {
            return View(db.user.Where(c => c.datebirth.Month == 09).ToList());
        }
        public IActionResult Octubre()
        {
            return View(db.user.Where(c => c.datebirth.Month == 10).ToList());
        }
        public IActionResult Noviembre()
        {
            return View(db.user.Where(c => c.datebirth.Month == 11).ToList());
        }
        public IActionResult Diciembre()
        {
            return View(db.user.Where(c => c.datebirth.Month == 12).ToList());
        }


    }
}