using System;
using System.ComponentModel.DataAnnotations;

namespace Ledinpro.Models
{
    /// <summary>
    /// 产品预览
    /// </summary>
    public class PreviewProduct : BaseEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "请输入名称！")]
        [Display(Name = "名称")]
        [MaxLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        [Display(Name = "图片")]
        public string PicturePath { get;
            set;
        }

        /// <summary>
        /// 手机版图片
        /// </summary>
        public string MobilePicturePath { get; set; }

        /// <summary>
        /// 关联产品Id
        /// </summary>
        [Display(Name = "产品")]
        public int ProductId{ get; set; }

        /// <summary>
        /// 关联产品
        /// </summary>
        public Product Product { get; set; }
    }
}
