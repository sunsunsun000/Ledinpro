using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ledinpro.Data;
using Ledinpro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Ledinpro.Controllers
{
    public class CarouselsController : BaseController
    {
        public CarouselsController(LedinproContext context, IHostingEnvironment env) : base(context, env)
        {
        }

        // GET: Carousels
        public async Task<IActionResult> Index()
        {
            return View(await _ledinproContext.Carousels.ToListAsync());
        }

        // GET: Carousels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carousel = await _ledinproContext.Carousels
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
            GenerateProductList();

            return View();
        }

        // POST: Carousels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Title,Description,SortNumber,Type,RelativeProductId,Id")] Carousel carousel, 
                                                IFormFile picturePath, IFormFile mobilePicturePath)
        {
            if (ModelState.IsValid)
            {
                var files = new List<IFormFile>() { picturePath, mobilePicturePath };
                if (await UploadFiles(carousel, files) == true)
                {
                    _ledinproContext.Add(carousel);
                    await _ledinproContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            GenerateProductList();
            return View(carousel);
        }

        // GET: Carousels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carousel = await _ledinproContext.Carousels.SingleOrDefaultAsync(m => m.Id == id);
            if (carousel == null)
            {
                return NotFound();
            }

            GenerateProductList();

            return View(carousel);
        }

        // POST: Carousels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Title,Description,PicturePath,MobilePicturePath,SortNumber,Type,RelativeProductId,Id")] Carousel carousel,
                                              IFormFile picturePath, IFormFile mobilePicturePath)
        {
            if (id != carousel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var files = new List<IFormFile>() { picturePath, mobilePicturePath };
                if (await UploadFiles(carousel, files) == false)
                {
                    return View(carousel);
                }

                try
                {
                    _ledinproContext.Update(carousel);
                    await _ledinproContext.SaveChangesAsync();
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carousel = await _ledinproContext.Carousels
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carousel = await _ledinproContext.Carousels.SingleOrDefaultAsync(m => m.Id == id);
            _ledinproContext.Carousels.Remove(carousel);
            await _ledinproContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarouselExists(int id)
        {
            return _ledinproContext.Carousels.Any(e => e.Id == id);
        }

        private void GenerateProductList()
        {
            var productList = (from p in _ledinproContext.Products
                              select p).ToList();
            productList.Insert(0, new Product(){ Id = 0, Name = "无链接"});

            var productSelectList = new SelectList(productList,"Id","Name");
            ViewBag.ProductList = productSelectList;
        }

        private async Task<bool> UploadFiles(Carousel carousel, List<IFormFile> files)
        {
            int index = 0;
            foreach (var f in files)
            {
                // 如果没有选择文件，继续执行循环
                if (f == null)
                {
                    index++;
                    continue;
                }

                string filePath = "upload/" + carousel.Id.ToString();
                string fileName = filePath  + "/" + f.FileName;
                string fullFilePath = Path.Combine(_env.WebRootPath, fileName);
                string fullFilePathDir = Path.Combine(_env.WebRootPath, filePath);
                try
                {
                    if (index == 0)
                    {
                        carousel.PicturePath = "/" + fileName;
                    }
                    else if (index == 1)
                    {
                        carousel.MobilePicturePath = "/" + fileName;
                    }
                    else
                    {
                        return false;
                    }

                    if (Directory.Exists(fullFilePathDir) == false)
                    {
                        Directory.CreateDirectory(fullFilePathDir);
                    }

                    using (var stream = new FileStream(fullFilePath, FileMode.Create, FileAccess.ReadWrite))
                    {
                        await f.CopyToAsync(stream);
                    }
                }
                catch
                {
                    return false;
                }

                index++;
            }

            return true;
        }
    }
}
