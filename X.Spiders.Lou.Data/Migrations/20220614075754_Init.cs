using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace X.Spiders.Lou.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configs",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configs", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "LouPans",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    District = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PiWenNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KaiFaShang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DongCount = table.Column<int>(type: "int", nullable: true),
                    ProjectAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    SalesAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SalesTel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FangCount = table.Column<int>(type: "int", nullable: true),
                    Bus = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Area = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Designer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BuildingArea = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    SalesAgent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RongJiRate = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    WuYeCompany = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LvHuaRate = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ShiGongDanWei = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WuYeFee = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CompleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LouPans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LouDongs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YuShouZheng = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DongNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FaZhengDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Area = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    GuoTuZheng = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GongChengGuiHuaZheng = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    YongDiGuiHuaZheng = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShiGongZheng = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LouPanId = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LouDongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LouDongs_LouPans_LouPanId",
                        column: x => x.LouPanId,
                        principalTable: "LouPans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaoFangs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Num = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: true),
                    Usage = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BuildingArea = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TaoNeiArea = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    GongTanArea = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    SaleStatus = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LouDongId = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaoFangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaoFangs_LouDongs_LouDongId",
                        column: x => x.LouDongId,
                        principalTable: "LouDongs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LouDongs_LouPanId",
                table: "LouDongs",
                column: "LouPanId");

            migrationBuilder.CreateIndex(
                name: "IX_TaoFangs_LouDongId",
                table: "TaoFangs",
                column: "LouDongId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configs");

            migrationBuilder.DropTable(
                name: "TaoFangs");

            migrationBuilder.DropTable(
                name: "LouDongs");

            migrationBuilder.DropTable(
                name: "LouPans");
        }
    }
}
