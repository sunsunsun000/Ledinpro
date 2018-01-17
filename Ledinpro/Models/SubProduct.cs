using System;
using System.ComponentModel.DataAnnotations;

namespace Ledinpro.Models
{
    /// <summary>
    /// Sub product.
    /// 子产品类：包含规格和配件
    /// </summary>
    public class SubProduct
    {
        public int Id
        {
            get;
            set;
        }

        [Required(ErrorMessage = "请输入名称！")]
        public String Name
        {
            get;
            set;
        }

        [Required(ErrorMessage = "请输入产品编码！")]
        public string Code
        {
            get;
            set;
        }

        public string Power
        {
            get;
            set;
        }

        public string Lumen
        {
            get;
            set;
        }

        public string ColorAngle
        {
            get;
            set;
        }

        public string Efficient
        {
            get;
            set;
        }

        public string Dimming
        {
            get;
            set;
        }

        public string PicturePath
        {
            get;
            set;
        }

        // 产品主表Id
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
