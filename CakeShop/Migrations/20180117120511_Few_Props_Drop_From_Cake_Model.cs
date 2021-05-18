using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FavoursShop.Migrations
{
    public partial class Few_Props_Drop_From_Cake_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllergyInfo",
                table: "Favours");

            migrationBuilder.DropColumn(
                name: "ImageThumbnailUrl",
                table: "Favours");

            migrationBuilder.DropColumn(
                name: "InStock",
                table: "Favours");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AllergyInfo",
                table: "Favours",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageThumbnailUrl",
                table: "Favours",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "InStock",
                table: "Favours",
                nullable: false,
                defaultValue: false);
        }
    }
}
