using System;
using System.ComponentModel.DataAnnotations;

namespace Ledinpro.Models
{
    /// <summary>
    /// 产品附件表：存储产品对应的附件
    /// </summary>
    public class ProductFile : BaseEntity
    {
        /// <summary>
        /// 产品指导书
        /// </summary>
        [Display(Name = "产品指导书")]
        public string Guide { get; set; }

        /// <summary>
        /// 安装指导书
        /// </summary>
        [Display(Name = "安装指导书")]
        public string InstallationGuide { get; set; }

        /// <summary>
        /// Datasheet
        /// </summary>
        [Display(Name = "产品Datasheet文件")]
        public string DataSheet { get; set; }

        /// <summary>
        /// IES文件
        /// </summary>
        [Display(Name = "产品IES文件")]
        public string Ies { get; set; }

        /// <summary>
        /// 产品Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 关联产品
        /// </summary>
        public Product Product { get; set; }
    }
}
