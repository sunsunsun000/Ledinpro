using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ledinpro.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ledinpro.Controllers
{
    /// <summary>
    /// 网站后台管理控制器
    /// </summary>
    [Authorize]
    public class LedinproAdminController : LedinproController
    {
        public LedinproAdminController(LedinproContext ledinproContext) : base(ledinproContext)
        {
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
