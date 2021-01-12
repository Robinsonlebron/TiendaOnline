using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaOnline.Data;
using TiendaOnline.Models;
using TiendaOnline.utility;

namespace TiendaOnline.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class OrdenController : Controller
    {
        public ApplicationDbContext db;
        SignInManager<IdentityUser> SignInManager;
        

        public OrdenController(ApplicationDbContext _db, SignInManager<IdentityUser> _SignInManager)
        {
            db = _db;
            SignInManager = _SignInManager;
        }
        [Authorize]
        public IActionResult VerOrdenes()
        {

            if (SignInManager.IsSignedIn(User)) { 
               
            string email = User.Identity.Name;
            return View(db.Orden.Where(c => c.Email == email).ToList());
            }
            return View();
            
        }
        [Authorize]
        public IActionResult Pago()
        {

            return View(db.Carrito.Include(c=>c.Producto).Where(c=>c.email==User.Identity.Name).ToList());
        }
        [Authorize]
        public IActionResult CheckOut()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckOut(Orden or)
        {
                        
            or.Email = User.Identity.Name;
          
             or.NoOrder = GetOrdenNo();
            or.Estado = "En proceso";
            db.Orden.Add(or);
            await db.SaveChangesAsync();
         

            return RedirectToAction(nameof(Pago));
        }

        public string GetOrdenNo()
        {
            int rowCount = db.Orden.ToList().Count();
            return rowCount.ToString("000");
        }
        public IActionResult Index()
        {
            return View(db.Orden.ToList());
        }

        public IActionResult Edit(int? id)
        {
          
            if (id == null)
            {
                return NotFound();

            }
            var ord = db.Orden.Find(id);
            if (ord == null)
            {
                return NotFound();
            }
            return View(ord);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(Orden ordenes)
        {
            if (ModelState.IsValid)
            {
                db.Update(ordenes);
                await db.SaveChangesAsync();
                TempData["editar"] = "La orden se actualizó correctamente!";
                return RedirectToAction(nameof(Index));
            }
            return View(ordenes);
        }

        [HttpGet]
       public IActionResult Mapas()
        {
            return View(db.Orden.ToList());
        }


        [HttpPost]
        public IActionResult Mapas(string estado)
        {
            ViewData["Estado"] = estado;
            return View(db.Orden.ToList());
        }

    }


}
