using Microsoft.EntityFrameworkCore.Migrations;

namespace AppWorkFlow.Data.Migrations
{
    public partial class check : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RedirectToDepartmentId",
                table: "FlowRequestActions",
                nullable: true,
                defaultValue: 0);

            //migrationBuilder.AddColumn<int>(
            //    name: "FlowRequestActionId",
            //    table: "Departments",
            //    nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlowRequestActions_RedirectToDepartmentId",
                table: "FlowRequestActions",
                column: "RedirectToDepartmentId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Departments_FlowRequestActionId",
            //    table: "Departments",
            //    column: "FlowRequestActionId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Departments_FlowRequestActions_FlowRequestActionId",
            //    table: "Departments",
            //    column: "FlowRequestActionId",
            //    principalTable: "FlowRequestActions",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FlowRequestActions_Departments_RedirectToDepartmentId",
                table: "FlowRequestActions",
                column: "RedirectToDepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_FlowRequestActions_FlowRequestActionId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_FlowRequestActions_Departments_RedirectToDepartmentId",
                table: "FlowRequestActions");

            migrationBuilder.DropIndex(
                name: "IX_FlowRequestActions_RedirectToDepartmentId",
                table: "FlowRequestActions");

            migrationBuilder.DropIndex(
                name: "IX_Departments_FlowRequestActionId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "RedirectToDepartmentId",
                table: "FlowRequestActions");

            migrationBuilder.DropColumn(
                name: "FlowRequestActionId",
                table: "Departments");
        }
    }
}
