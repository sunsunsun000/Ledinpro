using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ledinpro.Models
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class Menu : BaseEntity
    {
        /// <summary>
        /// 类别
        /// </summary>
        [Display(Name = "类别")]
        [Required(ErrorMessage = "类别！")]
        [MaxLength(16)]
        [StringLength(16)]
        public string Category { get; set; }

        /// <summary>
        /// 菜单标题
        /// </summary>
        [Display(Name = "标题")]
        [Required(ErrorMessage = "请输入标题！")]
        [MaxLength(16)]
        [StringLength(16)]
        public string Title { get; set; }

        /// <summary>
        /// 菜单链接
        /// </summary>
        [Display(Name = "菜单链接")]
        [Required(ErrorMessage = "请输入链接!")]
        [MaxLength(256)]
        [StringLength(256)]
        public string Link { get; set; }

        /// <summary>
        /// 排序编号
        /// </summary>
        public int Sortnumber { get; set; }
    }
}
