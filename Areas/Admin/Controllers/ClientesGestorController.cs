using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaOnline.Data;
using TiendaOnline.Models;

namespace TiendaOnline.Areas.Customer.Controllers
{
    [Area("Admin")]
    public class ClientesGestorController : Controller
    {
        UserManager<IdentityUser> userManager;
        ApplicationDbContext db;
        public ClientesGestorController(UserManager<IdentityUser> _userManager, ApplicationDbContext _db)
        {
           userManager = _userManager;
            db = _db;
        }

        public IActionResult Index()
        {
           
            return View(db.user.ToList());
           

        }

        public async Task<IActionResult> VerCompras(string id)
        {
            var user = db.user.FirstOrDefault(c => c.Id == id);

            var product = db.Carrito.Include(c => c.Producto).Where(c => c.email == user.UserName).ToList();
            return View(product);
        }
      
    }
}