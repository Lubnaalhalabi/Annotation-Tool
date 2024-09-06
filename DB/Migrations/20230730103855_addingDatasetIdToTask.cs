using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class addingDatasetIdToTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TaskManeger",
                table: "Task",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "DatasetId",
                table: "Task",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatasetId",
                table: "Task");

            migrationBuilder.AlterColumn<string>(
                name: "TaskManeger",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
