using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TiendaOnline.Data;
using TiendaOnline.Models;

namespace TiendaOnline.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class UserController : Controller
    {
        UserManager<IdentityUser> userManager;
        ApplicationDbContext db;
        public UserController(UserManager<IdentityUser> _userManager, ApplicationDbContext _db)
        {
           userManager = _userManager;
            db = _db;
        }

        public IActionResult Index()
        {
            return View(db.user.ToList());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ApplicationUser user)
        {
           
            if (ModelState.IsValid) {
                user.UserName = user.Email;
                var result = await userManager.CreateAsync(user, user.PasswordHash);
                if (result.Succeeded)
                {
                    TempData["Save"] = "Usuario registrado correctamente";
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
           
            
            return View();
        }
        public async Task<IActionResult> Edit(string id)
        {
            var user = db.user.FirstOrDefault(c => c.Id == id);
            if (user == null)
            {
                return NotFound();

            }
          
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationUser user)
        {
            var userInfo = db.user.FirstOrDefault(c => c.Id == user.Id);
            if (userInfo == null)
            {
                return NotFound();

            }
            userInfo.Nombre = user.Nombre;
            userInfo.Apellido = user.Apellido;
            userInfo.datebirth = user.datebirth;
            userInfo.Email = user.UserName;

            var result = await userManager.UpdateAsync(userInfo);
            if (result.Succeeded)
            {

                TempData["Save"] = "Usuario editado correctamente";
                return RedirectToAction(nameof(Index));
            }
            return View(userInfo);
        }
        public async Task<IActionResult> Detail(string id)
        {
            var user = db.user.FirstOrDefault(c => c.Id == id);
            if (user == null)
            {
                return NotFound();

            }

            return View(user);
        }
        public async Task<IActionResult> Bloquear(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = db.user.FirstOrDefault(c => c.Id == id);
            if (user == null)
            {
                return NotFound();

            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Bloquear(ApplicationUser user)
        {
            var userInfo = db.user.FirstOrDefault(c => c.Id == user.Id);
            if (userInfo == null)
            {
                return NotFound();

            }
            userInfo.LockoutEnd = DateTime.Now.AddYears(100);
            int rowAf = db.SaveChanges();
            if (rowAf > 0)
            {
                TempData["Save"] = "Usuario Bloqueado exitosamente";
                return RedirectToAction(nameof(Index));
            }
           
           
            return View(userInfo);
        }

        public async Task<IActionResult> Active(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = db.user.FirstOrDefault(c => c.Id == id);
            if (user == null)
            {
                return NotFound();

            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Active(ApplicationUser user)
        {
            var userInfo = db.user.FirstOrDefault(c => c.Id == user.Id);
            if (userInfo == null)
            {
                return NotFound();

            }
            userInfo.LockoutEnd = DateTime.Now.AddDays(-1);
            int rowAf = db.SaveChanges();
            if (rowAf > 0)
            {
                TempData["Save"] = "Usuario Habilitado exitosamente";
                return RedirectToAction(nameof(Index));
            }


            return View(userInfo);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = db.user.FirstOrDefault(c => c.Id == id);
            if (user == null)
            {
                return NotFound();

            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ApplicationUser user)
        {
            var userInfo = db.user.FirstOrDefault(c => c.Id == user.Id);
            if (userInfo == null)
            {
                return NotFound();

            }
            db.user.Remove(userInfo);
            int rowAf = db.SaveChanges();
            if (rowAf > 0)
            {
                TempData["Save"] = "Usuario eliminado exitosamente";
                return RedirectToAction(nameof(Index));
            }


            return View(userInfo);
        }
    }
}