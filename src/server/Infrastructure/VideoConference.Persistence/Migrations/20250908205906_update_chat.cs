using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoConference.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update_chat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Channels_ChannelId",
                table: "Meetings");

            migrationBuilder.DropIndex(
                name: "IX_Meetings_ChannelId",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "ChannelId",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "SettingId",
                table: "Meetings");

            migrationBuilder.AddColumn<Guid>(
                name: "MeetingId",
                table: "Chats",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SentAt",
                table: "ChatMessages",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SentAt",
                table: "ChannelMessages",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Chats_MeetingId",
                table: "Chats",
                column: "MeetingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Meetings_MeetingId",
                table: "Chats",
                column: "MeetingId",
                principalTable: "Meetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Meetings_MeetingId",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_MeetingId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "MeetingId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "SentAt",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "SentAt",
                table: "ChannelMessages");

            migrationBuilder.AddColumn<Guid>(
                name: "ChannelId",
                table: "Meetings",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SettingId",
                table: "Meetings",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_ChannelId",
                table: "Meetings",
                column: "ChannelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Channels_ChannelId",
                table: "Meetings",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
