using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CongThongTinMobifone.Data.Migrations
{
    public partial class crdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Number_Type",
                columns: table => new
                {
                    Number_TypeID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Number_Type", x => x.Number_TypeID);
                });

            migrationBuilder.CreateTable(
                name: "Post_cate",
                columns: table => new
                {
                    PostCateID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_cate", x => x.PostCateID);
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    Package_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Package_title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Package_Cate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Package_content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PostCateID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.Package_ID);
                    table.ForeignKey(
                        name: "FK_Package_Post_cate_PostCateID",
                        column: x => x.PostCateID,
                        principalTable: "Post_cate",
                        principalColumn: "PostCateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phone_number",
                columns: table => new
                {
                    Number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Number_TypeID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostCateID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone_number", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Phone_number_Number_Type_Number_TypeID",
                        column: x => x.Number_TypeID,
                        principalTable: "Number_Type",
                        principalColumn: "Number_TypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Phone_number_Post_cate_PostCateID",
                        column: x => x.PostCateID,
                        principalTable: "Post_cate",
                        principalColumn: "PostCateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostCateID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Post_title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Post_content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    avatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date_update = table.Column<DateTime>(type: "datetime2", nullable: false),
                    active = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostID);
                    table.ForeignKey(
                        name: "FK_Post_Post_cate_PostCateID",
                        column: x => x.PostCateID,
                        principalTable: "Post_cate",
                        principalColumn: "PostCateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Package_PostCateID",
                table: "Package",
                column: "PostCateID");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_number_Number_TypeID",
                table: "Phone_number",
                column: "Number_TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_number_PostCateID",
                table: "Phone_number",
                column: "PostCateID");

            migrationBuilder.CreateIndex(
                name: "IX_Post_PostCateID",
                table: "Post",
                column: "PostCateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "Phone_number");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Number_Type");

            migrationBuilder.DropTable(
                name: "Post_cate");
        }
    }
}
