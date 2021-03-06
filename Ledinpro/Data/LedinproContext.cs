﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ledinpro.Models;

namespace Ledinpro.Data
{
    /// <summary>
    /// Ledinpro数据上下文
    /// </summary>
    public class LedinproContext : DbContext
    {
        public LedinproContext(DbContextOptions<LedinproContext> options)
            : base(options)
        {  
        }

        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<CompanyInfo> CompanyInfos { get; set; }
        public DbSet<Logo> Logos { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<PreviewProduct> PreviewProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<ProductFile> ProductFiles { get; set; }
        public DbSet<ProductScene> ProductScenes { get; set; }
        public DbSet<SaleContactInfo> SaleContactInfos { get; set; }
        public DbSet<SubProduct> SubProducts { get; set; }
        public DbSet<CustomerContactInfo> CustomerContactInfos { get; set; }

        /// <summary>
        /// 映射实体到数据库表名称
        /// </summary>
        /// <param name="modelBuilder">Model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 创建实体数据库表映射
            modelBuilder.Entity<Carousel>().ToTable("Carousel");
            modelBuilder.Entity<CompanyInfo>().ToTable("CompanyInfo");
            modelBuilder.Entity<Logo>().ToTable("Logo");
            modelBuilder.Entity<Menu>().ToTable("Menu");
            modelBuilder.Entity<News>().ToTable("News");
            modelBuilder.Entity<PreviewProduct>().ToTable("PreviewProduct");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<ProductComment>().ToTable("ProductComment");
            modelBuilder.Entity<ProductFeature>().ToTable("ProductFeature");
            modelBuilder.Entity<ProductFile>().ToTable("ProductFile");
            modelBuilder.Entity<ProductScene>().ToTable("ProductScene");
            modelBuilder.Entity<SaleContactInfo>().ToTable("SaleContactInfo");
            modelBuilder.Entity<SubProduct>().ToTable("SubProduct");
            modelBuilder.Entity<CustomerContactInfo>().ToTable("CustomerContactInfo");

            // 配置场景和产品多对多关系
            modelBuilder.Entity<ProductSceneProduct>()
                        .HasKey(ps => new { ps.ProductSceneId, ps.ProductId });
            modelBuilder.Entity<ProductSceneProduct>()
                        .HasOne(psp => psp.ProductScene)
                        .WithMany(psp => psp.ProductSceneProducts)
                        .HasForeignKey(psp => psp.ProductSceneId);
            modelBuilder.Entity<ProductSceneProduct>()
                        .HasOne(psp => psp.Product)
                        .WithMany(psp => psp.ProductSceneProducts)
                        .HasForeignKey(psp => psp.ProductId);
        }
    }
}
