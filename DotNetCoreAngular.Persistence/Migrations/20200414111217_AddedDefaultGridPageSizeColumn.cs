using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCoreAngular.Persistence.Migrations
{
    public partial class AddedDefaultGridPageSizeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DefaultGridPageSize",
                table: "UserExtensions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultGridPageSize",
                table: "UserExtensions");
        }
    }
}
