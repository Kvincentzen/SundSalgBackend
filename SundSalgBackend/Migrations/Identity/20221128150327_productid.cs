using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SundSalgBackend.Migrations.Identity
{
    public partial class productid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3789d391-f7d6-43af-9fae-50af2b1c50d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c968025-f28c-4a78-a71b-6910abc80b4d");

            migrationBuilder.AddColumn<string>(
                name: "PriceId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ee7a994-607e-435a-9f25-3ffe81d2680e", "4876a140-db5e-44f4-8190-6fc9c0f71e35", "Administrator", "ADMINISTRATOR" },
                    { "a8f1d782-4892-4260-a59a-929b485b54f9", "12616ed2-79a5-4bae-b630-0f8fc2fd5c8e", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Price", "PriceId" },
                values: new object[] { 125.0, "price_1M97kuJYRgEBAqqdoaKBOfkY" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "PriceId",
                value: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ee7a994-607e-435a-9f25-3ffe81d2680e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8f1d782-4892-4260-a59a-929b485b54f9");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3789d391-f7d6-43af-9fae-50af2b1c50d1", "da322656-da2e-4702-9e76-f3fce610afbf", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5c968025-f28c-4a78-a71b-6910abc80b4d", "4f3b6255-03e0-473a-9130-585949ef9b35", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 320.19999999999999);
        }
    }
}
