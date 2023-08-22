using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLSV.Migrations
{
    public partial class initialv18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhViens_Khoas_KhoaId",
                table: "SinhViens");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhViens_Khoas_KhoaId",
                table: "SinhViens",
                column: "KhoaId",
                principalTable: "Khoas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhViens_Khoas_KhoaId",
                table: "SinhViens");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhViens_Khoas_KhoaId",
                table: "SinhViens",
                column: "KhoaId",
                principalTable: "Khoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
