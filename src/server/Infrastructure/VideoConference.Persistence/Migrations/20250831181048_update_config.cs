using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoConference.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update_config : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organization_Users_OwnerId",
                table: "Organization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.AddColumn<Guid>(
                name: "ScopeId",
                table: "UserRoles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Organization",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId", "ScopeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Organization_Users_OwnerId",
                table: "Organization",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organization_Users_OwnerId",
                table: "Organization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "ScopeId",
                table: "UserRoles");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Organization",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Organization_Users_OwnerId",
                table: "Organization",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
