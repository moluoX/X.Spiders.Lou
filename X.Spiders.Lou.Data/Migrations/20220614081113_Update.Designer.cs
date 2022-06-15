﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using X.Spiders.Lou.Data;

#nullable disable

namespace X.Spiders.Lou.Data.Migrations
{
    [DbContext(typeof(SpiderDbContext))]
    [Migration("20220614081113_Update")]
    partial class Update
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("X.Spiders.Lou.Data.Models.Config", b =>
                {
                    b.Property<string>("Key")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Key");

                    b.ToTable("Configs");
                });

            modelBuilder.Entity("X.Spiders.Lou.Data.Models.LouDong", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("Area")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("DongNo")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime?>("FaZhengDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GongChengGuiHuaZheng")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("GuoTuZheng")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("LastModifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("LouPanId")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ShiGongZheng")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("YongDiGuiHuaZheng")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("YuShouZheng")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("LouPanId");

                    b.ToTable("LouDongs");
                });

            modelBuilder.Entity("X.Spiders.Lou.Data.Models.LouPan", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("Area")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal?>("BuildingArea")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Bus")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("CompleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Designer")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("District")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("DongCount")
                        .HasColumnType("int");

                    b.Property<int?>("FangCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("KaiFaShang")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("LastModifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("LvHuaRate")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PiWenNo")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("Price")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("ProjectAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal?>("RongJiRate")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("SalesAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("SalesAgent")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SalesTel")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ShiGongDanWei")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("WuYeCompany")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("WuYeFee")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("LouPans");
                });

            modelBuilder.Entity("X.Spiders.Lou.Data.Models.TaoFang", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal?>("BuildingArea")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<int?>("Floor")
                        .HasColumnType("int");

                    b.Property<decimal?>("GongTanArea")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime>("LastModifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("LouDongId")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Num")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("SaleStatus")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<decimal?>("TaoNeiArea")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Type")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Usage")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("LouDongId");

                    b.ToTable("TaoFangs");
                });

            modelBuilder.Entity("X.Spiders.Lou.Data.Models.LouDong", b =>
                {
                    b.HasOne("X.Spiders.Lou.Data.Models.LouPan", "LouPan")
                        .WithMany("LouDongs")
                        .HasForeignKey("LouPanId");

                    b.Navigation("LouPan");
                });

            modelBuilder.Entity("X.Spiders.Lou.Data.Models.TaoFang", b =>
                {
                    b.HasOne("X.Spiders.Lou.Data.Models.LouDong", "LouDong")
                        .WithMany("TaoFangs")
                        .HasForeignKey("LouDongId");

                    b.Navigation("LouDong");
                });

            modelBuilder.Entity("X.Spiders.Lou.Data.Models.LouDong", b =>
                {
                    b.Navigation("TaoFangs");
                });

            modelBuilder.Entity("X.Spiders.Lou.Data.Models.LouPan", b =>
                {
                    b.Navigation("LouDongs");
                });
#pragma warning restore 612, 618
        }
    }
}
