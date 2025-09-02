using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VideoConference.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "Scope" },
                values: new object[,]
                {
                    { new Guid("a46a7b39-95a4-4e43-9727-06b5568c6d83"), null, "CommunityMember", "COMMUNITYMEMBER", (byte)6 },
                    { new Guid("abce1401-ffba-419e-b517-18af8cff15d1"), null, "CommunityOwner", "COMMUNITYOWNER", (byte)6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a46a7b39-95a4-4e43-9727-06b5568c6d83"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("abce1401-ffba-419e-b517-18af8cff15d1"));
        }
    }
}
