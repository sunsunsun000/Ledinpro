using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ledinpro.Data;

namespace Ledinpro.Controllers
{
    public class LedinproController : Controller
    {
        protected readonly LedinproContext _ledinproContext;

        /// <summary>
        /// 数据上下文
        /// </summary>
        /// <param name="ledinproContext">数据上下文</param>
        public LedinproController(LedinproContext ledinproContext)
        {
            _ledinproContext = ledinproContext;
        } 
    }
}