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
        /// 文件类型
        /// </summary>
        [Required(ErrorMessage = "请选择文件类型！")]
        public ProductFileType FileTpye { get; set; }

        /// <summary>
        /// 文件版本号
        /// </summary>
        [Required(ErrorMessage = "请填写版本号！")]
        public string Version { get; set; }

        /// <summary>
        /// 产品文件
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 产品Id
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// 关联产品
        /// </summary>
        public Product Product { get; set; }
    }
}
