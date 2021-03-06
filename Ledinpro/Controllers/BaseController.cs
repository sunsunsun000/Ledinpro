using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Ledinpro.Data;
using Ledinpro.Models;
using Microsoft.AspNetCore.Hosting;
namespace Ledinpro.Controllers
{
    public class BaseController : Controller
    {
        // 菜单数据
        public List<Menu> menus;
        protected LedinproContext _ledinproContext;
        protected readonly IHostingEnvironment _env;
        public BaseController(LedinproContext context, IHostingEnvironment env)
        {
            _ledinproContext = context;
            _env = env;
        }

        /// <summary>
        /// 获取菜单数据
        /// </summary>
        /// <returns></returns>
        private void GetMenus()
        {
            menus = (from menu in _ledinproContext.Menus
                     select menu).ToList();
            if (menus.Count == 0)
            {
                // 设置默认菜单到数据库
                InitialMenus();
                menus = (from menu in _ledinproContext.Menus
                         select menu).ToList();
            }
        }

        /// <summary>
        /// 测试初始化时使用
        /// </summary>
        /// <returns></returns>
        private void InitialMenus(){
                        // 初始化菜单项
            var menuList = new List<Menu>()
            {
                new Menu()
                {
                    Category = "Plant",
                    Title = "News",
                    Sortnumber = 0,
                    Link = ""
                },
                new Menu()
                {
                    Category = "Plant",
                    Title = "Products",
                    Sortnumber = 1,
                    Link = ""
                },
                new Menu()
                {
                    Category = "Plant",
                    Title = "Company",
                    Sortnumber = 2,
                    Link = ""
                },
                new Menu()
                {
                    Category = "Plant",
                    Title = "Contact Us",
                    Sortnumber = 3,
                    Link = ""
                },
                new Menu()
                {
                    Category = "Plant",
                    Title = "Download",
                    Sortnumber = 4,
                    Link = ""
                },
            };

            _ledinproContext.Menus.AddRange(menuList.ToArray());
            _ledinproContext.SaveChanges();
        }
    }
}