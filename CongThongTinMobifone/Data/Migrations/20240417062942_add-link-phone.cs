using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CongThongTinMobifone.Data.Migrations
{
    public partial class addlinkphone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "link",
                table: "Phone_number",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "cost",
                table: "Number_Type",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "link",
                table: "Phone_number");

            migrationBuilder.DropColumn(
                name: "cost",
                table: "Number_Type");
        }
    }
}
