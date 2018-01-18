using System;
using System.ComponentModel.DataAnnotations;

namespace Ledinpro.Models
{
    /// <summary>
    /// 产品评论类
    /// </summary>
    public class ProductComment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "请输入评论！")]
        public string Comment { get; set; }

        public DateTime? EditTime { get; set; }

        // 用户Id
        public int UserId { get; set; }

        // 关联产品
        public int ProductId { get; set; }
    }
}
