using Microsoft.EntityFrameworkCore.Migrations;

namespace AppWorkFlow.Data.Migrations
{
    public partial class requestisnewrequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewRequest",
                table: "FlowRequests");

            migrationBuilder.AddColumn<bool>(
                name: "IsNewRequest",
                table: "FlowRequests",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsNewRequest",
                table: "FlowRequests");

            migrationBuilder.AddColumn<bool>(
                name: "NewRequest",
                table: "FlowRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
