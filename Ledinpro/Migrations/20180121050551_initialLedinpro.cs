using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Ledinpro.Migrations
{
    public partial class initialLedinpro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carousel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 1000, nullable: false),
                    BackgroundImage = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 64, nullable: false),
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
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
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Link = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Author = table.Column<string>(maxLength: 64, nullable: false),
                    Content = table.Column<string>(nullable: false),
                    EditTime = table.Column<DateTime>(nullable: true),
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EditPerson = table.Column<string>(nullable: true),
                    EditTime = table.Column<DateTime>(nullable: true),
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
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 64, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Dimming = table.Column<string>(nullable: true),
                    EditTime = table.Column<DateTime>(nullable: true),
                    EditUser = table.Column<string>(nullable: true),
                    Efficient = table.Column<string>(nullable: true),
                    Heat = table.Column<string>(maxLength: 64, nullable: true),
                    InputPower = table.Column<string>(maxLength: 64, nullable: true),
                    InputVoltage = table.Column<string>(maxLength: 64, nullable: true),
                    LightingAngle = table.Column<string>(nullable: true),
                    Lumen = table.Column<string>(nullable: true),
                    MobilePicturePath = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    OutputPower = table.Column<string>(maxLength: 64, nullable: true),
                    OutputVoltage = table.Column<string>(maxLength: 64, nullable: true),
                    PicturePath = table.Column<string>(nullable: true),
                    Power = table.Column<string>(nullable: true),
                    Ppf = table.Column<string>(maxLength: 255, nullable: true),
                    ProductSceneId = table.Column<int>(nullable: true),
                    Specification = table.Column<string>(nullable: true),
                    Spectrum = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Weight = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductComment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: false),
                    EditTime = table.Column<DateTime>(nullable: true),
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
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductFeature",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductFile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataSheet = table.Column<string>(nullable: true),
                    Guide = table.Column<string>(nullable: true),
                    Ies = table.Column<string>(nullable: true),
                    InstallationGuide = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFile_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: false),
                    ColorAngle = table.Column<string>(nullable: true),
                    Dimming = table.Column<string>(nullable: true),
                    Efficient = table.Column<string>(nullable: true),
                    Lumen = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    PicturePath = table.Column<string>(nullable: true),
                    Power = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PreviewProduct_ProductId",
                table: "PreviewProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductSceneId",
                table: "Product",
                column: "ProductSceneId");

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
