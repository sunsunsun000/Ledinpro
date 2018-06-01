using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ledinpro.Models;
using Microsoft.AspNetCore.Authorization;
using Ledinpro.Data;

namespace Ledinpro.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(LedinproContext context) : base(context)
        {

        }

        /// <summary>
        /// 网站首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 商业照明首页
        /// </summary>
        /// <returns></returns>
        public IActionResult LightingIndex()
        {
            return View();
        }

        /// <summary>
        /// 植物灯首页
        /// </summary>
        /// <returns></returns>
        public IActionResult PlantIndex()
        {
            // 1.获取轮播图数据
            var carousels = (from c in _ledinproContext.Carousels
                             where c.Type == ProductType.HORTICULTURE
                             orderby c.SortNumber ascending
                             select c).ToList<Carousel>();

            ViewBag.Carousels = carousels;

            // 2.获取新闻数据
            var news = (from n in _ledinproContext.News
                        where n.PublishOrNot == true && n.ProductType == ProductType.HORTICULTURE
                        orderby n.Sortnumber
                        select n).ToList<News>();

            ViewBag.News = news;

            // 3.获取植物灯应用场景
            var scenes = (from s in _ledinproContext.ProductScenes
                         where s.Type == ProductType.HORTICULTURE
                         select s).ToList<ProductScene>();
            ViewBag.Scenes = scenes;
            
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
