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
            Console.WriteLine(ViewData["Menus"]);
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
