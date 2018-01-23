using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Ledinpro.Migrations
{
    public partial class InitialLedinpro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carousel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUserName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    LastEditDateTime = table.Column<DateTime>(nullable: true),
                    LastEditUserName = table.Column<string>(nullable: true),
                    MobilePicturePath = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    PicturePath = table.Column<string>(nullable: false),
                    RelativeProductId = table.Column<int>(nullable: false),
                    SortNumber = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carousel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(maxLength: 1000, nullable: false),
                    BackgroundImage = table.Column<string>(nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUserName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 64, nullable: false),
                    LastEditDateTime = table.Column<DateTime>(nullable: true),
                    LastEditUserName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 500, nullable: false),
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
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUserName = table.Column<string>(nullable: true),
                    LastEditDateTime = table.Column<DateTime>(nullable: true),
                    LastEditUserName = table.Column<string>(nullable: true),
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
                    Id = table.Column<Guid>(nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUserName = table.Column<string>(nullable: true),
                    LastEditDateTime = table.Column<DateTime>(nullable: true),
                    LastEditUserName = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Author = table.Column<string>(maxLength: 64, nullable: false),
                    Content = table.Column<string>(nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUserName = table.Column<string>(nullable: true),
                    LastEditDateTime = table.Column<DateTime>(nullable: true),
                    LastEditUserName = table.Column<string>(nullable: true),
                    PublishOrNot = table.Column<bool>(nullable: false),
                    PublishTime = table.Column<DateTime>(nullable: true),
                    SubTitle = table.Column<string>(maxLength: 255, nullable: true),
                    Title = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductScene",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUserName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    LastEditDateTime = table.Column<DateTime>(nullable: true),
                    LastEditUserName = table.Column<string>(nullable: true),
                    MobilePicturePath = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    PicturePath = table.Column<string>(nullable: true),
                    SceneType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductScene", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleContactInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 64, nullable: false),
                    IsShow = table.Column<bool>(nullable: false),
                    LastEditDateTime = table.Column<DateTime>(nullable: true),
                    LastEditUserName = table.Column<string>(nullable: true),
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
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(maxLength: 64, nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUserName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Dimming = table.Column<string>(nullable: true),
                    Efficient = table.Column<string>(nullable: true),
                    Heat = table.Column<string>(maxLength: 64, nullable: true),
                    InputPower = table.Column<string>(maxLength: 64, nullable: true),
                    InputVoltage = table.Column<string>(maxLength: 64, nullable: true),
                    LastEditDateTime = table.Column<DateTime>(nullable: true),
                    LastEditUserName = table.Column<string>(nullable: true),
                    LightingAngle = table.Column<string>(nullable: true),
                    Lumen = table.Column<string>(nullable: true),
                    MobilePicturePath = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    OutputPower = table.Column<string>(maxLength: 64, nullable: true),
                    OutputVoltage = table.Column<string>(maxLength: 64, nullable: true),
                    PicturePath = table.Column<string>(nullable: true),
                    Power = table.Column<string>(nullable: true),
                    Ppf = table.Column<string>(maxLength: 255, nullable: true),
                    ProductSceneId = table.Column<Guid>(nullable: true),
                    Specification = table.Column<string>(nullable: true),
                    Spectrum = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: false),
                    Weight = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductScene_ProductSceneId",
                        column: x => x.ProductSceneId,
                        principalTable: "ProductScene",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PreviewProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUserName = table.Column<string>(nullable: true),
                    LastEditDateTime = table.Column<DateTime>(nullable: true),
                    LastEditUserName = table.Column<string>(nullable: true),
                    MobilePicturePath = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    PicturePath = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    ProductId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreviewProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreviewProduct_Product_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductComment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Comment = table.Column<string>(nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUserName = table.Column<string>(nullable: true),
                    LastEditDateTime = table.Column<DateTime>(nullable: true),
                    LastEditUserName = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    ProductId1 = table.Column<Guid>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductComment_Product_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductFeature",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUserName = table.Column<string>(nullable: true),
                    LastEditDateTime = table.Column<DateTime>(nullable: true),
                    LastEditUserName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    PicturePath = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    ProductId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFeature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFeature_Product_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductFile",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUserName = table.Column<string>(nullable: true),
                    DataSheet = table.Column<string>(nullable: true),
                    Guide = table.Column<string>(nullable: true),
                    Ies = table.Column<string>(nullable: true),
                    InstallationGuide = table.Column<string>(nullable: true),
                    LastEditDateTime = table.Column<DateTime>(nullable: true),
                    LastEditUserName = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    ProductId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFile_Product_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(maxLength: 64, nullable: false),
                    ColorAngle = table.Column<string>(maxLength: 64, nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUserName = table.Column<string>(nullable: true),
                    Dimming = table.Column<string>(maxLength: 64, nullable: true),
                    Efficient = table.Column<string>(maxLength: 64, nullable: true),
                    InputPower = table.Column<string>(maxLength: 64, nullable: true),
                    LastEditDateTime = table.Column<DateTime>(nullable: true),
                    LastEditUserName = table.Column<string>(nullable: true),
                    Lumen = table.Column<string>(maxLength: 64, nullable: true),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    OutputPower = table.Column<string>(maxLength: 64, nullable: true),
                    PicturePath = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    ProductId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubProduct_Product_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PreviewProduct_ProductId1",
                table: "PreviewProduct",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductSceneId",
                table: "Product",
                column: "ProductSceneId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComment_ProductId1",
                table: "ProductComment",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeature_ProductId1",
                table: "ProductFeature",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFile_ProductId1",
                table: "ProductFile",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_SubProduct_ProductId1",
                table: "SubProduct",
                column: "ProductId1");
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
                name: "SaleContactInfo");

            migrationBuilder.DropTable(
                name: "SubProduct");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProductScene");
        }
    }
}
