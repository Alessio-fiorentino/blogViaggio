using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Web2.Migrations
{
    public partial class seconda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Consigliato",
                table: "Post",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sconsigliato",
                table: "Post",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Consigliato",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Sconsigliato",
                table: "Post");
        }
    }
}
