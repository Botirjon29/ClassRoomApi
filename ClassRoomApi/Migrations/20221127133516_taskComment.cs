using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassRoomApi.Migrations
{
    public partial class taskComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ParentId = table.Column<Guid>(type: "TEXT", nullable: true),
                    TaskId = table.Column<Guid>(type: "TEXT", nullable: true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskComments_TaskComments_ParentId",
                        column: x => x.ParentId,
                        principalTable: "TaskComments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaskComments_TaskEntities_TaskId",
                        column: x => x.TaskId,
                        principalTable: "TaskEntities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskComments_ParentId",
                table: "TaskComments",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskComments_TaskId",
                table: "TaskComments",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskComments_UserId",
                table: "TaskComments",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskComments");
        }
    }
}
