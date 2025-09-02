using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoConference.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class communityupdatedbcontext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Channels_Community_CommunityId",
                table: "Channels");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunityMember_Community_CommunityId",
                table: "CommunityMember");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunityMember_Roles_RoleId",
                table: "CommunityMember");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunityMember_Users_UserId",
                table: "CommunityMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommunityMember",
                table: "CommunityMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Community",
                table: "Community");

            migrationBuilder.RenameTable(
                name: "CommunityMember",
                newName: "CommunityMembers");

            migrationBuilder.RenameTable(
                name: "Community",
                newName: "Communities");

            migrationBuilder.RenameIndex(
                name: "IX_CommunityMember_UserId",
                table: "CommunityMembers",
                newName: "IX_CommunityMembers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CommunityMember_RoleId",
                table: "CommunityMembers",
                newName: "IX_CommunityMembers_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_CommunityMember_CommunityId",
                table: "CommunityMembers",
                newName: "IX_CommunityMembers_CommunityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommunityMembers",
                table: "CommunityMembers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Communities",
                table: "Communities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Channels_Communities_CommunityId",
                table: "Channels",
                column: "CommunityId",
                principalTable: "Communities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityMembers_Communities_CommunityId",
                table: "CommunityMembers",
                column: "CommunityId",
                principalTable: "Communities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityMembers_Roles_RoleId",
                table: "CommunityMembers",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityMembers_Users_UserId",
                table: "CommunityMembers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Channels_Communities_CommunityId",
                table: "Channels");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunityMembers_Communities_CommunityId",
                table: "CommunityMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunityMembers_Roles_RoleId",
                table: "CommunityMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunityMembers_Users_UserId",
                table: "CommunityMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommunityMembers",
                table: "CommunityMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Communities",
                table: "Communities");

            migrationBuilder.RenameTable(
                name: "CommunityMembers",
                newName: "CommunityMember");

            migrationBuilder.RenameTable(
                name: "Communities",
                newName: "Community");

            migrationBuilder.RenameIndex(
                name: "IX_CommunityMembers_UserId",
                table: "CommunityMember",
                newName: "IX_CommunityMember_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CommunityMembers_RoleId",
                table: "CommunityMember",
                newName: "IX_CommunityMember_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_CommunityMembers_CommunityId",
                table: "CommunityMember",
                newName: "IX_CommunityMember_CommunityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommunityMember",
                table: "CommunityMember",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Community",
                table: "Community",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Channels_Community_CommunityId",
                table: "Channels",
                column: "CommunityId",
                principalTable: "Community",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityMember_Community_CommunityId",
                table: "CommunityMember",
                column: "CommunityId",
                principalTable: "Community",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityMember_Roles_RoleId",
                table: "CommunityMember",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityMember_Users_UserId",
                table: "CommunityMember",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
