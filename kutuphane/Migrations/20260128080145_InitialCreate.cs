using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kutuphane.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kitap",
                columns: table => new
                {
                    kitapNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kitapAdi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ISBNNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    sayfaSayisi = table.Column<int>(type: "int", nullable: true),
                    kitapOzeti = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitap", x => x.kitapNo);
                });

            migrationBuilder.CreateTable(
                name: "tur",
                columns: table => new
                {
                    turNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    turAciklama = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tur", x => x.turNo);
                });

            migrationBuilder.CreateTable(
                name: "uye",
                columns: table => new
                {
                    uyeNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    soyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    adresi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    aktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uye", x => x.uyeNo);
                });

            migrationBuilder.CreateTable(
                name: "yazar",
                columns: table => new
                {
                    yazarNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    soyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    dogum = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    hayatOzeti = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yazar", x => x.yazarNo);
                });

            migrationBuilder.CreateTable(
                name: "kitap_tur",
                columns: table => new
                {
                    kitapNo = table.Column<int>(type: "int", nullable: false),
                    turNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kitap_tur", x => new { x.kitapNo, x.turNo });
                    table.ForeignKey(
                        name: "FK_kitap_tur_Kitap_kitapNo",
                        column: x => x.kitapNo,
                        principalTable: "Kitap",
                        principalColumn: "kitapNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_kitap_tur_tur_turNo",
                        column: x => x.turNo,
                        principalTable: "tur",
                        principalColumn: "turNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "odunc",
                columns: table => new
                {
                    oduncNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kitapNo = table.Column<int>(type: "int", nullable: false),
                    uyeNo = table.Column<int>(type: "int", nullable: false),
                    vermeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vermeSuresi = table.Column<int>(type: "int", nullable: false),
                    geldiMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_odunc", x => x.oduncNo);
                    table.ForeignKey(
                        name: "FK_odunc_Kitap_kitapNo",
                        column: x => x.kitapNo,
                        principalTable: "Kitap",
                        principalColumn: "kitapNo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_odunc_uye_uyeNo",
                        column: x => x.uyeNo,
                        principalTable: "uye",
                        principalColumn: "uyeNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "kitap_yazar",
                columns: table => new
                {
                    kitap_yazarNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    yazarNo = table.Column<int>(type: "int", nullable: false),
                    kitapNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kitap_yazar", x => x.kitap_yazarNo);
                    table.ForeignKey(
                        name: "FK_kitap_yazar_Kitap_kitapNo",
                        column: x => x.kitapNo,
                        principalTable: "Kitap",
                        principalColumn: "kitapNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_kitap_yazar_yazar_yazarNo",
                        column: x => x.yazarNo,
                        principalTable: "yazar",
                        principalColumn: "yazarNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_kitap_tur_turNo",
                table: "kitap_tur",
                column: "turNo");

            migrationBuilder.CreateIndex(
                name: "IX_kitap_yazar_kitapNo",
                table: "kitap_yazar",
                column: "kitapNo");

            migrationBuilder.CreateIndex(
                name: "IX_kitap_yazar_yazarNo",
                table: "kitap_yazar",
                column: "yazarNo");

            migrationBuilder.CreateIndex(
                name: "IX_odunc_kitapNo",
                table: "odunc",
                column: "kitapNo");

            migrationBuilder.CreateIndex(
                name: "IX_odunc_uyeNo",
                table: "odunc",
                column: "uyeNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "kitap_tur");

            migrationBuilder.DropTable(
                name: "kitap_yazar");

            migrationBuilder.DropTable(
                name: "odunc");

            migrationBuilder.DropTable(
                name: "tur");

            migrationBuilder.DropTable(
                name: "yazar");

            migrationBuilder.DropTable(
                name: "Kitap");

            migrationBuilder.DropTable(
                name: "uye");
        }
    }
}
