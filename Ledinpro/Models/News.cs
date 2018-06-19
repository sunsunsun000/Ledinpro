using System;
using System.ComponentModel.DataAnnotations;

namespace Ledinpro.Models
{
    /// <summary>
    /// 新闻
    /// </summary>
    public class News : BaseEntity
    {
        /// <summary>
        /// 新闻标题
        /// </summary>
        [Required(ErrorMessage = "请输入标题！")]
        [MaxLength(255)]
        [Display(Name = "新闻标题")]
        public string Title { get; set; }

        /// <summary>
        /// 新闻副标题
        /// </summary>
        [MaxLength(255)]
        [Display(Name = "新闻副标题")]
        public string SubTitle { get; set; }

        /// <summary>
        /// 新闻内容
        /// </summary>
        [Required(ErrorMessage = "请输入新闻内容")]
        [Display(Name = "新闻内容")]
        public string Content { get; set; }

        /// <summary>
        /// 新闻作者
        /// </summary>
        [Required(ErrorMessage = "请输入作者名称！")]
        [MaxLength(16)]
        [StringLength(16)]
        [Display(Name = "作者名称")]
        public string Author { get; set; }

        /// <summary>
        /// 产品类型
        /// </summary>
        [Display(Name = "新闻类型")]
        public ProductType? ProductType { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        [Display(Name = "发布时间")]
        public DateTime? PublishTime { get; set; }

        /// <summary>
        /// 是否发布
        /// </summary>
        [Display(Name = "是否发布")]
        public bool? PublishOrNot { get; set; }

        /// <summary>
        /// 排序编号
        /// </summary>
        [Display(Name = "排序编号")]
        public int? Sortnumber { get; set; }

        /// <summary>
        /// 新闻图片
        /// </summary>
        [Display(Name = "新闻图片")]
        public string Picture { get; set; }

        /// <summary>
        /// 手机版新闻图片
        /// </summary>
        [Display(Name = "手机版新闻图片")]
        public string MobilePicture { get; set; }

        /// <summary>
        /// 新闻背景图片
        /// </summary>
        [Display(Name = "新闻背景图片")]
        public string BackgroundPicture { get; set; }

        /// <summary>
        /// 手机新闻背景图片
        /// </summary>
        [Display(Name = "手机新闻背景图片")]
        public string MobileBackgroundPicture { get; set; }

        /// <summary>
        /// 小图片
        /// </summary>
        [Display(Name = "小图片")]
        public string Thumbnail { get; set; }
    }
}
