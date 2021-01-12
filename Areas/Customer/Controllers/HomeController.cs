using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TiendaOnline.Data;
using TiendaOnline.Models;
using TiendaOnline.utility;

namespace TiendaOnline.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private ApplicationDbContext _db;
        SignInManager<IdentityUser> SignInManager;

        public HomeController(ApplicationDbContext db, SignInManager<IdentityUser> _SignInManager)
        {
            _db = db;
            SignInManager = _SignInManager;
        }
        public IActionResult Index()
        {
            ProductoAndSlider ps = new ProductoAndSlider();
            ps.productos = _db.Productos.ToList();
            ps.sliders = _db.Slider.ToList();
            return View(ps);
        }

       

        public ActionResult Details(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var product = _db.Productos.Include(c => c.ProductTypes).FirstOrDefault(c => c.Id == id);
            if(product==null)
            {
                return NotFound();

            }
            return View(product);
        }
        [Authorize]
        [HttpPost]
        [ActionName("Details")]
        public async Task<ActionResult> ProductDetails(int? id)
        {
            Carrito cr = new Carrito();
            List<Producto> producto = _db.Productos.Include(c => c.ProductTypes).Where(c => c.Id == id).ToList();
           
                if (producto != null)
                {
                    foreach (var prod in producto)
                    {
                        cr.ProductId = prod.Id;
                    }
                }
               
                    cr.email = User.Identity.Name;
                
                cr.Cantidad = 1;

                await _db.Carrito.AddAsync(cr);
           
            _db.SaveChanges();


            return View();

            
        }

       
        public async Task<IActionResult> Remove(int? id, Carrito ca)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (id != ca.Id)
            {
                return NotFound();
            }

            var car = _db.Carrito.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Remove(car);
                await _db.SaveChangesAsync();
                TempData["save"] = "El producto ha sido borrado del carrito exitosamente";
                return RedirectToAction(actionName: nameof(Cart));
            }
            return View(car);

        }
        
        [Authorize]
        public IActionResult Cart()
        {
            
            var product = _db.Carrito.Include(c => c.Producto).Where(c => c.email == User.Identity.Name).ToList();
            return View(product);
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
