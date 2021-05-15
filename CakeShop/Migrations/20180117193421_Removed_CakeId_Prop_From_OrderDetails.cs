using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FavoursShop.Migrations
{
    public partial class Removed_CakeId_Prop_From_OrderDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Cakes_CakeId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_CakeId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "FavourId",
                table: "OrderDetails");

            migrationBuilder.AddColumn<string>(
                name: "FavourName",
                table: "OrderDetails",
                maxLength: 1024,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FavourName",
                table: "OrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "FavourId",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_CakeId",
                table: "OrderDetails",
                column: "FavourId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Cakes_CakeId",
                table: "OrderDetails",
                column: "FavourId",
                principalTable: "Favours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
