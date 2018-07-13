using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Ledinpro.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Ledinpro.Data;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;

namespace Ledinpro.Controllers
{
    public class HomeController : BaseController
    {
        private IConfiguration Configuration { get; }
        public HomeController(LedinproContext context, IHostingEnvironment env, IConfiguration configuration) : base(context, env)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 网站首页
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 商业照明首页
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
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
        [AllowAnonymous]
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
        [AllowAnonymous]
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

        [AllowAnonymous]
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

        [AllowAnonymous]
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
        [Authorize]
        public ActionResult ProductFileDownload(bool isPlant = false)
        {
            var productList = (from p in _ledinproContext.Products
                               orderby p.Name
                               select p).ToList();
            ViewBag.isPlant = isPlant;

            return View(productList);
        }

        /// <summary>
        /// 产品文件下载
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="email">邮箱</param>
        /// <param name="message">消息</param>
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveCustomerMessage([Bind("Name,Email,Message")] CustomerContactInfo customerContactInfo)
        {
            if (ModelState.IsValid)
            {
                if (!ReCaptchaPassed(Request.Form["g-recaptcha-response"], 
                                    Configuration.GetSection("GoogleReCaptcha:secret").Value))
                {
                    ViewBag.ReCaptchaResult = "失败";
                    return View("SendCustomerMessage");
                }
                // 这里不能过滤，信息可能不同
                customerContactInfo.CreateDateTime = DateTime.Now;
                _ledinproContext.CustomerContactInfos.Add(customerContactInfo);
                await _ledinproContext.SaveChangesAsync();
            }

            // return this.Content("<script>alert('Send Successfully!')</script>", "application/x-javascript", null);
            ViewBag.ReCaptchaResult = "成功";
            return View("SendCustomerMessage");
        }

        public static bool ReCaptchaPassed(string gRecaptchaResponse, string secret) {
            HttpClient httpClient = new HttpClient();
            var res = httpClient.GetAsync($"https://www.google.com/recaptcha/api/siteverify?secret={secret}&response={gRecaptchaResponse}").Result;
            if (res.StatusCode != HttpStatusCode.OK)
            {
                return false;
            }

            string JSONres = res.Content.ReadAsStringAsync().Result;
            dynamic JSONdata = JObject.Parse(JSONres);
            if (JSONdata.success != "true")
            {
                return false;
            }

            return true;
        }

        private bool ExistCustomerEmail(string email)
        {
            try {
                var c = _ledinproContext.CustomerContactInfos.Single(cus => cus.Email.Equals(email));
                if (c == null)
                {
                    return false;
                }

                return true;
            }
            catch (ArgumentNullException ex)
            {
                return false;
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
