using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Ledinpro.Data;
using Ledinpro.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace Ledinpro.Controllers
{
    public class ProductsController : BaseController
    {
        public ProductsController(LedinproContext context, IHostingEnvironment env) : base(context, env)
        {
        }

        // GET: Products
        // public async Task<IActionResult> Index()
        // {
        //     return View(await _ledinproContext.Products.ToListAsync());
        // }

        public async Task<IActionResult> Index(int sceneId)
        {
            ViewBag.SceneId = sceneId;
            return View(await _ledinproContext.Products.Where(p => p.ProductSceneId == sceneId).ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _ledinproContext.Products
                .SingleOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        // public IActionResult Create()
        // {
        //     return View();
        // }

        public IActionResult Create(int sceneId)
        {
            GenerateSceneList(sceneId);

            return View();
        }

        private void GenerateSceneList(int sceneId)
        {
            // 把应用场景的列表数据传递到视图中
            ViewBag.SceneList = new SelectList(_ledinproContext.ProductScenes, "Id", "Name");
            ViewBag.SceneId = sceneId;
            // 列表默认选中当前产品
            foreach (var item in ViewBag.SceneList)
            {
                string str = item.Value;
                if (str.Equals(sceneId))
                {
                    // 选中当前项
                    item.Selected = true;
                }
                else
                {
                    // 其他选项设置未选中
                    item.Selected = false;
                }
            }
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,Name,Type,Description,Specification,Power,Lumen,LightingAngle,Efficient,Dimming,SceneName,ProductSceneId,Weight,Heat,Ppf,Id")] Product product,
                                                 IFormFile scenePicture, IFormFile picture, IFormFile mobilePicture, IFormFile backgroundPicture, IFormFile spectrum, IFormFile productGuide, IFormFile productInstallGuide, IFormFile productDatasheet, IFormFile productIes)
        {
            if (ModelState.IsValid)
            {
                var files = new List<IFormFile>() {scenePicture, picture, mobilePicture, backgroundPicture, spectrum, productGuide, productInstallGuide, productDatasheet, productIes};
                if (await UploadFiles(product, files) == false)
                {
                    return View(product);
                }

                _ledinproContext.Add(product);
                await _ledinproContext.SaveChangesAsync();
                // 保存之后应该返回到当前场景界面
                return RedirectToAction(nameof(Index), new { sceneId = product.ProductSceneId });
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _ledinproContext.Products.SingleOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            GenerateSceneList(product.ProductSceneId);

            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Code,Name,Type,Description,Specification,Power,Lumen,LightingAngle,Efficient,Dimming,SceneName,ProductSceneId,ScenePicturePath,Weight,Heat,Ppf,Id,PicturePath,MobilePicturePath,BackgroundPicturePath,Spectrum,ProductGuide,ProductInstallationGuide,ProductDatasheet,ProductIES")] Product product,
                                              IFormFile scenePicture, IFormFile picture, IFormFile mobilePicture, IFormFile backgroundPicture, IFormFile spectrum, IFormFile productGuide, IFormFile productInstallGuide, IFormFile productDatasheet, IFormFile productIes)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var files = new List<IFormFile>() {scenePicture, picture, mobilePicture, backgroundPicture, spectrum, productGuide, productInstallGuide, productDatasheet, productIes};
                if (await UploadFiles(product, files) == false)
                {
                    return View(product);
                }

                try
                {
                    _ledinproContext.Update(product);
                    await _ledinproContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { sceneId = product.ProductSceneId });
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _ledinproContext.Products
                .SingleOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _ledinproContext.Products.SingleOrDefaultAsync(m => m.Id == id);
            _ledinproContext.Products.Remove(product);
            await _ledinproContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _ledinproContext.Products.Any(e => e.Id == id);
        }

        [Authorize]
        public IActionResult ProductDetailInfo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // 获取当前产品
            var product = (from p in _ledinproContext.Products
                          where p.Id == id
                          select p).ToList();
            if (product.Count() > 0)
            {
                ViewBag.Product = product[0];
            }

            if (ViewBag.Product != null)
            {
                Product currentProduct = ViewBag.Product;
                ViewBag.NavTitle = currentProduct.Type + " /" + currentProduct.Name + " /" + currentProduct.Code;
            }

            // 获取预览图片
            var previewProductList = (from p in _ledinproContext.PreviewProducts
                                     where p.ProductId == id
                                     select p).ToList();
            ViewBag.PreviewProducts = previewProductList;

            // 获取特点图标
            var featureList = (from f in _ledinproContext.ProductFeatures
                               where f.ProductId == id
                               select f).ToList();
            ViewBag.FeatureList = featureList; 

            // 获取规格图片
            var subProductList = (from p in _ledinproContext.SubProducts
                                  where p.ProductId == id
                                  select p).ToList();
            ViewBag.SubProductList = subProductList;      
            
            return View();
        }

        private async Task<bool> UploadFiles(Product product, List<IFormFile> files)
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

                string filePath = "upload/" + product.Code;
                string fileName = filePath + "/" + f.FileName;
                string fullFilePath = Path.Combine(_env.WebRootPath, fileName);
                string fullFilePathDir = Path.Combine(_env.WebRootPath, filePath);
                try
                {
                    if (index == 0)
                    {
                        product.ScenePicturePath = fileName;
                    }
                    else if (index == 1)
                    {
                        product.PicturePath = fileName;
                    }
                    else if (index == 2)
                    {
                        product.MobilePicturePath = fileName;
                    }
                    else if (index == 3)
                    {
                        product.BackgroundPicturePath = fileName;
                    }
                    else if (index == 4)
                    {
                        product.Spectrum = fileName;
                    }
                    else if (index == 5)
                    {
                        product.ProductGuide = fileName;
                    }
                    else if (index == 6)
                    {
                        product.ProductInstallationGuide = fileName;
                    }
                    else if (index == 7)
                    {
                        product.ProductDatasheet = fileName;
                    }
                    else if (index == 8)
                    {
                        product.ProductIES = fileName;
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
