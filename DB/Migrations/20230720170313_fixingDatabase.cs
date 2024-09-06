using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class fixingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnnotationClassMapping_Task",
                table: "AnnotationClassMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_DistributionPolicy_Task",
                table: "DistributionPolicy");

            migrationBuilder.DropForeignKey(
                name: "FK_InputType_Task",
                table: "InputType");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskType_Task",
                table: "TaskType");

            migrationBuilder.AddColumn<int>(
                name: "AnnotationClassMappingId",
                table: "Task",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistributionPolicyId",
                table: "Task",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InputTypeId",
                table: "Task",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskTypeId",
                table: "Task",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Task_AnnotationClassMappingId",
                table: "Task",
                column: "AnnotationClassMappingId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_DistributionPolicyId",
                table: "Task",
                column: "DistributionPolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_InputTypeId",
                table: "Task",
                column: "InputTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_TaskTypeId",
                table: "Task",
                column: "TaskTypeId");

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

            migrationBuilder.DropIndex(
                name: "IX_Task_AnnotationClassMappingId",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_DistributionPolicyId",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_InputTypeId",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_TaskTypeId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "AnnotationClassMappingId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "DistributionPolicyId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "InputTypeId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "TaskTypeId",
                table: "Task");

            migrationBuilder.AddForeignKey(
                name: "FK_AnnotationClassMapping_Task",
                table: "AnnotationClassMapping",
                column: "Id",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DistributionPolicy_Task",
                table: "DistributionPolicy",
                column: "Id",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InputType_Task",
                table: "InputType",
                column: "Id",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskType_Task",
                table: "TaskType",
                column: "Id",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
