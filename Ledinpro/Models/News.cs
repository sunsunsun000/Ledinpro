using System;
using System.ComponentModel.DataAnnotations;

namespace Ledinpro.Models
{
    public class News
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "请输入标题！")]
        [MaxLength(255)]
        [Display(Name = "新闻标题")]
        public string Title { get; set; }

        [MaxLength(255)]
        [Display(Name = "新闻副标题")]
        public string SubTitle { get; set; }

        [Required(ErrorMessage = "请输入新闻内容")]
        [Display(Name = "新闻内容")]
        public string Content { get; set; }

        [Required(ErrorMessage = "请输入作者名称！")]
        [MaxLength(64)]
        [Display(Name = "作者名称")]
        public string Author { get; set; }

        [Display(Name = "编辑时间")]
        public DateTime? EditTime { get; set; }

        [Display(Name = "发布时间")]
        public DateTime? PublishTime { get; set; }

        [Display(Name = "是否发布")]
        public bool PublishOrNot { get; set; }
    }
}
