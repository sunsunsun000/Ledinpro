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
    public class ProductsController : BaseController
    {
        public ProductsController(LedinproContext context) : base(context)
        {
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _ledinproContext.Products.ToListAsync());
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,Name,Type,Description,Specification,Power,Lumen,LightingAngle,Efficient,Dimming,SceneName,ProductSceneId,ScenePicturePath,InputVoltage,OutputVoltage,InputPower,OutputPower,Weight,Heat,Ppf,Spectrum,PicturePath,BackgroundPicturePath,MobilePicturePath,ProductGuide,ProductInstallationGuide,ProductDatasheet,ProductIES,Id,CreateUserName,CreateDateTime")] Product product)
        {
            if (ModelState.IsValid)
            {
                _ledinproContext.Add(product);
                await _ledinproContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Code,Name,Type,Description,Specification,Power,Lumen,LightingAngle,Efficient,Dimming,SceneName,ProductSceneId,ScenePicturePath,InputVoltage,OutputVoltage,InputPower,OutputPower,Weight,Heat,Ppf,Spectrum,PicturePath,BackgroundPicturePath,MobilePicturePath,ProductGuide,ProductInstallationGuide,ProductDatasheet,ProductIES,Id,CreateUserName,CreateDateTime")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
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
                return RedirectToAction(nameof(Index));
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

        public async Task<IActionResult> ProductDetailInfo(int? id)
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
    }
}
