using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ledinpro.Models
{
    /// <summary>
    /// 场景 产品中间表
    /// </summary>
    public class ProductSceneProduct
    {
        public int ProductSceneId { get; set; }
        public ProductScene ProductScene { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
