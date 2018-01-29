using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ledinpro.Data;
using Ledinpro.Models;

namespace Ledinpro.Controllers
{
    public class CarouselsController : Controller
    {
        private readonly LedinproContext _context;

        public CarouselsController(LedinproContext context)
        {
            _context = context;
        }

        // GET: Carousels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carousels.ToListAsync());
        }

        // GET: Carousels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carousel = await _context.Carousels
                .SingleOrDefaultAsync(m => m.Id == id);
            if (carousel == null)
            {
                return NotFound();
            }

            return View(carousel);
        }

        // GET: Carousels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carousels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Title,Description,PicturePath,MobilePicturePath,SortNumber,RelativeProductId,Id,CreateUserName,CreateDateTime,LastEditUserName,LastEditDateTime")] Carousel carousel)
        {
            if (ModelState.IsValid)
            {
                carousel.Id = Guid.NewGuid();
                _context.Add(carousel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carousel);
        }

        // GET: Carousels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carousel = await _context.Carousels.SingleOrDefaultAsync(m => m.Id == id);
            if (carousel == null)
            {
                return NotFound();
            }
            return View(carousel);
        }

        // POST: Carousels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Title,Description,PicturePath,MobilePicturePath,SortNumber,RelativeProductId,Id,CreateUserName,CreateDateTime,LastEditUserName,LastEditDateTime")] Carousel carousel)
        {
            if (id != carousel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carousel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarouselExists(carousel.Id))
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
            return View(carousel);
        }

        // GET: Carousels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carousel = await _context.Carousels
                .SingleOrDefaultAsync(m => m.Id == id);
            if (carousel == null)
            {
                return NotFound();
            }

            return View(carousel);
        }

        // POST: Carousels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var carousel = await _context.Carousels.SingleOrDefaultAsync(m => m.Id == id);
            _context.Carousels.Remove(carousel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarouselExists(Guid id)
        {
            return _context.Carousels.Any(e => e.Id == id);
        }
    }
}
