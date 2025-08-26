using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoConference.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update_entites_navigation_prop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_UserId",
                table: "TeamMembers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingParticipants_UserId",
                table: "MeetingParticipants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMembers_UserId",
                table: "ChatMembers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMembers_AspNetUsers_UserId",
                table: "ChatMembers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingParticipants_AspNetUsers_UserId",
                table: "MeetingParticipants",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_AspNetUsers_UserId",
                table: "TeamMembers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMembers_AspNetUsers_UserId",
                table: "ChatMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_MeetingParticipants_AspNetUsers_UserId",
                table: "MeetingParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_AspNetUsers_UserId",
                table: "TeamMembers");

            migrationBuilder.DropIndex(
                name: "IX_TeamMembers_UserId",
                table: "TeamMembers");

            migrationBuilder.DropIndex(
                name: "IX_MeetingParticipants_UserId",
                table: "MeetingParticipants");

            migrationBuilder.DropIndex(
                name: "IX_ChatMembers_UserId",
                table: "ChatMembers");
        }
    }
}
