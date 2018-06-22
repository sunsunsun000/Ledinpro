using System;
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
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace Ledinpro.Controllers
{
    [Authorize(Roles = "内部员工,管理员")]
    public class NewsController : BaseController
    {
        public NewsController(LedinproContext context, IHostingEnvironment env) : base(context, env)
        {
        }

        // GET: News
        public async Task<IActionResult> Index()
        {
            return View(await _ledinproContext.News.ToListAsync());
        }

        // GET: News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _ledinproContext.News
                .SingleOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // GET: News/Create
        public IActionResult Create()
        {
            var orNotList = new SelectList(new List<object>() { new { Title = "是", Publish = true } , new { Title = "否", Publish = false } }, "Publish", "Title");
            ViewBag.OrNotList = orNotList;

            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,SubTitle,Content,Author,ProductType,PublishTime,PublishOrNot,Sortnumber")] News news,
                                                IFormFile picture, IFormFile mobilePicture, IFormFile backgroundPicture, IFormFile mobileBackgroundPicture, 
                                                IFormFile thumbnail)
        {
            if (ModelState.IsValid)
            {
                var files = new List<IFormFile>() { picture, mobilePicture, backgroundPicture, mobileBackgroundPicture, thumbnail };
                if (await UploadFiles(news, files))
                {
                    _ledinproContext.Add(news);
                    await _ledinproContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(news);
        }

        // GET: News/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _ledinproContext.News.SingleOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            var orNotList = new SelectList(new List<object>() { new { Title = "是", Publish = true } , new { Title = "否", Publish = false } }, "Publish", "Title");
            ViewBag.OrNotList = orNotList;

            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,SubTitle,Content,Author,ProductType,PublishTime,PublishOrNot,Sortnumber,Id,Picture,MobilePicture,BackgroundPicture,MobileBackgroundPicture,Thumbnail")] News news,
                                              IFormFile picture, IFormFile mobilePicture, IFormFile backgroundPicture, IFormFile mobileBackgroundPicture, 
                                              IFormFile thumbnail)
        {
            if (id != news.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var files = new List<IFormFile>() { picture, mobilePicture, backgroundPicture, mobileBackgroundPicture, thumbnail };
                if (await UploadFiles(news, files) == false)
                {
                    return View(news);
                }

                try
                {
                    _ledinproContext.Update(news);
                    await _ledinproContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.Id))
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
            return View(news);
        }

        // GET: News/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _ledinproContext.News
                .SingleOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var news = await _ledinproContext.News.SingleOrDefaultAsync(m => m.Id == id);
            _ledinproContext.News.Remove(news);
            await _ledinproContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsExists(int id)
        {
            return _ledinproContext.News.Any(e => e.Id == id);
        }

        private async Task<bool> UploadFiles(News news, List<IFormFile> files)
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

                string filePath = "upload/" + news.Id.ToString();
                string fileName = filePath + "/" + f.FileName;
                string fullFilePath = Path.Combine(_env.WebRootPath, fileName);
                string fullFilePathDir = Path.Combine(_env.WebRootPath, filePath);
                try
                {
                    if (index == 0)
                    {
                        news.Picture =  "/" + fileName;
                    }
                    else if (index == 1)
                    {
                        news.MobilePicture = "/" + fileName;
                    }
                    else if (index == 2)
                    {
                        news.BackgroundPicture = "/" + fileName;
                    }
                    else if (index == 3)
                    {
                        news.MobileBackgroundPicture = "/" + fileName;
                    }
                    else if (index == 4)
                    {
                        news.Thumbnail = "/" + fileName;
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
