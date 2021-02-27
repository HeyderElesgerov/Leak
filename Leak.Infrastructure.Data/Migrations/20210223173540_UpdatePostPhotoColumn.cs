using Microsoft.EntityFrameworkCore.Migrations;

namespace Leak.Infrastructure.Data.Migrations
{
    public partial class UpdatePostPhotoColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HeaderPhotoFileName",
                table: "Post",
                newName: "HeaderPhotoFilePath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HeaderPhotoFilePath",
                table: "Post",
                newName: "HeaderPhotoFileName");
        }
    }
}
