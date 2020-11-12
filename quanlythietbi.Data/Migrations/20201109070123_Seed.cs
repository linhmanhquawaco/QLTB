using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace quanlythietbi.Data.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "NamSd",
                table: "Products",
                maxLength: 20,
                nullable: false,
                defaultValue: new DateTime(2020, 11, 9, 14, 1, 23, 391, DateTimeKind.Local).AddTicks(8052),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 20,
                oldDefaultValue: new DateTime(2020, 11, 9, 13, 55, 7, 383, DateTimeKind.Local).AddTicks(5056));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "NamSd",
                table: "Products",
                type: "datetime2",
                maxLength: 20,
                nullable: false,
                defaultValue: new DateTime(2020, 11, 9, 13, 55, 7, 383, DateTimeKind.Local).AddTicks(5056),
                oldClrType: typeof(DateTime),
                oldMaxLength: 20,
                oldDefaultValue: new DateTime(2020, 11, 9, 14, 1, 23, 391, DateTimeKind.Local).AddTicks(8052));
        }
    }
}
