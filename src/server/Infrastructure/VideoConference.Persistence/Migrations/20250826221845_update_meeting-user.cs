using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoConference.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update_meetinguser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Meetings",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_OrganizerId",
                table: "Meetings",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_UserId",
                table: "Meetings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_AspNetUsers_OrganizerId",
                table: "Meetings",
                column: "OrganizerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_AspNetUsers_UserId",
                table: "Meetings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_AspNetUsers_OrganizerId",
                table: "Meetings");

            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_AspNetUsers_UserId",
                table: "Meetings");

            migrationBuilder.DropIndex(
                name: "IX_Meetings_OrganizerId",
                table: "Meetings");

            migrationBuilder.DropIndex(
                name: "IX_Meetings_UserId",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Meetings");
        }
    }
}
