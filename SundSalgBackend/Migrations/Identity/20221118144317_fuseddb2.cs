using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SundSalgBackend.Migrations.Identity
{
    public partial class fuseddb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2cf3dbf-01e3-4512-af35-415e74e02d6f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd6a3fcf-23f4-4f9f-89ba-125ba8f43c42");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8f4a3f5f-fcb9-467e-a77b-7778c1c87f03", "b0dfd55e-484d-490d-bbb5-1da02bf74c1f", "User", "USER" },
                    { "a7e5f757-9e52-487d-9516-a34a17dcc9f7", "ea30208d-3f88-4b24-8961-c32a46489955", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Desc", "Name", "Picture", "Price" },
                values: new object[,]
                {
                    { 1, "Med banan og chokolade smag", "Protein Pulver", "", 320.19999999999999 },
                    { 2, "Brug max 5g om dagen", "Kreatin Pulver", "", 119.95 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f4a3f5f-fcb9-467e-a77b-7778c1c87f03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7e5f757-9e52-487d-9516-a34a17dcc9f7");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e2cf3dbf-01e3-4512-af35-415e74e02d6f", "56a7407e-3187-407f-9928-569451e3bb9a", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fd6a3fcf-23f4-4f9f-89ba-125ba8f43c42", "54d31e40-cdb2-4284-a558-6cea13ba72ee", "User", "USER" });
        }
    }
}
