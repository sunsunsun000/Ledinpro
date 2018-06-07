using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Ledinpro.Models;
using Microsoft.AspNetCore.Authorization;
using Ledinpro.Data;

namespace Ledinpro.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(LedinproContext context, IHostingEnvironment env) : base(context, env)
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
            var carousels = (from c in _ledinproContext.Carousels
                             where c.Type != ProductType.HORTICULTURE
                             orderby c.SortNumber ascending
                             select c).ToList<Carousel>();

            ViewBag.Carousels = carousels;

            var products = (from p in _ledinproContext.Products
                            where p.Type != ProductType.HORTICULTURE && p.Id != 21 & p.Id != 25
                            select p).ToList();

            ViewBag.Products = products;

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
                         orderby s.Id
                         select s).ToList<ProductScene>();
            ViewBag.Scenes = scenes;

            // 4.获取对应场景产品信息
            var products = (from p in _ledinproContext.Products
                           where p.Type == ProductType.HORTICULTURE
                           orderby p.ProductSceneId
                           select p).ToList<Product>();

            ViewBag.Products = products;

            // 5.获取公司信息
            var companyInfo = (from c in _ledinproContext.CompanyInfos
                               where c.Id == 2
                              select c).ToArray<CompanyInfo>();
            
            if (companyInfo.Count() > 0)
            {
                ViewBag.CompanyInfo = companyInfo[0];
            }
            
            return View();
        }

        [HttpGet]
        public IActionResult Lights()
        {
            ViewBag.isShowButton = true;

            // 传递导航信息
            ViewBag.NavTitle = "LIGHTING";

            ViewBag.index = 0;
            // 点击Lighting菜单返回的视图：传递从数据库中读取到的，筛选出类别为lighting的
            // 这里因为点击Product和Application
            List<Product> productList = (from p in _ledinproContext.Products
                                         where p.Type == ProductType.LIGHTING && p.Id != 21 && p.Id != 25
                                         select p).ToList();

            return View(productList);
        }

        public IActionResult IntellgentControl()
        {
            // 传递导航信息
            ViewBag.NavTitle = "INTELLGENTCONTROL";

            ViewBag.index = 0;
            // 点击Lighting菜单返回的视图：传递从数据库中读取到的，筛选出类别为lighting的
            // 这里因为点击Product和Application
            List<Product> productList = (from p in _ledinproContext.Products
                                         where p.Type == ProductType.INTELLGENTCONTROL
                                         select p).ToList();

            return View(productList);
        }

        public IActionResult Company()
        {
            List<CompanyInfo> companyList = (from p in _ledinproContext.CompanyInfos
                                            where p.Id == 4
                                            select p).ToList();
            if (companyList.Count > 0)
            {
                ViewBag.ComanyInfo = companyList[0];
                return View();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 产品文件下载
        /// </summary>
        public ActionResult ProductFileDownload(bool isPlant = false)
        {
            var productList = (from p in _ledinproContext.Products
                               orderby p.Name
                               select p).ToList();
            ViewBag.isPlant = isPlant;

            return View(productList);
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
