using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class eventEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Categories_CategoryId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Rooms_RoomId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Speakers_SpeakerId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_CategoryId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_RoomId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_SpeakerId",
                table: "Events");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_RoomId",
                table: "Events",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_SpeakerId",
                table: "Events",
                column: "SpeakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Categories_CategoryId",
                table: "Events",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Rooms_RoomId",
                table: "Events",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Speakers_SpeakerId",
                table: "Events",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "Id");
        }
    }
}
