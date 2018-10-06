using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class TourPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageSize",
                table: "Tours",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Tours",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageSize",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Tours");
        }
    }
}
