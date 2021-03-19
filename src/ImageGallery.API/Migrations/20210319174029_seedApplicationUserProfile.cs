using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImageGallery.API.Migrations
{
    public partial class seedApplicationUserProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ApplicationUserProfiles",
                columns: new[] { "Id", "Subject", "SubscriptionLevel" },
                values: new object[] { new Guid("7f8ce18c-d156-4c85-9575-56bf59938b0c"), "d860efca-22d9-47fd-8249-791ba61b07c7", "FreeUser" });

            migrationBuilder.InsertData(
                table: "ApplicationUserProfiles",
                columns: new[] { "Id", "Subject", "SubscriptionLevel" },
                values: new object[] { new Guid("38ff72e7-834a-4f5d-a0d1-acfaffad05c2"), "b7539694-97e7-4dfe-84da-b4256e1ff5c7", "PayingUser" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationUserProfiles",
                keyColumn: "Id",
                keyValue: new Guid("38ff72e7-834a-4f5d-a0d1-acfaffad05c2"));

            migrationBuilder.DeleteData(
                table: "ApplicationUserProfiles",
                keyColumn: "Id",
                keyValue: new Guid("7f8ce18c-d156-4c85-9575-56bf59938b0c"));
        }
    }
}
