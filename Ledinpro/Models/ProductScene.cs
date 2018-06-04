using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ledinpro.Models
{
    /// <summary>
    /// 产品应用场景
    /// </summary>
    public class ProductScene : BaseEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "请输入场景名称！")]
        [MaxLength(255)]
        [Display(Name = "名称")]
        public string Name { get; set; }

        /// <summary>
        /// 场景描述
        /// </summary>
        [MaxLength(1024)]
        [Display(Name = "描述")]
        public string Description { get; set; }

        /// <summary>
        /// 场景图片
        /// </summary>
        [Display(Name = "场景图片")]
        public string PicturePath { get; set; }

        /// <summary>
        /// 场景背景
        /// </summary>
        [Display(Name = "场景背景")]
        public string ProductApplicationScene { get; set; }

        /// <summary>
        /// 手机版场景图片
        /// </summary>
        [Display(Name = "手机版场景图片")]
        public string MobilePicturePath { get; set; }

        /// <summary>
        /// 场景类型
        /// </summary>
        public ProductType? Type { get; set; }

        /// <summary>
        /// 场景包含的产品
        /// </summary>
        public ICollection<ProductSceneProduct> ProductSceneProducts { get; set; }
    }
}
