using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asma.pl.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PLastroducts",
                table: "PLastroducts");

            migrationBuilder.RenameTable(
                name: "PLastroducts",
                newName: "LastProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LastProducts",
                table: "LastProducts",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LastProducts",
                table: "LastProducts");

            migrationBuilder.RenameTable(
                name: "LastProducts",
                newName: "PLastroducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PLastroducts",
                table: "PLastroducts",
                column: "Id");
        }
    }
}
