using System;
using System.ComponentModel.DataAnnotations;

namespace Ledinpro.Models
{
    /// <summary>
    /// 轮播图
    /// </summary>
    public class Carousel : BaseEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "请输入名称！")]
        [MaxLength(64)]
        [StringLength(64)]
        [Display(Name = "名称")]
        public string Name { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Display(Name = "标题")]
        [StringLength(32)]
        [MaxLength(32)]
        public string Title { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Display(Name = "描述")]
        [MaxLength(1024)]
        [StringLength(1024)]
        public string Description { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        [Required(ErrorMessage = "请添加轮播图片！")]
        [Display(Name = "图片")]
        public string PicturePath { get; set; }

        /// <summary>
        /// 手机版图片
        /// </summary>
        [Display(Name = "手机版图片")]
        public string MobilePicturePath { get; set; }

        /// <summary>
        /// 排序编号
        /// </summary>
        [Display(Name = "排序编号")]
        public int SortNumber { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public ProductType? Type { get; set; }

        /// <summary>
        /// 关联产品
        /// </summary>
        [Display(Name = "关联产品")]
        public int RelativeProductId { get; set; }
    }
}
