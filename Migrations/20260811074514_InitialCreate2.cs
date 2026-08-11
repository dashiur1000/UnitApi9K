using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnitApi9K.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trainingSessions_Dogs_DogId",
                table: "trainingSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_trainingSessions",
                table: "trainingSessions");

            migrationBuilder.RenameTable(
                name: "trainingSessions",
                newName: "TrainingSessions");

            migrationBuilder.RenameIndex(
                name: "IX_trainingSessions_DogId",
                table: "TrainingSessions",
                newName: "IX_TrainingSessions_DogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingSessions",
                table: "TrainingSessions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingSessions_Dogs_DogId",
                table: "TrainingSessions",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingSessions_Dogs_DogId",
                table: "TrainingSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingSessions",
                table: "TrainingSessions");

            migrationBuilder.RenameTable(
                name: "TrainingSessions",
                newName: "trainingSessions");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingSessions_DogId",
                table: "trainingSessions",
                newName: "IX_trainingSessions_DogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_trainingSessions",
                table: "trainingSessions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_trainingSessions_Dogs_DogId",
                table: "trainingSessions",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
