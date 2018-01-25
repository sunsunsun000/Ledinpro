﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ledinpro.Models
{
    /// <summary>
    /// 产品
    /// </summary>
    public class Product : BaseEntity
    {
        /// <summary>
        /// 产品编码
        /// </summary>
        [Display(Name = "产品编码")]
        [Required, StringLength(64), MaxLength(64)]
        public string Code { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        [Display(Name = "名称")]
        [Required, StringLength(128), MaxLength(128)]
        public string Name { get; set; }

        /// <summary>
        /// 产品类型
        /// </summary>
        [Display(Name = "类型")]
        [Required]
        public string Type { get; set; }

        /// <summary>
        /// 产品描述
        /// </summary>
        [Display(Name = "描述")]
        public string Description { get; set; }

        /// <summary>
        /// 产品规格
        /// </summary>
        [Display(Name = "规格")]
        public string Specification { get; set; }

        /// <summary>
        /// 功率
        /// </summary>
        [Display(Name = "功率")]
        public string Power { get; set; }

        /// <summary>
        /// 流明
        /// </summary>
        [Display(Name = "流明")]
        public string Lumen { get; set; }

        /// <summary>
        /// 光角
        /// </summary>
        [Display(Name = "光角")]
        public string LightingAngle { get; set; }

        /// <summary>
        /// 光效
        /// </summary>
        [Display(Name = "光效")]
        public string Efficient { get; set; }

        /// <summary>
        /// 调光
        /// </summary>
        [Display(Name = "调光")]
        public string Dimming { get; set; }

        /// <summary>
        /// 输入电压
        /// </summary>
        [Display(Name = "输入电压")]
        [MaxLength(64, ErrorMessage = "输入过长，最长64字符！")]
        public string InputVoltage { get; set; }

        /// <summary>
        /// 输出电压
        /// </summary>
        [Display(Name = "输出电压")]
        [MaxLength(64, ErrorMessage = "输入过长，最长64字符！")]
        public string OutputVoltage { get; set; }

        /// <summary>
        /// 输入功率
        /// </summary>
        [Display(Name = "输入功率")]
        [MaxLength(64, ErrorMessage = "输入过长，最长64字符！")]
        public string InputPower { get; set; }

        /// <summary>
        /// 输出功率
        /// </summary>
        [Display(Name = "输出功率")]
        [MaxLength(64, ErrorMessage = "输入过长，最长64字符！")]
        public string OutputPower { get; set; }
 
        /// <summary>
        /// 重量
        /// </summary>
        [Display(Name = "重量")]
        [MaxLength(64, ErrorMessage = "输入过长，最长64字符！")]
        public string Weight { get; set; }

        /// <summary>
        /// 发热
        /// </summary>
        [Display(Name = "发热")]
        [MaxLength(64, ErrorMessage = "输入过长，最长64字符！")]
        public string Heat { get; set; }

        /// <summary>
        /// PPF
        /// </summary>
        [Display(Name = "PPF")]
        [MaxLength(255, ErrorMessage = "输入过长，最长255字符！")]
        public string Ppf { get; set; }

        /// <summary>
        /// 光谱
        /// </summary>
        [Display(Name = "光谱")]
        public string Spectrum { get; set; }

        /// <summary>
        /// 产品图片
        /// </summary>
        [Display(Name = "产品图片")]
        public string PicturePath { get; set; }

        /// <summary>
        /// 手机版产品图片
        /// </summary>
        [Display(Name = "手机版产品图片")]
        public string MobilePicturePath { get; set; }

        /// <summary>
        /// 关联场景
        /// </summary>
        public ICollection<ProductSceneProduct> ProductSceneProducts { get; set; }

        /// <summary>
        /// 产品特点
        /// </summary>
        public ICollection<ProductFeature> ProductFeatures { get; set;}

        /// <summary>
        /// 预览图片
        /// </summary>
        public ICollection<PreviewProduct> PreviewProducts { get; set; }

        /// <summary>
        /// 子产品
        /// </summary>
        public ICollection<SubProduct> SubProducts { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        public ICollection<ProductFile> ProductFiles { get; set; }

        /// <summary>
        /// 评论
        /// </summary>
        public ICollection<ProductComment> ProductComments { get; set; }
    }
}
