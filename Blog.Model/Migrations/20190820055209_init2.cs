using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Model.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "UserGroups",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "Comments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "BlogCategories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "ArticleToCategories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "Articles",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserGroups",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comments",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BlogCategories",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ArticleToCategories",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Articles",
                newName: "Guid");
        }
    }
}
