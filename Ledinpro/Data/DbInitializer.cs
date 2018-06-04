﻿using System;
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

            // 6.初始化公司信息
            InitialCompanyInfo(context);

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
            context.Menus.AddRange(new List<Menu>() {
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

            context.Carousels.AddRange(new List<Carousel>(){
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
            context.Products.AddRange(new List<Product>() {
                new Product() { Code = "Trunk Pro Flex", ProductSceneId = 6, Name = "LED Trunking System", Type = ProductType.LIGHTING, Description = "Modular design, parts replaceable.various beam angle: Flat, Narrow, Batwing, Asymmetric.", Specification = "1500", Power = "45-130W", Lumen = "5000-10000lm", LightingAngle = "30°-130°", Efficient = "130lm/w", Dimming = "", SceneName = "", ScenePicturePath = "/upload/20174241536394.png", PicturePath = "/upload/20174241058260.jpg", MobilePicturePath = "/upload/201742410582601.jpg", ProductGuide = "/upload/201753177225.pdf", ProductInstallationGuide = "", ProductDatasheet = "", ProductIES = "/upload/2017531444348.zip", InputVoltage = "", OutputVoltage = "", InputPower = "", OutputPower = "", Weight = "", Heat = "", Ppf = "", Spectrum = "", BackgroundPicturePath = "", },
                new Product() { Code = "Trunk Go Flex", ProductSceneId = 6, Name = "Slim Linear Light", Type = ProductType.LIGHTING, Description = "Built-in driver.Interconnection installation，easy and fast.", Specification = "1200mm/1500mm", Power = "20-60W", Lumen = "2400-7800lm", LightingAngle = "80°/110°", Efficient = "120lm/w", Dimming = "", SceneName = "", ScenePicturePath = "/upload/201742411357014.png", PicturePath = "/upload/2017424113570.png", MobilePicturePath = "/upload/20174241135701.png", ProductGuide = "/upload/201753174285.pdf", ProductInstallationGuide = "/upload/201742410533801456.pdf", ProductDatasheet = "", ProductIES = "/upload/201753144588.zip", InputVoltage = "", OutputVoltage = "", InputPower = "", OutputPower = "", Weight = "", Heat = "", Ppf = "", Spectrum = "", BackgroundPicturePath = "", },
                new Product() { Code = "LL232", ProductSceneId = 7, Name = "LED Trunking System", Type = ProductType.LIGHTING, Description = "Modular design, parts replaceable.Flexible beam angles: Flat, Narrow, Batwing, Asymmetric.", Specification = "1500", Power = "45-130W", Lumen = "5000-10000lm", LightingAngle = "30°-130°", Efficient = "130lm/w", Dimming = "", SceneName = "", ScenePicturePath = "/upload/20174241536394.png", PicturePath = "/upload/20174241058260.jpg", MobilePicturePath = "/upload/201742410582601.jpg", ProductGuide = "/upload/20174241058260145.pdf", ProductInstallationGuide = "", ProductDatasheet = "", ProductIES = "/upload/201742410425401458.rar", InputVoltage = "", OutputVoltage = "", InputPower = "", OutputPower = "", Weight = "", Heat = "", Ppf = "", Spectrum = "", BackgroundPicturePath = "", },
                new Product() { Code = "LL249", ProductSceneId = 7, Name = "Slim Linear Light", Type = ProductType.LIGHTING, Description = "Built-in driver.Interconnection installation，easy and fast.", Specification = "1200mm/1500mm", Power = "20-60W", Lumen = "2400-7800lm", LightingAngle = "80°/110°", Efficient = "120lm/w", Dimming = "", SceneName = "", ScenePicturePath = "/upload/201742411357014.png", PicturePath = "/upload/2017424113570.png", MobilePicturePath = "/upload/20174241135701.png", ProductGuide = "/upload/2017424113570145.pdf", ProductInstallationGuide = "/upload/201742410533801456.pdf", ProductDatasheet = "", ProductIES = "", InputVoltage = "", OutputVoltage = "", InputPower = "", OutputPower = "", Weight = "", Heat = "", Ppf = "", Spectrum = "", BackgroundPicturePath = "", },
                new Product() { Code = "TriProof Connect II", ProductSceneId = 8, Name = "Waterproof Linear Light", Type = ProductType.LIGHTING, Description = "IP66,Waterproof.", Specification = "1200mm/1500mm", Power = "30W-130W", Lumen = "3900-18000lm", LightingAngle = "45°-130°", Efficient = "140lm/w", Dimming = "", SceneName = "", ScenePicturePath = "/upload/2017424153140014.png", PicturePath = "/upload/20174241531400.jpg", MobilePicturePath = "/upload/201742415314001.jpg", ProductGuide = "/upload/201755145055.pdf", ProductInstallationGuide = "", ProductDatasheet = "", ProductIES = "/upload/2017531445558.zip", InputVoltage = "", OutputVoltage = "", InputPower = "", OutputPower = "", Weight = "", Heat = "", Ppf = "", Spectrum = "", BackgroundPicturePath = "", },
                new Product() { Code = "TriProof Flex I", ProductSceneId = 8, Name = "Modular Waterproof Linear Light", Type = ProductType.LIGHTING, Description = "IP65,Modular Design", Specification = "1500mm", Power = "30W-65W", Lumen = "4200-10000lm", LightingAngle = "30°-130°", Efficient = "", Dimming = "", SceneName = "", ScenePicturePath = "/upload/2017425182745014.png", PicturePath = "/upload/20174251827450.jpg", MobilePicturePath = "/upload/201742518274501.jpg", ProductGuide = "/upload/2017531710115.pdf", ProductInstallationGuide = "/upload/201742518274501456.pdf", ProductDatasheet = "", ProductIES = "/upload/2017531446268.zip", InputVoltage = "", OutputVoltage = "", InputPower = "", OutputPower = "", Weight = "", Heat = "", Ppf = "", Spectrum = "", BackgroundPicturePath = "", },
                new Product() { Code = "TriProof Go", ProductSceneId = 12, Name = "IP67 Waterproof Linear Light", Type = ProductType.LIGHTING, Description = "IP67,130lm/W", Specification = "1200mm 1500mm", Power = "20W-60W", Lumen = "2400lm-7200lm", LightingAngle = "120°", Efficient = "", Dimming = "", SceneName = "", ScenePicturePath = "/upload/201742695355014.png", PicturePath = "/upload/2017426953550.jpg", MobilePicturePath = "/upload/20174269535501.jpg", ProductGuide = "/upload/2017531712405.pdf", ProductInstallationGuide = "", ProductDatasheet = "", ProductIES = "/upload/2017531447538.zip", InputVoltage = "", OutputVoltage = "", InputPower = "", OutputPower = "", Weight = "", Heat = "", Ppf = "", Spectrum = "", BackgroundPicturePath = "", },
                new Product() { Code = "LD284", ProductSceneId = 9, Name = "LED Dimable Driver", Type = ProductType.INTELLGENTCONTROL, Description = "0-10V/PWM No Ripple", Specification = "284x30x22mm（LxWxH）", Power = "13W-58W", Lumen = "OUTPUT:30-39VDC ", LightingAngle = "No Ripple", Efficient = "", Dimming = "", SceneName = "", ScenePicturePath = "", PicturePath = "/upload/2017521158240.png", MobilePicturePath = "/upload/20175211582401.png", ProductGuide = "", ProductInstallationGuide = "", ProductDatasheet = "/upload/2017427162548017.pdf", ProductIES = "", InputVoltage = "", OutputVoltage = "", InputPower = "", OutputPower = "", Weight = "", Heat = "", Ppf = "", Spectrum = "", BackgroundPicturePath = "", },
                new Product() { Code = "300", ProductSceneId = 15, Name = "Grow Connect", Type = ProductType.HORTICULTURE, Description = "Greenhouse ToplightingFull-cycle spectrum optimized for rapid growth and complete plant development.Suitable for a wide range of horticulture lighting applications like vegetables and herbs.Release date:June,2017", Specification = "1200mm", Power = "130W", Lumen = "15600lm", LightingAngle = "40°/70°/90°", Efficient = "1.8μmol/J", Dimming = "0-10V", SceneName = "greenhouse", ScenePicturePath = "", PicturePath = "/upload/201712291442440.png", MobilePicturePath = "/upload/2017122914424401.png", ProductGuide = "/upload/20171229931105.pdf", ProductInstallationGuide = "/upload/20171018114156012456.pdf", ProductDatasheet = "/upload/201710181141560124567.xls", ProductIES = "", InputVoltage = "", OutputVoltage = "", InputPower = "", OutputPower = "", Weight = "", Heat = "", Ppf = "234μmol/s", Spectrum = "/upload/201710201037464.png", BackgroundPicturePath = "/upload/2018117184392.png", },
                new Product() { Code = "298", ProductSceneId = 15, Name = "Grow Inline Connect", Type = ProductType.HORTICULTURE, Description = "Greenhouse InterlightingFull spectrum design.Suitable for reproductive growth like cucumbers and tomatoes.Release date:June,2017", Specification = "1200mm", Power = "60W", Lumen = "4020lm", LightingAngle = "Double 120°", Efficient = "1.7 μmol/J", Dimming = "0-10V", SceneName = "greenhouse", ScenePicturePath = "", PicturePath = "/upload/201712291432510.png", MobilePicturePath = "/upload/2017122914325101.png", ProductGuide = "/upload/2018120935205.pdf", ProductInstallationGuide = "/upload/20171018151358012456.pdf", ProductDatasheet = "/upload/201710181513580124567.xls", ProductIES = "", InputVoltage = "", OutputVoltage = "", InputPower = "", OutputPower = "", Weight = "", Heat = "", Ppf = "102μmol/s", Spectrum = "/upload/201710201038494.png", BackgroundPicturePath = "/upload/2018117184542.png", },
                new Product() { Code = "320", ProductSceneId = 15, Name = "Grow Flowering Flex", Type = ProductType.HORTICULTURE, Description = "Green house, Indoor cultivateCut your energy usage by up to 90% versus incandescent lamps, offers big energy savings versus halogen and compact fluorescent lamps. Suitable for cut flowers,bedding plants, perennials,strawberries.Release date: Nov,2017", Specification = "Φ95mm", Power = "14W", Lumen = "1", LightingAngle = "120°", Efficient = "2.2μmol/J ", Dimming = "Dim:No", SceneName = "1", ScenePicturePath = "", PicturePath = "/upload/201712291457590.png", MobilePicturePath = "/upload/2017122914575901.png", ProductGuide = "/upload/20171229928130125.pdf", ProductInstallationGuide = "/upload/201712299281301256.pdf", ProductDatasheet = "/upload/2017122992813012567.xlsx", ProductIES = "", InputVoltage = "", OutputVoltage = "", InputPower = "", OutputPower = "", Weight = "", Heat = "", Ppf = "30.8μmol/s ", Spectrum = "/upload/20171229941134.png", BackgroundPicturePath = "/upload/2018117185392.png", },
                new Product() { Code = "300", ProductSceneId = 16, Name = "Grow Connect", Type = ProductType.HORTICULTURE, Description = "Indoor cultivateFull-cycle spectrum optimized for rapid growth and complete plant development. Suitable for a wide range of horticulture lighting applications like vegetables and herbs.Release date: Nov,2017", Specification = "1200mm ", Power = "230W", Lumen = "1", LightingAngle = "70°/90°", Efficient = "2.3 μmol/J", Dimming = "1-10V", SceneName = "indoor", ScenePicturePath = "", PicturePath = "/upload/20171229109260.png", MobilePicturePath = "/upload/201712291092601.png", ProductGuide = "/upload/201712291044701245.pdf", ProductInstallationGuide = "/upload/2017122910447012456.pdf", ProductDatasheet = "/upload/20171229104470124567.xls", ProductIES = "", InputVoltage = "", OutputVoltage = "", InputPower = "", OutputPower = "", Weight = "", Heat = "", Ppf = "529μmol/s", Spectrum = "/upload/20171229104470124.png", BackgroundPicturePath = "/upload/2018117185102.png", },
                new Product() { Code = "301", ProductSceneId = 17, Name = "Grow Go", Type = ProductType.HORTICULTURE, Description = "Indoor cultivate, Vertical farmFull-cycle spectrum optimized for rapid growth and complete plant development.Suitable for a wide range of horticulture lighting applications like vegetables and herbs.Release date: Nov,2017", Specification = "1200mm", Power = "160W", Lumen = "24000lm/40000lm", LightingAngle = "40°/70°/90°", Efficient = "2.2 μmol/J", Dimming = "Dim:1-10V", SceneName = "Vertical farm", ScenePicturePath = "", PicturePath = "/upload/2018118912340.png", MobilePicturePath = "/upload/20181189123401.png", ProductGuide = "/upload/2017122818385701245.pdf", ProductInstallationGuide = "/upload/20171228183857012456.pdf", ProductDatasheet = "/upload/201712281838570124567.xls", ProductIES = "", InputVoltage = "", OutputVoltage = "", InputPower = "", OutputPower = "", Weight = "", Heat = "", Ppf = "352 μmol/s", Spectrum = "/upload/201712281838570124.png", BackgroundPicturePath = "/upload/2018117185252.png", },
                new Product() { Code = "315", ProductSceneId = 17, Name = "Grow Go T8 Flex", Type = ProductType.HORTICULTURE, Description = "Vertical farm, Tissue CultureFull-cycle spectrum optimized for rapid growth and complete plant development.Suitable for a wide range of horticulture lighting applications like vegetablesRelease date: Oct,2017", Specification = "1200mm", Power = "30W", Lumen = "1", LightingAngle = "120°", Efficient = "E1.8 μmol/J", Dimming = "no", SceneName = "", ScenePicturePath = "", PicturePath = "/upload/20181171718220.png", MobilePicturePath = "/upload/201811717182201.png", ProductGuide = "/upload/201712291356135.pdf", ProductInstallationGuide = "/upload/201712291445846.pdf", ProductDatasheet = "/upload/20171229134057012457.xls", ProductIES = "", InputVoltage = "", OutputVoltage = "", InputPower = "", OutputPower = "", Weight = "", Heat = "", Ppf = "54 μmol/s", Spectrum = "/upload/20171229144584.png", BackgroundPicturePath = "/upload/2018117185532.png", }
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

            context.News.AddRange(new List<News>() {
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

            context.ProductScenes.AddRange(new List<ProductScene>() {
                new ProductScene() {
                    Name = "Office",
                    Description = "场景描述",
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
                    Description = "场景描述",
                    ProductApplicationScene = "/upload/20174211042220.png",
                    PicturePath = "",
                    Type = ProductType.LIGHTING
                },
                new ProductScene() {
                    Name = "Farm",
                    Description = "场景描述",
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

        /// <summary>
        /// 初始化公司信息
        /// </summary>
        private static void InitialCompanyInfo(LedinproContext context)
        {
            if (context.CompanyInfos.Any())
            {
                return;
            }

            context.CompanyInfos.AddRange(new List<CompanyInfo>()
            {
                new CompanyInfo()
                {
                    Name = "INLEDCO",
                    Address = "INLEDCO",
                    Phone = "INLEDCO",
                    Email = "INLEDCO",
                    Description = "INLEDCO",
                    BackgroundImage = "/upload/20181171811423.jpg",
                    MobileBackgroundImage = "/upload/2018118144592.jpg"
                }
            });
        }
    }
}
