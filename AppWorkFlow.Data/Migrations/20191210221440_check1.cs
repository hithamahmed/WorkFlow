using Microsoft.EntityFrameworkCore.Migrations;

namespace AppWorkFlow.Data.Migrations
{
    public partial class check1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlowRequestActions_Departments_RedirectToDepartmentId",
                table: "FlowRequestActions");

            migrationBuilder.AlterColumn<int>(
                name: "RedirectToDepartmentId",
                table: "FlowRequestActions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_FlowRequestActions_Departments_RedirectToDepartmentId",
                table: "FlowRequestActions",
                column: "RedirectToDepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlowRequestActions_Departments_RedirectToDepartmentId",
                table: "FlowRequestActions");

            migrationBuilder.AlterColumn<int>(
                name: "RedirectToDepartmentId",
                table: "FlowRequestActions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FlowRequestActions_Departments_RedirectToDepartmentId",
                table: "FlowRequestActions",
                column: "RedirectToDepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
