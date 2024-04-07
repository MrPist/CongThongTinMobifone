using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CongThongTinMobifone.Data.Migrations
{
    public partial class add_link : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "link",
                table: "Package",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "link",
                table: "Package");
        }
    }
}
