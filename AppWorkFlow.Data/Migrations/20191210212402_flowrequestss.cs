using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppWorkFlow.Data.Migrations
{
    public partial class flowrequestss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkFlows_Users_UserId",
                table: "WorkFlows");

            migrationBuilder.DropIndex(
                name: "IX_WorkFlows_UserId",
                table: "WorkFlows");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WorkFlows");

            migrationBuilder.CreateTable(
                name: "FlowRequestActions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    FlowRequestId = table.Column<int>(nullable: false),
                    ActionDate = table.Column<DateTime>(nullable: false),
                    RequestStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowRequestActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlowRequestActions_FlowRequests_FlowRequestId",
                        column: x => x.FlowRequestId,
                        principalTable: "FlowRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlowRequestActions_FlowRequestId",
                table: "FlowRequestActions",
                column: "FlowRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlowRequestActions");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "WorkFlows",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkFlows_UserId",
                table: "WorkFlows",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkFlows_Users_UserId",
                table: "WorkFlows",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
