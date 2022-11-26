using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProgramlamaAraProje.Migrations
{
    public partial class CollageDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminKullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminSifre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    DuyuruID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DuyuruBaslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuyuruIcerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuyuruTarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.DuyuruID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Announcements");
        }
    }
}
