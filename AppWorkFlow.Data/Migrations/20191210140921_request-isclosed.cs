using Microsoft.EntityFrameworkCore.Migrations;

namespace AppWorkFlow.Data.Migrations
{
    public partial class requestisclosed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                table: "FlowRequests",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "FlowRequests");
        }
    }
}
