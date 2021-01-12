using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaOnline.Data;
using TiendaOnline.Models;
using TiendaOnline.utility;

namespace TiendaOnline.Areas.Admin.Controllers
{[Area("Admin")]
    public class CategoriasController : Controller
    {
        private ApplicationDbContext _db;

        public CategoriasController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Comida()
        {
            return View(_db.Productos.Include(c => c.ProductTypes).Include(c => c.specialTag).Where(c=>c.ProductTypes.ProductType=="Comida").ToList());
        }

        public IActionResult Electronica()
        {
            return View(_db.Productos.Include(c => c.ProductTypes).Include(c => c.specialTag).Where(c => c.ProductTypes.ProductType == "Electronica").ToList());
        }

        public IActionResult Ropas()
        {
            return View(_db.Productos.Include(c => c.ProductTypes).Include(c => c.specialTag).Where(c => c.ProductTypes.ProductType == "Ropas").ToList());
        }
        public IActionResult Deportes()
        {
            return View(_db.Productos.Include(c => c.ProductTypes).Include(c => c.specialTag).Where(c => c.ProductTypes.ProductType == "Deportes").ToList());
        }
        public IActionResult VideoJuegos()
        {
            return View(_db.Productos.Include(c => c.ProductTypes).Include(c => c.specialTag).Where(c => c.ProductTypes.ProductType == "Video Juegos").ToList());
        }
        public IActionResult Salud()
        {
            return View(_db.Productos.Include(c => c.ProductTypes).Include(c => c.specialTag).Where(c => c.ProductTypes.ProductType == "Salud").ToList());
        }
        public IActionResult CuidadoPersonal()
        {
            return View(_db.Productos.Include(c => c.ProductTypes).Include(c => c.specialTag).Where(c => c.ProductTypes.ProductType == "Cuidado Personal").ToList());
        }
        public IActionResult Calzados()
        {
            return View(_db.Productos.Include(c => c.ProductTypes).Include(c => c.specialTag).Where(c => c.ProductTypes.ProductType == "Calzados").ToList());
        }



        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _db.Productos.Include(c => c.ProductTypes).FirstOrDefault(c => c.Id == id);
            if (product == null)
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
            //var cartItem = _db.Carrito.SingleOrDefault(c => c.email == User.Identity.Name && c.ProductId == id);

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
    }
}