using System;
using System.ComponentModel.DataAnnotations;

namespace Ledinpro.Models
{
    public class PreviewProduct
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "请输入名称！")]
        [Display(Name = "名称")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Display(Name = "图片")]
        public string PicturePath { get;
            set;
        }

        // 关联的产品
        [Display(Name = "产品")]
        public int ProductId{ get; set; }
        public Product Product { get; set; }
    }
}
