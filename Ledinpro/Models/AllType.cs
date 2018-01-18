using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ledinpro.Models
{
    /// <summary>
    /// 产品类型
    /// </summary>
    public enum ProductType
    {
        [Display(Name = "商业照明")]
        LIGHTING = 0,
        [Display(Name = "智能控制")]
        INTELLGENTCONTROL = 1,
        [Display(Name = "植物照明")]
        HORTICULTURE = 2,
        [Display(Name = "水族照明")]
        AQUARIUM = 3,
        [Display(Name = "其它类型")]
        LightingTypeEnd = 100
    }

    /// <summary>
    /// 子产品类型
    /// </summary>
    public enum SubProductType
    {
        [Display(Name = "规格")]
        SPECIFICATION = 0,
        [Display(Name = "配件")]
        ACCESSORIES = 1,
        [Display(Name = "其它类型")]
        OTHERTYPE = 100
    }

    public enum ProductFileType
    {
        DATASHEET = 0,
        IES = 1,
        OTHERTYPE = 100
    }
}
