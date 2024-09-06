using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class ConvertTaskManagerIdInTasksToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_AnnotationClassMapping_AnnotationClassMappingId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_DistributionPolicy_DistributionPolicyId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_InputType_InputTypeId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_TaskType_TaskTypeId",
                table: "Task");

            migrationBuilder.AlterColumn<int>(
                name: "TaskTypeId",
                table: "Task",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TaskManeger",
                table: "Task",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InputTypeId",
                table: "Task",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DistributionPolicyId",
                table: "Task",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnnotationClassMappingId",
                table: "Task",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_AnnotationClassMapping_AnnotationClassMappingId",
                table: "Task",
                column: "AnnotationClassMappingId",
                principalTable: "AnnotationClassMapping",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_DistributionPolicy_DistributionPolicyId",
                table: "Task",
                column: "DistributionPolicyId",
                principalTable: "DistributionPolicy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_InputType_InputTypeId",
                table: "Task",
                column: "InputTypeId",
                principalTable: "InputType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_TaskType_TaskTypeId",
                table: "Task",
                column: "TaskTypeId",
                principalTable: "TaskType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_AnnotationClassMapping_AnnotationClassMappingId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_DistributionPolicy_DistributionPolicyId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_InputType_InputTypeId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_TaskType_TaskTypeId",
                table: "Task");

            migrationBuilder.AlterColumn<int>(
                name: "TaskTypeId",
                table: "Task",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TaskManeger",
                table: "Task",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InputTypeId",
                table: "Task",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DistributionPolicyId",
                table: "Task",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AnnotationClassMappingId",
                table: "Task",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Task_AnnotationClassMapping_AnnotationClassMappingId",
                table: "Task",
                column: "AnnotationClassMappingId",
                principalTable: "AnnotationClassMapping",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_DistributionPolicy_DistributionPolicyId",
                table: "Task",
                column: "DistributionPolicyId",
                principalTable: "DistributionPolicy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_InputType_InputTypeId",
                table: "Task",
                column: "InputTypeId",
                principalTable: "InputType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_TaskType_TaskTypeId",
                table: "Task",
                column: "TaskTypeId",
                principalTable: "TaskType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
