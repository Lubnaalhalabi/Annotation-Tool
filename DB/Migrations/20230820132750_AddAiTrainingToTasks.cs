using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class AddAiTrainingToTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AiTraining",
                table: "Task",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AiTraining",
                table: "Task");
        }
    }
}
