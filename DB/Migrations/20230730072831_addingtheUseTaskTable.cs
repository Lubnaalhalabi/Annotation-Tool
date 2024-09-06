using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class addingtheUseTaskTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TaskManeger",
                table: "Task",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "UsersTask",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId1 = table.Column<int>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersTask_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersTask_Task_TaskId1",
                        column: x => x.TaskId1,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersTask_ApplicationUserId",
                table: "UsersTask",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersTask_TaskId1",
                table: "UsersTask",
                column: "TaskId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersTask");

            migrationBuilder.AlterColumn<string>(
                name: "TaskManeger",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
