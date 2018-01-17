using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ledinpro.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Display(Name = "产品编码")]
        [Required, StringLength(64), MaxLength(64)]
        public string Code { get; set; }

        [Display(Name = "名称")]
        [Required, StringLength(128), MaxLength(128)]
        public string Name { get; set; }

        [Display(Name = "类型")]
        [Required]
        public string Type { get; set; }

        [Display(Name = "描述")]
        public string Description { get; set; }

        [Display(Name = "规格")]
        public string Specification { get; set; }

        [Display(Name = "功率")]
        public string Power { get; set; }

        [Display(Name = "流明")]
        public string Lumen { get; set; }

        [Display(Name = "光角")]
        public string LightingAngle { get; set; }

        [Display(Name = "光效")]
        public string Efficient { get; set; }

        [Display(Name = "调光")]
        public string Dimming { get; set; }

        [Display(Name = "输入电压")]
        [MaxLength(64, ErrorMessage = "输入过长，最长64字符！")]
        public string InputVoltage { get; set; }

        [Display(Name = "输出电压")]
        [MaxLength(64, ErrorMessage = "输入过长，最长64字符！")]
        public string OutputVoltage { get; set; }

        [Display(Name = "输入功率")]
        [MaxLength(64, ErrorMessage = "输入过长，最长64字符！")]
        public string InputPower { get; set; }

        [Display(Name = "输入功率")]
        [MaxLength(64, ErrorMessage = "输入过长，最长64字符！")]
        public string OutputPower { get; set; }
 
        [Display(Name = "重量")]
        [MaxLength(64, ErrorMessage = "输入过长，最长64字符！")]
        public string Weight { get; set; }

        [Display(Name = "发热")]
        [MaxLength(64, ErrorMessage = "输入过长，最长64字符！")]
        public string Heat { get; set; }

        [Display(Name = "PPF")]
        [MaxLength(255, ErrorMessage = "输入过长，最长255字符！")]
        public string Ppf { get; set; }

        [Display(Name = "光谱")]
        public string Spectrum { get; set; }

        [Display(Name = "电脑版产品图片")]
        public string PicturePath { get; set; }

        [Display(Name = "电脑版产品图片")]
        public string MobilePicturePath { get; set; }

        // 产品指导书
        [Display(Name = "产品指导书")]
        public string Guide { get; set; }

        // 安装指导书
        [Display(Name = "安装指导书")]
        public string InstallationGuide { get; set; }

        // datasheet
        [Display(Name = "产品Datasheet文件")]
        public string Datasheet { get; set; }

        // IES文件
        [Display(Name = "产品IES文件")]
        public string Ies { get; set; }

        // 导航属性
        // 产品特点
        public ICollection<ProductFeature> ProductFeatures { get; set;}

        // 预览图片
        public ICollection<PreviewProduct> PreviewProducts { get; set; }

        // 子产品：规格、配件
        public ICollection<SubProduct> SubProducts { get; set; }
    }
}
