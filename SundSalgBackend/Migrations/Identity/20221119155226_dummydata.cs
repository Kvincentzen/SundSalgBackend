using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SundSalgBackend.Migrations.Identity
{
    public partial class dummydata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f4a3f5f-fcb9-467e-a77b-7778c1c87f03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7e5f757-9e52-487d-9516-a34a17dcc9f7");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Counselors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3789d391-f7d6-43af-9fae-50af2b1c50d1", "da322656-da2e-4702-9e76-f3fce610afbf", "Administrator", "ADMINISTRATOR" },
                    { "5c968025-f28c-4a78-a71b-6910abc80b4d", "4f3b6255-03e0-473a-9130-585949ef9b35", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Counselors",
                columns: new[] { "Id", "Desc", "Name", "Picture", "Price" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum", "Mads Madsen", "", 299.99000000000001 },
                    { 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum", "Hanne Hansen", "", 420.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3789d391-f7d6-43af-9fae-50af2b1c50d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c968025-f28c-4a78-a71b-6910abc80b4d");

            migrationBuilder.DeleteData(
                table: "Counselors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Counselors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Counselors");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8f4a3f5f-fcb9-467e-a77b-7778c1c87f03", "b0dfd55e-484d-490d-bbb5-1da02bf74c1f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a7e5f757-9e52-487d-9516-a34a17dcc9f7", "ea30208d-3f88-4b24-8961-c32a46489955", "Administrator", "ADMINISTRATOR" });
        }
    }
}
