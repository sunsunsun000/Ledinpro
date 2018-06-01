using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Ledinpro.Models;

namespace Ledinpro.Data
{
    public static class DbInitializer
    {
        public static void Initializer(LedinproContext context)
        {
            context.Database.EnsureCreated();

            // 1.初始化菜单
            InitialMenu(context);

            // 2.初始化轮播图
            InitialCarousel(context);

            // 3.初始化产品
            InitialProduct(context);

            // 4.初始化新闻
            InitialNews(context);

            // 5.初始化应用场景
            InitialApplicationScene(context);

            context.SaveChanges();
        }

        /// <summary>
        /// 初始化菜单
        /// </summary>
        private static void InitialMenu(LedinproContext context)
        {
            if (context.Menus.Any())
            {
                return;
            }
            context.Menus.AddRangeAsync(new List<Menu>() {
                new Menu() {
                    Title = "LIGHTS",
                    Sortnumber = 0,
                    Link = "Lighting",
                    Category = "Index"
                },                
                new Menu(){
                    Title = "CONTROL",
                    Sortnumber = 2,
                    Link = "Intellgentcontrol",
                    Category = "Index"
                },                
                new Menu(){
                    Title = "HORTICULTURE",
                    Sortnumber = 3,
                    Link = "Horticulture",
                    Category = "Other"
                },                
                new Menu(){
                    Title = "COMPANY",
                    Sortnumber = 5,
                    Link = "Company",
                    Category = "Index"
                },                
                new Menu(){
                    Title = "News",
                    Sortnumber = 0,
                    Link = "#companyNews",
                    Category = "Plant"
                },
                new Menu(){
                    Title = "Products",
                    Sortnumber = 1,
                    Link = "#productScenes",
                    Category = "Plant"
                },
                new Menu(){
                    Title = "Company",
                    Sortnumber = 2,
                    Link = "#companyIntroduce",
                    Category = "Plant"
                },
                new Menu(){
                    Title = "Contact_Us",
                    Sortnumber = 3,
                    Link = "#contact",
                    Category = "Plant"
                },
                new Menu(){
                    Title = "DOWNLOAD",
                    Sortnumber = 6,
                    Link = "ProductFileDownload",
                    Category = "Index"
                },
                new Menu(){
                    Title = "Download",
                    Sortnumber = 4,
                    Link = "ProductFileDownload",
                    Category = "Plant"
                }
            });
        }

        /// <summary>
        /// 初始化轮播图
        /// </summary>
        private static void InitialCarousel(LedinproContext context)
        {
            if (context.Carousels.Any())
            {
                return;
            }

            context.Carousels.AddRangeAsync(new List<Carousel>(){
                new Carousel()
                {
                    Name = "商照轮播图",
                    Title = "Trunk Go Flex Slim Liner Light",
                    Description = "Gapless interconnection.Plug & Play.",
                    PicturePath = "/upload/2017581153190.png",
                    MobilePicturePath = "/upload/20175811531901.png",
                    Type = ProductType.LIGHTING,
                    SortNumber = 1
                },                
                new Carousel()
                {
                    Name = "商照轮播图",
                    Title = "Trunk Pro Flex Linear Trunking System",
                    Description = "New optic desigen, up to 150lm/w. Free wiring and easy maintenance.",
                    PicturePath = "/upload/2017591342170.png",
                    MobilePicturePath = "/upload/20175913421701.png",
                    Type = ProductType.LIGHTING,
                    SortNumber = 4
                },
                new Carousel()
                {
                    Name = "商照轮播图",
                    Title = "HKTDC HK International Lighting Fair 2017 (Autumn Edition)",
                    Description = "Our booth: 3E-F15; Date: 2017/10/27-2017/10/30",
                    PicturePath = "/upload/20179211751410.png",
                    MobilePicturePath = "/upload/201792117514101.png",
                    Type = ProductType.LIGHTING,
                    SortNumber = 0
                },
                new Carousel()
                {
                    Name = "植物灯轮播图",
                    Title = "轮播图",
                    Description = "轮播图",
                    PicturePath = "/upload/201712281618180.png",
                    MobilePicturePath = "/upload/201712271033431.jpg",
                    Type = ProductType.HORTICULTURE,
                    SortNumber = 0
                },
            });
        }

