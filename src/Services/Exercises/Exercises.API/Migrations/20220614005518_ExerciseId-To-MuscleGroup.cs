using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercises.API.Migrations
{
    public partial class ExerciseIdToMuscleGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MuscleGroups_Exercises_ExerciseId",
                table: "MuscleGroups");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "MuscleGroups",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MuscleGroups_Exercises_ExerciseId",
                table: "MuscleGroups",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MuscleGroups_Exercises_ExerciseId",
                table: "MuscleGroups");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "MuscleGroups",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MuscleGroups_Exercises_ExerciseId",
                table: "MuscleGroups",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");
        }
    }
}
