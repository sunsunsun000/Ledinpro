using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Ledinpro.Data;
using Ledinpro.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Ledinpro.Controllers
{
    public class ProductScenesController : BaseController
    {
        public ProductScenesController(LedinproContext context, IHostingEnvironment env) : base(context, env)
        {
            
        }

        // GET: ProductScenes
        public async Task<IActionResult> Index()
        {
            return View(await _ledinproContext.ProductScenes.ToListAsync());
        }

        // GET: ProductScenes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productScene = await _ledinproContext.ProductScenes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (productScene == null)
            {
                return NotFound();
            }

            return View(productScene);
        }

        // GET: ProductScenes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductScenes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,PicturePath,ProductApplicationScene,MobilePicturePath,Type")] ProductScene productScene,
                                                IFormFile picture, IFormFile mobilePicture, IFormFile backgroundPicture)
        {
            if (ModelState.IsValid)
            {
                bool isUploadFileSuccess = await UploadFiles(productScene, new List<IFormFile>() { picture, mobilePicture, backgroundPicture });
                if (isUploadFileSuccess == false)
                {
                    return View(productScene);
                }

                _ledinproContext.Add(productScene);
                await _ledinproContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productScene);
        }

        // GET: ProductScenes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productScene = await _ledinproContext.ProductScenes.SingleOrDefaultAsync(m => m.Id == id);
            if (productScene == null)
            {
                return NotFound();
            }
            return View(productScene);
        }

        // POST: ProductScenes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,PicturePath,ProductApplicationScene,MobilePicturePath,Type,Id")] ProductScene productScene,
                                              IFormFile picture, IFormFile mobilePicture, IFormFile backgroundPicture)
        {
            if (id != productScene.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (await UploadFiles(productScene, new List<IFormFile>() { picture, mobilePicture, backgroundPicture }) == false)
                {
                    return View(productScene);
                }
                try
                {
                    _ledinproContext.Update(productScene);
                    await _ledinproContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductSceneExists(productScene.Id))
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
            return View(productScene);
        }

        // GET: ProductScenes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productScene = await _ledinproContext.ProductScenes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (productScene == null)
            {
                return NotFound();
            }

            return View(productScene);
        }

        // POST: ProductScenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productScene = await _ledinproContext.ProductScenes.SingleOrDefaultAsync(m => m.Id == id);
            _ledinproContext.ProductScenes.Remove(productScene);
            await _ledinproContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductSceneExists(int id)
        {
            return _ledinproContext.ProductScenes.Any(e => e.Id == id);
        }

        private async Task<bool> UploadFiles(ProductScene productScene, List<IFormFile> files)
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

                string filePath = Path.Combine(_env.WebRootPath, "upload/" + f.FileName);
                string fileName = Path.Combine("/upload/" + f.FileName);
                try
                {
                    if (index == 0)
                    {
                        productScene.PicturePath = fileName;
                    }
                    else if (index == 1)
                    {
                        productScene.MobilePicturePath = fileName;
                    }
                    else if (index == 2)
                    {
                        productScene.ProductApplicationScene = fileName;
                    }

                    using (var stream = new FileStream(filePath, FileMode.Create))
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
