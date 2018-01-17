using System;
using System.ComponentModel.DataAnnotations;

namespace Ledinpro.Models
{
    public class ProductFeature
    {
        public int Id { get; set; }

        // 特点名称
        [Required(ErrorMessage = "名称")]
        [MaxLength(255)]
        [Display(Name = "名称")]
        public string Name { get; set; }

        // 特点图片路径
        public string PicturePath { get; set; }

        // 关联的产品
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
