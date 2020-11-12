using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace quanlythietbi.Data.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VongQuay",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NguonDien",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "380",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true,
                oldDefaultValue: "380");

            migrationBuilder.AlterColumn<string>(
                name: "LuuLuong",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HutSau",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HongHutXa",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DonViID",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CongSuat",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AppConfigs",
                columns: new[] { "Key", "Value" },
                values: new object[,]
                {
                    { "HomeTitle", "This is home page of QLTB" },
                    { "HomeKeyWord", "This is HomeKeyWord of QLTB" },
                    { "HomeDescription", "This is HomeDescription of QLTB" }
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("ca7ee66a-fe33-4985-940b-29ae960e5c9d"), "e77a579b-7f81-4e22-a2a4-ee527780af55", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("ca7ee66a-fe33-4985-940b-29ae960e5c9d"), new Guid("47ebc4fe-dc48-4ab2-9ae5-0b7e25efec50") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("47ebc4fe-dc48-4ab2-9ae5-0b7e25efec50"), 0, "6f2717de-e142-4d5f-bedc-ac09938bf0cb", "domanhlinh1@gmail.com", true, "Linh", "Do", false, null, "domanhlinh1@gmail.com", "admin", "AQAAAAEAACcQAAAAEHeoxmp+3c94P5adJOJPXZ9zzfm8PdauLfF719q2/Yxac8s40M3RKSkkInYfNUjqCQ==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsShowOnHome", "ParentID", "SortOrder", "Status" },
                values: new object[,]
                {
                    { 1, true, null, 1, 1 },
                    { 2, true, null, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CongSuat", "DoDay", "DonViID", "HangSX", "HongHutXa", "HutSau", "LuuLuong", "MaTb", "NamSd", "NamSx", "Name", "NguonDien", "SerialNumber", "TenNM", "Vi_tri_lap", "VongQuay", "Xuat_xu" },
                values: new object[] { 1, "1000", "100", null, "ABC", null, null, "900", "07-10", new DateTime(2020, 11, 12, 11, 35, 6, 64, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "máy bơm trục ngang", "380", null, null, null, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeDescription");

            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeKeyWord");

            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeTitle");

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("ca7ee66a-fe33-4985-940b-29ae960e5c9d"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ca7ee66a-fe33-4985-940b-29ae960e5c9d"), new Guid("47ebc4fe-dc48-4ab2-9ae5-0b7e25efec50") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("47ebc4fe-dc48-4ab2-9ae5-0b7e25efec50"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "VongQuay",
                table: "Products",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NguonDien",
                table: "Products",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                defaultValue: "380",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "380");

            migrationBuilder.AlterColumn<string>(
                name: "LuuLuong",
                table: "Products",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HutSau",
                table: "Products",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HongHutXa",
                table: "Products",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DonViID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CongSuat",
                table: "Products",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
