using System;
using System.ComponentModel.DataAnnotations;

namespace Ledinpro.Models
{
    /// <summary>
    /// 产品评论
    /// </summary>
    public class ProductComment : BaseEntity
    {
        /// <summary>
        /// 评论内容
        /// </summary>
        [Required(ErrorMessage = "请输入评论！")]
        public string Comment { get; set; }

        // 用户Id
        public int UserId { get; set; }

        /// <summary>
        /// 关联产品Id
        /// </summary>
        public int ProductId { get; set; }
    }
}
