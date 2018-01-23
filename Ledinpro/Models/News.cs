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
        [MaxLength(64)]
        [Display(Name = "作者名称")]
        public string Author { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        [Display(Name = "发布时间")]
        public DateTime? PublishTime { get; set; }

        /// <summary>
        /// 是否发布
        /// </summary>
        [Display(Name = "是否发布")]
        public bool PublishOrNot { get; set; }
    }
}
