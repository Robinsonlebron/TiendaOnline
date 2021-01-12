using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TiendaOnline.Areas.Admin.Model;
using TiendaOnline.Data;
using TiendaOnline.Data.Migrations;

namespace TiendaOnline.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> roleManager;
        UserManager<IdentityUser> userManager;
        
        ApplicationDbContext _db;

        //public UserManager<IdentityRole> User { get; }

        public RoleController(RoleManager<IdentityRole> _roleManager, ApplicationDbContext db, UserManager<IdentityUser> _userManager)
        {
            roleManager = _roleManager;
            _db = db;
            userManager = _userManager;
        }

        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();
            ViewBag.Roles = roles;
            return View();
        }

        public async Task<IActionResult>create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> create(string name)
        {

            IdentityRole role = new IdentityRole();
            role.Name = name;
            var isExist = await roleManager.RoleExistsAsync(role.Name);
            if(isExist)
            {
                ViewBag.mgs = "Este nombre de rol ya existe";
                ViewBag.name = name;
                return View();
            }
            var result = await roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                TempData["Save"] = "El rol ha sido guardado exitosamente";
                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        public async Task<IActionResult> Edit(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if(role== null)
            {
                return NotFound();
            }
            ViewBag.id = role.Id;
            ViewBag.name = role.Name;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, string name)
        {

            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            role.Name = name;
            var isExist = await roleManager.RoleExistsAsync(role.Name);
            if (isExist)
            {
                ViewBag.mgs = "Este nombre de rol ya existe";
                ViewBag.name = name;
                return View();
            }
            var result = await roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                TempData["Save"] = "El rol ha sido modificado correctamente";
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            ViewBag.id = role.Id;
            ViewBag.name = role.Name;
            return View();
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            var result = await roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                TempData["Save"] = "El rol ha sido eliminado correctamente";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Assign()
        {
            ViewData["UserId"] = new SelectList(_db.user.Where(f=>f.LockoutEnd<DateTime.Now|| f.LockoutEnd==null).ToList(), "Id", "UserName") ;
            ViewData["RoleId"] = new SelectList(roleManager.Roles.ToList(), "Name", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Assign(RoleUservm vm)
        {
            var user = _db.user.FirstOrDefault(c => c.Id == vm.UserId);
            var checking = await userManager.IsInRoleAsync(user, vm.RoleId);
            if (checking)
            {
                ViewBag.msg = "Este Usuario ya tiene asignado este rol";
                ViewData["UserId"] = new SelectList(_db.user.Where(f => f.LockoutEnd < DateTime.Now || f.LockoutEnd == null).ToList(), "Id", "UserName");
                ViewData["RoleId"] = new SelectList(roleManager.Roles.ToList(), "Name", "Name");
                return View();
            }



             var role = await userManager.AddToRoleAsync(user, vm.RoleId);
            if (role.Succeeded)
            {
                TempData["Save"] = "El rol ha sido asignado correctamente";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult AssignUserRole()
        {
            var result = from ur in _db.UserRoles
                         join r in _db.Roles on ur.RoleId equals r.Id
                         join a in _db.user on ur.UserId equals a.Id

                         select new UserRoleMaping()
                         {
                             UserId = ur.UserId,
                             RoleId = ur.RoleId,
                             UserName = a.UserName,
                             RoleName = r.Name
                         };

            ViewBag.UserRole = result;

            return View();
        }
    }
}