﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace quanlythietbi.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppConfigs",
                columns: table => new
                {
                    Key = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppConfigs", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsShowOnHome = table.Column<bool>(nullable: false),
                    ParentID = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DonVis",
                columns: table => new
                {
                    DonViId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonViName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonVis", x => x.DonViId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    SerialNumber = table.Column<string>(maxLength: 100, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Xuat_xu = table.Column<string>(maxLength: 50, nullable: true),
                    HangSX = table.Column<string>(maxLength: 50, nullable: true),
                    NamSx = table.Column<DateTime>(nullable: false),
                    NamSd = table.Column<DateTime>(maxLength: 20, nullable: false, defaultValue: new DateTime(2020, 11, 3, 5, 32, 34, 445, DateTimeKind.Local).AddTicks(7947)),
                    Vi_tri_lap = table.Column<string>(nullable: true),
                    TenNM = table.Column<string>(nullable: true),
                    DonViID = table.Column<int>(nullable: false),
                    NguonDien = table.Column<string>(maxLength: 10, nullable: true, defaultValue: "380"),
                    CongSuat = table.Column<string>(maxLength: 10, nullable: true),
                    DoDay = table.Column<string>(nullable: true),
                    HutSau = table.Column<string>(maxLength: 10, nullable: true),
                    LuuLuong = table.Column<string>(maxLength: 10, nullable: true),
                    HongHutXa = table.Column<string>(maxLength: 10, nullable: true),
                    VongQuay = table.Column<string>(maxLength: 10, nullable: true),
                    status = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhaMays",
                columns: table => new
                {
                    DonViId = table.Column<int>(nullable: false),
                    ProductId = table.Column<string>(nullable: false),
                    NMName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaMays", x => new { x.DonViId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_NhaMays_DonVis_DonViId",
                        column: x => x.DonViId,
                        principalTable: "DonVis",
                        principalColumn: "DonViId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhaMays_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productInCategories",
                columns: table => new
                {
                    ProductId = table.Column<string>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productInCategories", x => new { x.CategoryId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_productInCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productInCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productInDonvis",
                columns: table => new
                {
                    ProductId = table.Column<string>(nullable: false),
                    DonViId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productInDonvis", x => new { x.DonViId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_productInDonvis_DonVis_DonViId",
                        column: x => x.DonViId,
                        principalTable: "DonVis",
                        principalColumn: "DonViId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productInDonvis_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NhaMays_ProductId",
                table: "NhaMays",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_productInCategories_ProductId",
                table: "productInCategories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_productInDonvis_ProductId",
                table: "productInDonvis",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppConfigs");

            migrationBuilder.DropTable(
                name: "NhaMays");

            migrationBuilder.DropTable(
                name: "productInCategories");

            migrationBuilder.DropTable(
                name: "productInDonvis");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "DonVis");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
