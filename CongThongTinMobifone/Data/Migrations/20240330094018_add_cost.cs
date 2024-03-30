using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CongThongTinMobifone.Data.Migrations
{
    public partial class add_cost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cost",
                table: "Package",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cost",
                table: "Package");
        }
    }
}
