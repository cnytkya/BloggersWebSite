using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_writer_blog_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty");

            migrationBuilder.RenameTable(
                name: "MyProperty",
                newName: "Abouts");

            migrationBuilder.AddColumn<int>(
                name: "WriterId",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Abouts",
                table: "Abouts",
                column: "AboutId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_WriterId",
                table: "Blogs",
                column: "WriterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Writers_WriterId",
                table: "Blogs",
                column: "WriterId",
                principalTable: "Writers",
                principalColumn: "WriterId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Writers_WriterId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_WriterId",
                table: "Blogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Abouts",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "WriterId",
                table: "Blogs");

            migrationBuilder.RenameTable(
                name: "Abouts",
                newName: "MyProperty");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty",
                column: "AboutId");
        }
    }
}
