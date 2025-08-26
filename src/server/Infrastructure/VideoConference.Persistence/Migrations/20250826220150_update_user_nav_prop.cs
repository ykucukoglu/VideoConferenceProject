using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoConference.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update_user_nav_prop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "ChatMessages",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "ChannelMessages",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_SenderId",
                table: "ChatMessages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_UserId",
                table: "ChatMessages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelMessages_SenderId",
                table: "ChannelMessages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelMessages_UserId",
                table: "ChannelMessages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChannelMessages_AspNetUsers_SenderId",
                table: "ChannelMessages",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChannelMessages_AspNetUsers_UserId",
                table: "ChannelMessages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_AspNetUsers_SenderId",
                table: "ChatMessages",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_AspNetUsers_UserId",
                table: "ChatMessages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChannelMessages_AspNetUsers_SenderId",
                table: "ChannelMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_ChannelMessages_AspNetUsers_UserId",
                table: "ChannelMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_AspNetUsers_SenderId",
                table: "ChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_AspNetUsers_UserId",
                table: "ChatMessages");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessages_SenderId",
                table: "ChatMessages");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessages_UserId",
                table: "ChatMessages");

            migrationBuilder.DropIndex(
                name: "IX_ChannelMessages_SenderId",
                table: "ChannelMessages");

            migrationBuilder.DropIndex(
                name: "IX_ChannelMessages_UserId",
                table: "ChannelMessages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ChannelMessages");
        }
    }
}