        /// <summary>
        /// 初始化产品
        /// </summary>
        private static void InitialProduct(LedinproContext context)
        {
            if (context.Products.Any())
            {
                return;
            }
            context.Products.AddRangeAsync(new List<Product>() {
                new Product() {
                    Code = "Trunk Pro Flex",
                    Name = "LED Trunking System",
                    Type = ProductType.LIGHTING,
                    Description = "Modular design, parts replaceable.various beam angle: Flat, Narrow, Batwing, Asymmetric.",
                    Power = "45-130W",
                    Specification = "1500",
                    Lumen = "5000-10000lm",
                    LightingAngle = "30°-130°",
                    Efficient = "130lm/w",
                    Dimming = "",
                    PicturePath = "/upload/20174241058260.jpg",
                    MobilePicturePath = "/upload/201742410582601.jpg",
                    Ppf = ""
                },
                new Product() {
                    Code = "Trunk Go Flex",
                    Name = "Slim Linear Light",
                    Type = ProductType.LIGHTING,
                    Description = "Built-in driver.Interconnection installation，easy and fast.",
                    Power = "20-60W",
                    Specification = "1200mm/1500mm",
                    Lumen = "2400-7800lm",
                    LightingAngle = "80°/110°",
                    Efficient = "120lm/w",
                    Dimming = "",
                    PicturePath = "/upload/2017424113570.png",
                    MobilePicturePath = "/upload/20174241135701.png",
                    Ppf = ""
                },
                new Product() {
                    Code = "TriProof Connect II",
                    Name = "Waterproof Linear Light",
                    Type = ProductType.LIGHTING,
                    Description = "IP66,Waterproof.",
                    Power = "30W-130W",
                    Specification = "1200mm/1500mm",
                    Lumen = "3900-18000lm",
                    LightingAngle = "45°-130°",
                    Efficient = "140lm/w",
                    Dimming = "",
                    PicturePath = "/upload/20174241531400.jpg",
                    MobilePicturePath = "/upload/201742415314001.jpg",
                    Ppf = ""
                },
                new Product() {
                    Code = "Trunk Pro Flex",
                    Name = "LED Trunking System",
                    Type = ProductType.LIGHTING,
                    Description = "Modular design, parts replaceable.various beam angle: Flat, Narrow, Batwing, Asymmetric.",
                    Power = "45-130W",
                    Specification = "1500",
                    Lumen = "5000-10000lm",
                    LightingAngle = "30°-130°",
                    Efficient = "130lm/w",
                    Dimming = "",
                    PicturePath = "/upload/20174241058260.jpg",
                    MobilePicturePath = "/upload/201742410582601.jpg",
                    Ppf = ""
                },
                new Product() {
                    Code = "Trunk Pro Flex",
                    Name = "LED Trunking System",
                    Type = ProductType.LIGHTING,
                    Description = "Modular design, parts replaceable.various beam angle: Flat, Narrow, Batwing, Asymmetric.",
                    Power = "45-130W",
                    Specification = "1500",
                    Lumen = "5000-10000lm",
                    LightingAngle = "30°-130°",
                    Efficient = "130lm/w",
                    Dimming = "",
                    PicturePath = "/upload/20174241058260.jpg",
                    MobilePicturePath = "/upload/201742410582601.jpg",
                    Ppf = ""
                },
                new Product() {
                    Code = "Trunk Pro Flex",
                    Name = "LED Trunking System",
                    Type = ProductType.LIGHTING,
                    Description = "Modular design, parts replaceable.various beam angle: Flat, Narrow, Batwing, Asymmetric.",
                    Power = "45-130W",
                    Specification = "1500",
                    Lumen = "5000-10000lm",
                    LightingAngle = "30°-130°",
                    Efficient = "130lm/w",
                    Dimming = "",
                    PicturePath = "/upload/20174241058260.jpg",
                    MobilePicturePath = "/upload/201742410582601.jpg",
                    Ppf = ""
                },
                new Product() {
                    Code = "Trunk Pro Flex",
                    Name = "LED Trunking System",
                    Type = ProductType.LIGHTING,
                    Description = "Modular design, parts replaceable.various beam angle: Flat, Narrow, Batwing, Asymmetric.",
                    Power = "45-130W",
                    Specification = "1500",
                    Lumen = "5000-10000lm",
                    LightingAngle = "30°-130°",
                    Efficient = "130lm/w",
                    Dimming = "",
                    PicturePath = "/upload/20174241058260.jpg",
                    MobilePicturePath = "/upload/201742410582601.jpg",
                    Ppf = ""
                },
                                new Product() {
                    Code = "Trunk Pro Flex",
                    Name = "LED Trunking System",
                    Type = ProductType.LIGHTING,
                    Description = "Modular design, parts replaceable.various beam angle: Flat, Narrow, Batwing, Asymmetric.",
                    Power = "45-130W",
                    Specification = "1500",
                    Lumen = "5000-10000lm",
                    LightingAngle = "30°-130°",
                    Efficient = "130lm/w",
                    Dimming = "",
                    PicturePath = "/upload/20174241058260.jpg",
                    MobilePicturePath = "/upload/201742410582601.jpg",
                    Ppf = ""
                },
                new Product() {
                    Code = "Trunk Pro Flex",
                    Name = "LED Trunking System",
                    Type = ProductType.LIGHTING,
                    Description = "Modular design, parts replaceable.various beam angle: Flat, Narrow, Batwing, Asymmetric.",
                    Power = "45-130W",
                    Specification = "1500",
                    Lumen = "5000-10000lm",
                    LightingAngle = "30°-130°",
                    Efficient = "130lm/w",
                    Dimming = "",
                    PicturePath = "/upload/20174241058260.jpg",
                    MobilePicturePath = "/upload/201742410582601.jpg",
                    Ppf = ""
                },
                new Product() {
                    Code = "Trunk Pro Flex",
                    Name = "LED Trunking System",
                    Type = ProductType.LIGHTING,
                    Description = "Modular design, parts replaceable.various beam angle: Flat, Narrow, Batwing, Asymmetric.",
                    Power = "45-130W",
                    Specification = "1500",
                    Lumen = "5000-10000lm",
                    LightingAngle = "30°-130°",
                    Efficient = "130lm/w",
                    Dimming = "",
                    PicturePath = "/upload/20174241058260.jpg",
                    MobilePicturePath = "/upload/201742410582601.jpg",
                    Ppf = ""
                },
                new Product() {
                    Code = "Trunk Pro Flex",
                    Name = "LED Trunking System",
                    Type = ProductType.LIGHTING,
                    Description = "Modular design, parts replaceable.various beam angle: Flat, Narrow, Batwing, Asymmetric.",
                    Power = "45-130W",
                    Specification = "1500",
                    Lumen = "5000-10000lm",
                    LightingAngle = "30°-130°",
                    Efficient = "130lm/w",
                    Dimming = "",
                    PicturePath = "/upload/20174241058260.jpg",
                    MobilePicturePath = "/upload/201742410582601.jpg",
                    Ppf = ""
                },
                new Product() {
                    Code = "Trunk Pro Flex",
                    Name = "LED Trunking System",
                    Type = ProductType.LIGHTING,
                    Description = "Modular design, parts replaceable.various beam angle: Flat, Narrow, Batwing, Asymmetric.",
                    Power = "45-130W",
                    Specification = "1500",
                    Lumen = "5000-10000lm",
                    LightingAngle = "30°-130°",
                    Efficient = "130lm/w",
                    Dimming = "",
                    PicturePath = "/upload/20174241058260.jpg",
                    MobilePicturePath = "/upload/201742410582601.jpg",
                    Ppf = ""
                },
                new Product() {
                    Code = "Trunk Pro Flex",
                    Name = "LED Trunking System",
                    Type = ProductType.LIGHTING,
                    Description = "Modular design, parts replaceable.various beam angle: Flat, Narrow, Batwing, Asymmetric.",
                    Power = "45-130W",
                    Specification = "1500",
                    Lumen = "5000-10000lm",
                    LightingAngle = "30°-130°",
                    Efficient = "130lm/w",
                    Dimming = "",
                    PicturePath = "/upload/20174241058260.jpg",
                    MobilePicturePath = "/upload/201742410582601.jpg",
                    Ppf = ""
                },
                new Product() {
                    Code = "Trunk Pro Flex",
                    Name = "LED Trunking System",
                    Type = ProductType.LIGHTING,
                    Description = "Modular design, parts replaceable.various beam angle: Flat, Narrow, Batwing, Asymmetric.",
                    Power = "45-130W",
                    Specification = "1500",
                    Lumen = "5000-10000lm",
                    LightingAngle = "30°-130°",
                    Efficient = "130lm/w",
                    Dimming = "",
                    PicturePath = "/upload/20174241058260.jpg",
                    MobilePicturePath = "/upload/201742410582601.jpg",
                    Ppf = ""
                },
                new Product() {
                    Code = "Trunk Pro Flex",
                    Name = "LED Trunking System",
                    Type = ProductType.LIGHTING,
                    Description = "Modular design, parts replaceable.various beam angle: Flat, Narrow, Batwing, Asymmetric.",
                    Power = "45-130W",
                    Specification = "1500",
                    Lumen = "5000-10000lm",
                    LightingAngle = "30°-130°",
                    Efficient = "130lm/w",
                    Dimming = "",
                    PicturePath = "/upload/20174241058260.jpg",
                    MobilePicturePath = "/upload/201742410582601.jpg",
                    Ppf = ""
                },
                new Product() {
                    Code = "Trunk Pro Flex",
                    Name = "LED Trunking System",
                    Type = ProductType.LIGHTING,
                    Description = "Modular design, parts replaceable.various beam angle: Flat, Narrow, Batwing, Asymmetric.",
                    Power = "45-130W",
                    Specification = "1500",
                    Lumen = "5000-10000lm",
                    LightingAngle = "30°-130°",
                    Efficient = "130lm/w",
                    Dimming = "",
                    PicturePath = "/upload/20174241058260.jpg",
                    MobilePicturePath = "/upload/201742410582601.jpg",
                    Ppf = ""
                },
                new Product() {
                    Code = "Trunk Pro Flex",
                    Name = "LED Trunking System",
                    Type = ProductType.LIGHTING,
                    Description = "Modular design, parts replaceable.various beam angle: Flat, Narrow, Batwing, Asymmetric.",
                    Power = "45-130W",
                    Specification = "1500",
                    Lumen = "5000-10000lm",
                    LightingAngle = "30°-130°",
                    Efficient = "130lm/w",
                    Dimming = "",
                    PicturePath = "/upload/20174241058260.jpg",
                    MobilePicturePath = "/upload/201742410582601.jpg",
                    Ppf = ""
                },
                new Product() {
                    Code = "Trunk Pro Flex",
                    Name = "LED Trunking System",
                    Type = ProductType.LIGHTING,
                    Description = "Modular design, parts replaceable.various beam angle: Flat, Narrow, Batwing, Asymmetric.",
                    Power = "45-130W",
                    Specification = "1500",
                    Lumen = "5000-10000lm",
                    LightingAngle = "30°-130°",
                    Efficient = "130lm/w",
                    Dimming = "",
                    PicturePath = "/upload/20174241058260.jpg",
                    MobilePicturePath = "/upload/201742410582601.jpg",
                    Ppf = ""
                },
                new Product() {
                    Code = "Trunk Pro Flex",
                    Name = "LED Trunking System",
                    Type = ProductType.LIGHTING,
                    Description = "Modular design, parts replaceable.various beam angle: Flat, Narrow, Batwing, Asymmetric.",
                    Power = "45-130W",
                    Specification = "1500",
                    Lumen = "5000-10000lm",
                    LightingAngle = "30°-130°",
                    Efficient = "130lm/w",
                    Dimming = "",
                    PicturePath = "/upload/20174241058260.jpg",
                    MobilePicturePath = "/upload/201742410582601.jpg",
                    Ppf = ""
                },
            });
        }

