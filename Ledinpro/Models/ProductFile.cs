using System;
using System.ComponentModel.DataAnnotations;

namespace Ledinpro.Models
{
    /// <summary>
    /// 产品附件表：存储产品对应的附件
    /// </summary>
    public class ProductFile
    {
        public int Id { get; set; }

        // 产品指导书
        [Display(Name = "产品指导书")]
        public string Guide { get; set; }

        // 安装指导书
        [Display(Name = "安装指导书")]
        public string InstallationGuide { get; set; }

        // datasheet
        [Display(Name = "产品Datasheet文件")]
        public string DataSheet { get; set; }

        // IES文件
        [Display(Name = "产品IES文件")]
        public string Ies { get; set; }

        // 关联产品
        public int ProductId { get; set; }
    }
}
