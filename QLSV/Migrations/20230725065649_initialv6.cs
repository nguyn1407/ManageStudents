using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLSV.Migrations
{
    public partial class initialv6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KhoaId",
                table: "SinhViens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Khoas",
                columns: table => new
                {
                    KhoaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhoa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoas", x => x.KhoaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SinhViens_KhoaId",
                table: "SinhViens",
                column: "KhoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhViens_Khoas_KhoaId",
                table: "SinhViens",
                column: "KhoaId",
                principalTable: "Khoas",
                principalColumn: "KhoaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhViens_Khoas_KhoaId",
                table: "SinhViens");

            migrationBuilder.DropTable(
                name: "Khoas");

            migrationBuilder.DropIndex(
                name: "IX_SinhViens_KhoaId",
                table: "SinhViens");

            migrationBuilder.DropColumn(
                name: "KhoaId",
                table: "SinhViens");
        }
    }
}
