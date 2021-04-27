using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IServer.IDP.Migrations.IdentityDb
{
    public partial class AddEmailAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("047d13e4-08ed-4efc-8021-9c866bd0aa40"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("04b34437-a113-43a3-bb8e-7a82487210d3"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("1226d237-1552-4aa7-bde4-bb74fa3447d3"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("1ac36761-7047-4560-a095-ffa7040c8a27"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("2c02ac4c-4631-4f5e-ae37-cba69afdc607"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("44cd0ae4-c0bd-4537-b661-37fd04ee538c"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("748e338c-b4ec-43e0-aeeb-b93a0a34ad7b"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("c79d011b-b602-414a-bb17-e89072c1173f"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("d9f96eef-10bb-4c94-82e9-66a0fdc167e6"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("fcc164a8-3876-40ec-ae85-7594140e89fa"));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecurityCode",
                table: "Users",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SecurityCodeExpirationDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("49ef4147-92b1-44fa-8985-b49427b13498"), "aec20383-b883-42b1-9b01-d995e4490b5b", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Frank" },
                    { new Guid("3ec1552e-981f-4746-a0e1-67e1c1da659e"), "05f5b624-b226-4b16-ab9e-8d1b72b33c9d", "email", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "frank@someprovider.com" },
                    { new Guid("e2a42ece-e2b5-49df-bc4e-03aa7ed25e40"), "74959fa3-1205-4468-b524-5c16ef2dc542", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Underwood" },
                    { new Guid("0ad73c4e-77f2-4901-9471-19c4118d917b"), "cc3c2461-7440-4896-9c18-591bf58f76ec", "address", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Main Road 1" },
                    { new Guid("2fcdb59a-10a3-4852-a983-6b14a332165d"), "9e524fdf-d494-46fd-bc36-b2352254d3f1", "subscriptionlevel", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" },
                    { new Guid("a081ddc5-1913-4a15-a942-01cf1cdc8ce3"), "32f36104-4528-4df0-ac8f-2dcc51efad34", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" },
                    { new Guid("c4c4d278-99bb-4c2d-b75d-f84ed3cd7239"), "1fc3bb6b-a549-4aa1-acc1-ec7cfbb4b59b", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Claire" },
                    { new Guid("f1e96bca-7187-493e-a4fb-373a956da427"), "ae90995d-c576-4c7c-a8df-96bbcafb3ee4", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Underwood" },
                    { new Guid("aa451e92-533c-4a0d-889e-0b2c3e01a1b5"), "87d72f49-ca23-498d-a4eb-c21fcf87b6eb", "email", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "claire@someprovider.com" },
                    { new Guid("5bc287b2-47ac-4d46-af9c-dd21369297a6"), "2ba25b43-7829-4b01-b195-9f464af2721e", "address", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Big Street 2" },
                    { new Guid("18098b8f-f941-4667-af05-2af44e5d4f07"), "9a381320-b7b8-40fe-8516-242984f6dd9e", "subscriptionlevel", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" },
                    { new Guid("ae9a1559-57c4-4665-9683-bc26391dbe9d"), "ab3c9453-fde4-46e3-a4ac-b7fdcfe779ad", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                column: "ConcurrencyStamp",
                value: "dd7fbbbc-2928-4f27-b952-a1aa08482e13");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                column: "ConcurrencyStamp",
                value: "da58e617-4abb-4aef-852e-83d5492b5da8");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("0ad73c4e-77f2-4901-9471-19c4118d917b"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("18098b8f-f941-4667-af05-2af44e5d4f07"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("2fcdb59a-10a3-4852-a983-6b14a332165d"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("3ec1552e-981f-4746-a0e1-67e1c1da659e"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("49ef4147-92b1-44fa-8985-b49427b13498"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("5bc287b2-47ac-4d46-af9c-dd21369297a6"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("a081ddc5-1913-4a15-a942-01cf1cdc8ce3"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("aa451e92-533c-4a0d-889e-0b2c3e01a1b5"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("ae9a1559-57c4-4665-9683-bc26391dbe9d"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("c4c4d278-99bb-4c2d-b75d-f84ed3cd7239"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("e2a42ece-e2b5-49df-bc4e-03aa7ed25e40"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("f1e96bca-7187-493e-a4fb-373a956da427"));

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecurityCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecurityCodeExpirationDate",
                table: "Users");

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("748e338c-b4ec-43e0-aeeb-b93a0a34ad7b"), "c3cb9b30-6a9d-4dab-bba6-a8ac7f4c509e", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Frank" },
                    { new Guid("44cd0ae4-c0bd-4537-b661-37fd04ee538c"), "b3a8855f-fd83-47cf-b5f0-c4073dd0bd6d", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Underwood" },
                    { new Guid("c79d011b-b602-414a-bb17-e89072c1173f"), "a5c0d59a-148b-480e-96ab-41d517bf0b09", "address", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Main Road 1" },
                    { new Guid("1226d237-1552-4aa7-bde4-bb74fa3447d3"), "a4685dd4-3ecd-4813-8d10-14f2c24bd9b5", "subscriptionlevel", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" },
                    { new Guid("2c02ac4c-4631-4f5e-ae37-cba69afdc607"), "175b03c0-b030-495f-a9bd-d839c1c6f9c8", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" },
                    { new Guid("04b34437-a113-43a3-bb8e-7a82487210d3"), "ddab34b2-5363-488a-bcd9-daa1ed82efc9", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Claire" },
                    { new Guid("047d13e4-08ed-4efc-8021-9c866bd0aa40"), "a5abfbf0-ab67-4a10-b4d0-ba8d4e83851a", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Underwood" },
                    { new Guid("d9f96eef-10bb-4c94-82e9-66a0fdc167e6"), "cd7c257c-f151-42ba-8238-d3676d92d781", "address", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Big Street 2" },
                    { new Guid("fcc164a8-3876-40ec-ae85-7594140e89fa"), "8d0c9700-8a38-4a9a-8b72-df22b300bd79", "subscriptionlevel", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" },
                    { new Guid("1ac36761-7047-4560-a095-ffa7040c8a27"), "d687c88f-547a-4284-9380-0cefd93c5658", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                column: "ConcurrencyStamp",
                value: "a92b1b13-f961-454b-ab3c-c32c22dfc8de");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                column: "ConcurrencyStamp",
                value: "4ea0ee94-0f02-45c3-88a8-ef4319fe2c90");
        }
    }
}
