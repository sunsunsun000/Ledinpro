using System;
using System.ComponentModel.DataAnnotations;

namespace Ledinpro.Models
{
    /// <summary>
    /// 子产品类：包含规格和配件
    /// </summary>
    public class SubProduct : BaseEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "请输入名称！")]
        [MaxLength(64, ErrorMessage = "输入名称过长！最多64字符！")]
        public String Name { get; set; }

        /// <summary>
        /// 产品编码
        /// </summary>
        [Required(ErrorMessage = "请输入产品编码！"), StringLength(64)]
        [MaxLength(64, ErrorMessage = "输入编码过长！最多64字符！")]
        public string Code { get; set; }

        /// <summary>
        /// 子产品类型
        /// </summary>
        public SubProductType Type { get; set;}

        /// <summary>
        /// 功率
        /// </summary>
        [MaxLength(64, ErrorMessage = "输入功率过长！最多64字符！")]
        [Display(Name = "功率")]
        public string Power { get; set; }

        /// <summary>
        /// 输入功率
        /// </summary>
        [MaxLength(64, ErrorMessage = "输入功率过长！最多64字符！")]
        [Display(Name = "输入功率")]
        public string InputPower { get; set; }

        /// <summary>
        /// 输出功率
        /// </summary>
        [MaxLength(64, ErrorMessage = "输入功率过长！最多64字符！")]
        [Display(Name = "输出功率")]
        public string OutputPower { get; set; }

        /// <summary>
        /// 流明
        /// </summary>
        [MaxLength(64, ErrorMessage = "输入流明过长！最多64字符！")]
        [Display(Name = "流明")]
        public string Lumen { get; set; }

        /// <summary>
        /// 光角
        /// </summary>
        [MaxLength(64, ErrorMessage = "输入光角过长！最多64字符！")]
        [Display(Name = "光角")]
        public string ColorAngle { get; set; }

        /// <summary>
        /// 效率
        /// </summary>
        [MaxLength(64, ErrorMessage = "输入光效过长！最多64字符！")]
        [Display(Name = "光效")]
        public string Efficient { get; set; }

        /// <summary>
        /// 调光
        /// </summary>
        [MaxLength(64, ErrorMessage = "输入调光过长！最多64字符！")]
        [Display(Name = "调光")]
        public string Dimming { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        [Display(Name = "图片")]
        public string PicturePath { get; set; }

        /// <summary>
        /// 主产品Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 主产品
        /// </summary>
        public Product Product { get; set; }
    }
}
