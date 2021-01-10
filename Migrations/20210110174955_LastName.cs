﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceShop.Migrations
{
    public partial class LastName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Customer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(    
                name: "LastName",
                table: "Customer");
        }
    }
}
