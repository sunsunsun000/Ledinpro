using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ledinpro.Data;
using Ledinpro.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Ledinpro.Controllers
{
    [Authorize(Roles = "内部员工,管理员")]
    public class CompanyInfoController : BaseController
    {
        public CompanyInfoController(LedinproContext context, IHostingEnvironment env) : base(context, env)
        {
        }

        // GET: CompanyInfo
        public async Task<IActionResult> Index()
        {
            return View(await _ledinproContext.CompanyInfos.ToListAsync());
        }

        // GET: CompanyInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyInfo = await _ledinproContext.CompanyInfos
                .SingleOrDefaultAsync(m => m.Id == id);
            if (companyInfo == null)
            {
                return NotFound();
            }

            return View(companyInfo);
        }

        // GET: CompanyInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompanyInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Address,Phone,Email,Description,FreeOne,FreeTwo,FreeThree,Id")] CompanyInfo companyInfo,
                                                 IFormFile backgroundImage, IFormFile mobileBackgroundImage, IFormFile freeOne, IFormFile freeTwo, IFormFile freeThree)
        {
            if (ModelState.IsValid)
            {
                var files = new List<IFormFile>() { backgroundImage, mobileBackgroundImage, freeOne, freeTwo, freeThree};
                if (await UploadFiles(companyInfo, files) == true)
                {
                    _ledinproContext.Add(companyInfo);
                    await _ledinproContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(companyInfo);
        }

        // GET: CompanyInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyInfo = await _ledinproContext.CompanyInfos.SingleOrDefaultAsync(m => m.Id == id);
            if (companyInfo == null)
            {
                return NotFound();
            }
            return View(companyInfo);
        }

        // POST: CompanyInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Address,Phone,Email,Description,Id,BackgroundImage,MobileBackgroundImage,FreeOne,FreeTwo,FreeThree")] CompanyInfo companyInfo,
                                              IFormFile backgroundImage, IFormFile mobileBackgroundImage, IFormFile freeOne, IFormFile freeTwo, IFormFile freeThree)
        {
            if (id != companyInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var files = new List<IFormFile>() { backgroundImage, mobileBackgroundImage, freeOne, freeTwo, freeThree };
                if (await UploadFiles(companyInfo, files) == false)
                {
                    return NotFound();
                }

                try
                {
                    _ledinproContext.Update(companyInfo);
                    await _ledinproContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyInfoExists(companyInfo.Id))
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
            return View(companyInfo);
        }

        // GET: CompanyInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyInfo = await _ledinproContext.CompanyInfos
                .SingleOrDefaultAsync(m => m.Id == id);
            if (companyInfo == null)
            {
                return NotFound();
            }

            return View(companyInfo);
        }

        // POST: CompanyInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyInfo = await _ledinproContext.CompanyInfos.SingleOrDefaultAsync(m => m.Id == id);
            _ledinproContext.CompanyInfos.Remove(companyInfo);
            await _ledinproContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyInfoExists(int id)
        {
            return _ledinproContext.CompanyInfos.Any(e => e.Id == id);
        }

        private async Task<bool> UploadFiles(CompanyInfo companyInfo, List<IFormFile> files)
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

                string filePath = "upload/" + companyInfo.Id.ToString();
                string fileName = filePath + "/" + f.FileName;
                string fullFilePath = Path.Combine(_env.WebRootPath, fileName);
                string fullFilePathDir = Path.Combine(_env.WebRootPath, filePath);
                try
                {
                    if (index == 0)
                    {
                        companyInfo.BackgroundImage =  "/" + fileName;
                    }
                    else if (index == 1)
                    {
                        companyInfo.MobileBackgroundImage = "/" + fileName;
                    }
                    else if (index == 2)
                    {
                        companyInfo.FreeOne = "/" + fileName;
                    }
                    else if (index == 3)
                    {
                        companyInfo.FreeTwo = "/" + fileName;
                    }
                    else if (index == 4)
                    {
                        companyInfo.FreeThree = "/" + fileName;
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
