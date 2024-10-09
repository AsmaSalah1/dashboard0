using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asma.pl.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImagePAth1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "LastProducts",
                newName: "ImageName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "LastProducts",
                newName: "ImagePath");
        }
    }
}
