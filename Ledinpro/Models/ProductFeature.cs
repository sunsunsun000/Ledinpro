using System;
using System.ComponentModel.DataAnnotations;

namespace Ledinpro.Models
{
    /// <summary>
    /// 产品特点
    /// </summary>
    public class ProductFeature : BaseEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "名称")]
        [MaxLength(255)]
        [Display(Name = "名称")]
        public string Name { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string PicturePath { get; set; }

        /// <summary>
        /// 关联产品Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 关联产品
        /// </summary>
        public Product Product { get; set; }
    }
}
