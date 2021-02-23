using Microsoft.EntityFrameworkCore.Migrations;

namespace Leak.Infrastructure.Data.Migrations
{
    public partial class DeleteUrlsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Url_UrlId",
                table: "Blog");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Url_UrlId",
                table: "Post");

            migrationBuilder.DropTable(
                name: "Url");

            migrationBuilder.DropIndex(
                name: "IX_Post_UrlId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Blog_UrlId",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "UrlId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "UrlId",
                table: "Blog");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UrlId",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UrlId",
                table: "Blog",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Url",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Url", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_UrlId",
                table: "Post",
                column: "UrlId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blog_UrlId",
                table: "Blog",
                column: "UrlId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Url_UrlId",
                table: "Blog",
                column: "UrlId",
                principalTable: "Url",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Url_UrlId",
                table: "Post",
                column: "UrlId",
                principalTable: "Url",
                principalColumn: "Id");
        }
    }
}
