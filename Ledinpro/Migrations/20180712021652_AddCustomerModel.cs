using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Ledinpro.Migrations
{
    public partial class AddCustomerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Skype",
                table: "SaleContactInfo",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "SaleContactInfo",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 64);

            migrationBuilder.AddColumn<string>(
                name: "CellPhone",
                table: "SaleContactInfo",
                maxLength: 64,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomerContactInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUserName = table.Column<string>(maxLength: 16, nullable: true),
                    Email = table.Column<string>(maxLength: 32, nullable: true),
                    Free = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerContactInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerContactInfo");

            migrationBuilder.DropColumn(
                name: "CellPhone",
                table: "SaleContactInfo");

            migrationBuilder.AlterColumn<string>(
                name: "Skype",
                table: "SaleContactInfo",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "SaleContactInfo",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 64,
                oldNullable: true);
        }
    }
}
