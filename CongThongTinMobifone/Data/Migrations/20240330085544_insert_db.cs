using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CongThongTinMobifone.Data.Migrations
{
    public partial class insert_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "Package");

            migrationBuilder.RenameColumn(
                name: "Package_Cate",
                table: "Package",
                newName: "Package_CateID");

            migrationBuilder.CreateTable(
                name: "Package_Cate",
                columns: table => new
                {
                    Package_CateID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Package_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package_Cate", x => x.Package_CateID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Package_Package_CateID",
                table: "Package",
                column: "Package_CateID");

            migrationBuilder.AddForeignKey(
                name: "FK_Package_Package_Cate_Package_CateID",
                table: "Package",
                column: "Package_CateID",
                principalTable: "Package_Cate",
                principalColumn: "Package_CateID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Package_Package_Cate_Package_CateID",
                table: "Package");

            migrationBuilder.DropTable(
                name: "Package_Cate");

            migrationBuilder.DropIndex(
                name: "IX_Package_Package_CateID",
                table: "Package");

            migrationBuilder.RenameColumn(
                name: "Package_CateID",
                table: "Package",
                newName: "Package_Cate");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Package",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }
    }
}
