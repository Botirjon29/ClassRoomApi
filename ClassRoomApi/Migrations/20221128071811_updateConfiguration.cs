using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassRoomApi.Migrations
{
    public partial class updateConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskComments_AspNetUsers_UserId",
                table: "TaskComments");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskComments_TaskEntities_TaskId",
                table: "TaskComments");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskEntities_Courses_CourseId",
                table: "TaskEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_AspNetUsers_UserId",
                table: "UserCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_AspNetUsers_UserId",
                table: "UserTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_TaskEntities_TaskId",
                table: "UserTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTasks",
                table: "UserTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskEntities",
                table: "TaskEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "UserTasks",
                newName: "user_tasks");

            migrationBuilder.RenameTable(
                name: "TaskEntities",
                newName: "tasks");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "users");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "user_tasks",
                newName: "description");

            migrationBuilder.RenameIndex(
                name: "IX_UserTasks_UserId",
                table: "user_tasks",
                newName: "IX_user_tasks_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTasks_TaskId",
                table: "user_tasks",
                newName: "IX_user_tasks_TaskId");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "tasks",
                newName: "title");

            migrationBuilder.RenameIndex(
                name: "IX_TaskEntities_CourseId",
                table: "tasks",
                newName: "IX_tasks_CourseId");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "user_tasks",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "user task description",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "tasks",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "task title",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "tasks",
                type: "TEXT",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Firstname",
                table: "users",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_tasks",
                table: "user_tasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tasks",
                table: "tasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_users_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_users_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_users_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_users_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskComments_tasks_TaskId",
                table: "TaskComments",
                column: "TaskId",
                principalTable: "tasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskComments_users_UserId",
                table: "TaskComments",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_Courses_CourseId",
                table: "tasks",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_tasks_tasks_TaskId",
                table: "user_tasks",
                column: "TaskId",
                principalTable: "tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_tasks_users_UserId",
                table: "user_tasks",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_users_UserId",
                table: "UserCourses",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_users_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_users_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_users_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_users_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskComments_tasks_TaskId",
                table: "TaskComments");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskComments_users_UserId",
                table: "TaskComments");

            migrationBuilder.DropForeignKey(
                name: "FK_tasks_Courses_CourseId",
                table: "tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_user_tasks_tasks_TaskId",
                table: "user_tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_user_tasks_users_UserId",
                table: "user_tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_users_UserId",
                table: "UserCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_tasks",
                table: "user_tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tasks",
                table: "tasks");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "user_tasks",
                newName: "UserTasks");

            migrationBuilder.RenameTable(
                name: "tasks",
                newName: "TaskEntities");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "UserTasks",
                newName: "Description");

            migrationBuilder.RenameIndex(
                name: "IX_user_tasks_UserId",
                table: "UserTasks",
                newName: "IX_UserTasks_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_user_tasks_TaskId",
                table: "UserTasks",
                newName: "IX_UserTasks_TaskId");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "TaskEntities",
                newName: "Title");

            migrationBuilder.RenameIndex(
                name: "IX_tasks_CourseId",
                table: "TaskEntities",
                newName: "IX_TaskEntities_CourseId");

            migrationBuilder.AlterColumn<string>(
                name: "Firstname",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "UserTasks",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50,
                oldDefaultValue: "user task description");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "TaskEntities",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50,
                oldDefaultValue: "task title");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TaskEntities",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 255);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTasks",
                table: "UserTasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskEntities",
                table: "TaskEntities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskComments_AspNetUsers_UserId",
                table: "TaskComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskComments_TaskEntities_TaskId",
                table: "TaskComments",
                column: "TaskId",
                principalTable: "TaskEntities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskEntities_Courses_CourseId",
                table: "TaskEntities",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_AspNetUsers_UserId",
                table: "UserCourses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_AspNetUsers_UserId",
                table: "UserTasks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_TaskEntities_TaskId",
                table: "UserTasks",
                column: "TaskId",
                principalTable: "TaskEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
