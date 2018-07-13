using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ledinpro.Data;
using Ledinpro.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;

namespace Ledinpro.Controllers
{
    [Authorize(Roles = "内部员工,管理员")]
    public class SaleContactInfoController : BaseController
    {
        public SaleContactInfoController(LedinproContext context, IHostingEnvironment env) : base(context, env)
        {

        }

        // GET: SaleContactInfo
        public async Task<IActionResult> Index()
        {
            return View(await _ledinproContext.SaleContactInfos.ToListAsync());
        }

        // GET: SaleContactInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleContactInfo = await _ledinproContext.SaleContactInfos
                .SingleOrDefaultAsync(m => m.Id == id);
            if (saleContactInfo == null)
            {
                return NotFound();
            }

            return View(saleContactInfo);
        }

        // GET: SaleContactInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SaleContactInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Phone,CellPhone,Email,Skype,IsShow,Id")] SaleContactInfo saleContactInfo)
        {
            if (ModelState.IsValid)
            {
                saleContactInfo.CreateDateTime = DateTime.Now;
                _ledinproContext.Add(saleContactInfo);
                await _ledinproContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(saleContactInfo);
        }

        // GET: SaleContactInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleContactInfo = await _ledinproContext.SaleContactInfos.SingleOrDefaultAsync(m => m.Id == id);
            if (saleContactInfo == null)
            {
                return NotFound();
            }
            return View(saleContactInfo);
        }

        // POST: SaleContactInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Phone,CellPhone,Email,Skype,IsShow,Id")] SaleContactInfo saleContactInfo)
        {
            if (id != saleContactInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ledinproContext.Update(saleContactInfo);
                    await _ledinproContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleContactInfoExists(saleContactInfo.Id))
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
            return View(saleContactInfo);
        }

        // GET: SaleContactInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleContactInfo = await _ledinproContext.SaleContactInfos
                .SingleOrDefaultAsync(m => m.Id == id);
            if (saleContactInfo == null)
            {
                return NotFound();
            }

            return View(saleContactInfo);
        }

        // POST: SaleContactInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saleContactInfo = await _ledinproContext.SaleContactInfos.SingleOrDefaultAsync(m => m.Id == id);
            _ledinproContext.SaleContactInfos.Remove(saleContactInfo);
            await _ledinproContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleContactInfoExists(int id)
        {
            return _ledinproContext.SaleContactInfos.Any(e => e.Id == id);
        }
    }
}
