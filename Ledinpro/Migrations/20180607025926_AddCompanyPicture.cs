using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Ledinpro.Migrations
{
    public partial class AddCompanyPicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FreeOne",
                table: "CompanyInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FreeThree",
                table: "CompanyInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FreeTwo",
                table: "CompanyInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FreeOne",
                table: "CompanyInfo");

            migrationBuilder.DropColumn(
                name: "FreeThree",
                table: "CompanyInfo");

            migrationBuilder.DropColumn(
                name: "FreeTwo",
                table: "CompanyInfo");
        }
    }
}
