using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Ledinpro.Data;
using Ledinpro.Models;

namespace Ledinpro.Controllers
{
    public class BaseController : Controller
    {
        // 菜单数据
        private List<Menu> menus;
        protected LedinproContext _ledinproContext;
        public BaseController(LedinproContext context)
        {
            _ledinproContext = context;
        }

        private void GetMenus()
        {
            menus = (from menu in _ledinproContext.Menus
                    select menu).ToList();
            if (menus.Count == 0)
            {
                menus = new List<Menu>() 
                {
                    new Menu {  }
                };
            }

            ViewBag.Menus = menus;
        }
    }
}