        /// <summary>
        /// 初始化新闻
        /// </summary>
        private static void InitialNews(LedinproContext context)
        {
            if (context.News.Any())
            {
                return;
            }

            context.News.AddRangeAsync(new List<News>() {
                new News() {
                    Title = "123",
                    SubTitle = "456",
                    Thumbnail = "/upload/201712281444470.png",
                    Picture = "/upload/2018117181112.jpg",
                    MobilePicture = "/upload/20181181444351.jpg",
                    Content = "1",
                    Author = "Gu",
                    PublishOrNot = true,
                    Sortnumber = 0,
                    BackgroundPicture = "/upload/2018117181112.jpg",
                    ProductType = ProductType.HORTICULTURE
                }
            });
        }

        /// <summary>
        /// 初始化新闻
        /// </summary>
        private static void InitialApplicationScene(LedinproContext context)
        {
            if (context.ProductScenes.Any())
            {
                return;
            }

            context.ProductScenes.AddRangeAsync(new List<ProductScene>() {
                new ProductScene() {
                    Name = "Office",
                    Description = "",
                    ProductApplicationScene = "/upload/20174121521280.png",
                    PicturePath = "/upload/201741215212801.png",
                    Type = ProductType.LIGHTING
                },
                new ProductScene() {
                    Name = "Supermarket",
                    Description = "Supermarket",
                    ProductApplicationScene = "/upload/20174201012310.png",
                    PicturePath = "",
                    Type = ProductType.LIGHTING
                },
                new ProductScene() {
                    Name = "Industry",
                    Description = "Industry",
                    ProductApplicationScene = "/upload/20174201043100.png",
                    PicturePath = "",
                    Type = ProductType.LIGHTING
                },
                new ProductScene() {
                    Name = "Parking",
                    Description = "Parking",
                    ProductApplicationScene = "/upload/20174201024310.png",
                    PicturePath = "",
                    Type = ProductType.LIGHTING
                },
                new ProductScene() {
                    Name = "Aquarium",
                    Description = "",
                    ProductApplicationScene = "/upload/20174211042220.png",
                    PicturePath = "",
                    Type = ProductType.LIGHTING
                },
                new ProductScene() {
                    Name = "Farm",
                    Description = "",
                    ProductApplicationScene = "/upload/2017421105010.png",
                    PicturePath = "",
                    Type = ProductType.LIGHTING
                },
                new ProductScene() {
                    Name = "驱动",
                    Description = "驱动",
                    ProductApplicationScene = "",
                    PicturePath = "",
                    Type = ProductType.LIGHTING
                },
                new ProductScene() {
                    Name = "Greenhouse",
                    Description = "123",
                    ProductApplicationScene = "/upload/20181121646440.jpg",
                    PicturePath = "/upload/201811216464401.jpg",
                    Type = ProductType.HORTICULTURE
                },
                new ProductScene() {
                    Name = "Indoor cultivate",
                    Description = "123",
                    ProductApplicationScene = "/upload/2018120947530.jpg",
                    PicturePath = "/upload/20181209475301.jpg",
                    Type = ProductType.HORTICULTURE
                },
                new ProductScene() {
                    Name = "Vertical Farm",
                    Description = "123",
                    ProductApplicationScene = "/upload/20181121647490.jpg",
                    PicturePath = "/upload/201811216474901.jpg",
                    Type = ProductType.HORTICULTURE
                }
            });
        }
    }
}
