using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Ledinpro.Data;
using Ledinpro.Models;

namespace Ledinpro.Controllers
{
    [AllowAnonymous]
    public class UserManagerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UserManagerController(ApplicationDbContext context, 
        UserManager<ApplicationUser> userManager, 
        RoleManager<ApplicationRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: UserManager
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApplicationUser.ToListAsync());
        }

        // GET: UserManager/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser
                .SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        // GET: UserManager/Create
        public IActionResult Create()
        {
            return RedirectToAction("Register", "Account");
        }

        // POST: UserManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Gender,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                applicationUser.Id = Guid.NewGuid();
                _context.Add(applicationUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applicationUser);
        }

        // GET: UserManager/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            return View(applicationUser);
        }

        // POST: UserManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Gender,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser)
        {
            if (id != applicationUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(applicationUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(applicationUser);
        }

        // GET: UserManager/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser
                .SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        // POST: UserManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            _context.ApplicationUser.Remove(applicationUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserExists(Guid id)
        {
            return _context.ApplicationUser.Any(e => e.Id == id);
        }

        public async Task<IActionResult> SetUserRole(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var userRoles = await _userManager.GetRolesAsync(user);

            ViewBag.UserRols = userRoles;
            ViewBag.Id = id;
            return View();
        }

        public async Task<IActionResult> CreateUserRole(Guid id)
        {
            // 角色列表
            var roles = await _roleManager.Roles.Where(r => r.Id != id).ToListAsync();
            var user = await _userManager.FindByIdAsync(id.ToString());
            var userRoles = await _userManager.GetRolesAsync(user);
            foreach(var roleName in userRoles)
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                roles.Remove(role);
            }

            var rolesList = new SelectList(roles);

            ViewBag.RolesList = rolesList;
            ViewBag.Id = id;

            return View();
        }

        public async Task<IActionResult> AddUserRole(string roleName, Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return NotFound();
            }

            await _userManager.AddToRoleAsync(user, roleName);

            var userRoles = await _userManager.GetRolesAsync(user);

            ViewBag.UserRols = userRoles;
            ViewBag.Id = id;
            return View("SetUserRole");
        }

        public async Task<IActionResult> RemoveUserRole(string roleName, Guid id)
        {
                        if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return NotFound();
            }

            await _userManager.RemoveFromRoleAsync(user, roleName);

            var userRoles = await _userManager.GetRolesAsync(user);

            ViewBag.UserRols = userRoles;
            ViewBag.Id = id;
            return View("SetUserRole");
        }
    }
}
