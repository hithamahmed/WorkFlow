using Microsoft.EntityFrameworkCore.Migrations;

namespace AppWorkFlow.Data.Migrations
{
    public partial class statustostring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Departments_FlowRequestActions_FlowRequestActionId",
            //    table: "Departments");

            //migrationBuilder.DropIndex(
            //    name: "IX_Departments_FlowRequestActionId",
            //    table: "Departments");

            //migrationBuilder.DropColumn(
            //    name: "FlowRequestActionId",
            //    table: "Departments");

            migrationBuilder.AlterColumn<string>(
                name: "RequestStatus",
                table: "FlowRequestActions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RequestStatus",
                table: "FlowRequestActions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FlowRequestActionId",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_FlowRequestActionId",
                table: "Departments",
                column: "FlowRequestActionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_FlowRequestActions_FlowRequestActionId",
                table: "Departments",
                column: "FlowRequestActionId",
                principalTable: "FlowRequestActions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
