﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Ledinpro.Migrations
{
    public partial class InitialLedinproDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carousel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUserName = table.Column<string>(maxLength: 16, nullable: true),
                    Description = table.Column<string>(maxLength: 1024, nullable: true),
                    MobilePicturePath = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    PicturePath = table.Column<string>(nullable: false),
                    RelativeProductId = table.Column<int>(nullable: true),
                    SortNumber = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 1024, nullable: true),
                    Type = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carousel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 1024, nullable: false),
                    BackgroundImage = table.Column<string>(nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUserName = table.Column<string>(maxLength: 16, nullable: true),
                    Description = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 64, nullable: false),
                    MobileBackgroundImage = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 512, nullable: false),
                    Phone = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUserName = table.Column<string>(maxLength: 16, nullable: true),
                    LogoPath = table.Column<string>(nullable: true),
                    LogoType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<string>(maxLength: 16, nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUserName = table.Column<string>(maxLength: 16, nullable: true),
                    Link = table.Column<string>(maxLength: 256, nullable: false),
                    Sortnumber = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Author = table.Column<string>(maxLength: 16, nullable: false),
                    BackgroundPicture = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUserName = table.Column<string>(maxLength: 16, nullable: true),
                    MobileBackgroundPicture = table.Column<string>(nullable: true),
                    MobilePicture = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    ProductType = table.Column<int>(nullable: true),
                    PublishOrNot = table.Column<bool>(nullable: true),
                    PublishTime = table.Column<DateTime>(nullable: true),
                    Sortnumber = table.Column<int>(nullable: true),
                    SubTitle = table.Column<string>(maxLength: 255, nullable: true),
                    Thumbnail = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BackgroundPicturePath = table.Column<string>(nullable: true),
                    Code = table.Column<string>(maxLength: 32, nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUserName = table.Column<string>(maxLength: 16, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Dimming = table.Column<string>(maxLength: 64, nullable: true),
                    Efficient = table.Column<string>(maxLength: 64, nullable: true),
                    Heat = table.Column<string>(maxLength: 64, nullable: true),
                    InputPower = table.Column<string>(maxLength: 64, nullable: true),
                    InputVoltage = table.Column<string>(maxLength: 64, nullable: true),
                    LightingAngle = table.Column<string>(maxLength: 64, nullable: true),
                    Lumen = table.Column<string>(maxLength: 64, nullable: true),
                    MobilePicturePath = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    OutputPower = table.Column<string>(maxLength: 64, nullable: true),
                    OutputVoltage = table.Column<string>(maxLength: 64, nullable: true),
                    PicturePath = table.Column<string>(nullable: true),
                    Power = table.Column<string>(maxLength: 64, nullable: true),
                    Ppf = table.Column<string>(maxLength: 64, nullable: true),
                    ProductDatasheet = table.Column<string>(nullable: true),
                    ProductGuide = table.Column<string>(nullable: true),
                    ProductIES = table.Column<string>(nullable: true),
                    ProductInstallationGuide = table.Column<string>(nullable: true),
                    ProductSceneId = table.Column<int>(nullable: false),
                    SceneName = table.Column<string>(maxLength: 64, nullable: true),
                    ScenePicturePath = table.Column<string>(nullable: true),
                    Specification = table.Column<string>(nullable: true),
                    Spectrum = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Weight = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductScene",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUserName = table.Column<string>(maxLength: 16, nullable: true),
                    Description = table.Column<string>(maxLength: 1024, nullable: true),
                    MobilePicturePath = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    PicturePath = table.Column<string>(nullable: true),
                    ProductApplicationScene = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductScene", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleContactInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUserName = table.Column<string>(maxLength: 16, nullable: true),
                    Email = table.Column<string>(maxLength: 64, nullable: false),
                    IsShow = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    NickName = table.Column<string>(maxLength: 64, nullable: true),
                    Phone = table.Column<string>(maxLength: 64, nullable: false),
                    PicturePath = table.Column<string>(nullable: true),
                    Skype = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleContactInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreviewProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUserName = table.Column<string>(maxLength: 16, nullable: true),
                    MobilePicturePath = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    PicturePath = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreviewProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreviewProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductComment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUserName = table.Column<string>(maxLength: 16, nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductComment_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductFeature",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUserName = table.Column<string>(maxLength: 16, nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    PicturePath = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFeature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFeature_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductFile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUserName = table.Column<string>(maxLength: 16, nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    FileTpye = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Version = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFile_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 64, nullable: false),
                    ColorAngle = table.Column<string>(maxLength: 64, nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUserName = table.Column<string>(maxLength: 16, nullable: true),
                    Dimming = table.Column<string>(maxLength: 64, nullable: true),
                    Efficient = table.Column<string>(maxLength: 64, nullable: true),
                    InputPower = table.Column<string>(maxLength: 64, nullable: true),
                    Lumen = table.Column<string>(maxLength: 64, nullable: true),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    OutputPower = table.Column<string>(maxLength: 64, nullable: true),
                    PicturePath = table.Column<string>(nullable: true),
                    Power = table.Column<string>(maxLength: 64, nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSceneProduct",
                columns: table => new
                {
                    ProductSceneId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSceneProduct", x => new { x.ProductSceneId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductSceneProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSceneProduct_ProductScene_ProductSceneId",
                        column: x => x.ProductSceneId,
                        principalTable: "ProductScene",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PreviewProduct_ProductId",
                table: "PreviewProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComment_ProductId",
                table: "ProductComment",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeature_ProductId",
                table: "ProductFeature",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFile_ProductId",
                table: "ProductFile",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSceneProduct_ProductId",
                table: "ProductSceneProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SubProduct_ProductId",
                table: "SubProduct",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carousel");

            migrationBuilder.DropTable(
                name: "CompanyInfo");

            migrationBuilder.DropTable(
                name: "Logo");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "PreviewProduct");

            migrationBuilder.DropTable(
                name: "ProductComment");

            migrationBuilder.DropTable(
                name: "ProductFeature");

            migrationBuilder.DropTable(
                name: "ProductFile");

            migrationBuilder.DropTable(
                name: "ProductSceneProduct");

            migrationBuilder.DropTable(
                name: "SaleContactInfo");

            migrationBuilder.DropTable(
                name: "SubProduct");

            migrationBuilder.DropTable(
                name: "ProductScene");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
