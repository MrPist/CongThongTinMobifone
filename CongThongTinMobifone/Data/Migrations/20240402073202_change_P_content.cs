using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CongThongTinMobifone.Data.Migrations
{
    public partial class change_P_content : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Post_content",
                table: "Post",
                newName: "Post_content4");

            migrationBuilder.AddColumn<string>(
                name: "Post_content1",
                table: "Post",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Post_content2",
                table: "Post",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Post_content3",
                table: "Post",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "img1",
                table: "Post",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "img2",
                table: "Post",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "img3",
                table: "Post",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Post_content1",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Post_content2",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Post_content3",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "img1",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "img2",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "img3",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "Post_content4",
                table: "Post",
                newName: "Post_content");
        }
    }
}
