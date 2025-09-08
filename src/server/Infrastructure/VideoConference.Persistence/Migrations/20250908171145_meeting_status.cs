using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoConference.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class meeting_status : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "MeetingParticipants");

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "MeetingParticipants",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "MeetingParticipants");

            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "MeetingParticipants",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
