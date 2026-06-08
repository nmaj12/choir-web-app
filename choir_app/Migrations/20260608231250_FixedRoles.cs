using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace choir_app.Migrations
{
    /// <inheritdoc />
    public partial class FixedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "366c0137-4d47-4d2c-8069-b541aa0cbf99", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "366c0137-4d47-4d2c-8069-b541aa0cbf99");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "366c0137-4d47-4e46-88bb-de02acb0855f", null, "Admin", "ADMIN" },
                    { "ccf65e78-511a-4e9f-b53d-11078c1279d8", null, "Dyrygent", "DYRYGENT" },
                    { "f5e74280-b416-4842-a7ba-9ed473a0e3b4", null, "Chorzysta", "CHORZYSTA" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60b449ac-a4e0-4b0b-a559-3e3fa3f9c5df", "AQAAAAIAAYagAAAAECTAimr6EcCBUU0uxSToTrWQaEN/lv8+kyXZlOYc7fWHngQP93lciSvFNJ5leFGo8g==", "d321a766-bfe9-4436-a0d4-5399370a03e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "acbb5289-0de8-4b1b-b89f-b19241b10a74", "AQAAAAIAAYagAAAAEMlQP+esaSNlTIgQ68c19cq9CskWtgnC8jGsJR1TXlrl1HtIEs0O2ZYr36HubkcEQA==", "b746a6b3-0a07-446f-921c-b6dfa8299b29" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "366c0137-4d47-4e46-88bb-de02acb0855f", "1" },
                    { "f5e74280-b416-4842-a7ba-9ed473a0e3b4", "2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ccf65e78-511a-4e9f-b53d-11078c1279d8");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "366c0137-4d47-4e46-88bb-de02acb0855f", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f5e74280-b416-4842-a7ba-9ed473a0e3b4", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "366c0137-4d47-4e46-88bb-de02acb0855f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5e74280-b416-4842-a7ba-9ed473a0e3b4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "366c0137-4d47-4d2c-8069-b541aa0cbf99", null, "Admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cbca7009-e7b8-4dce-829e-7da580722fb5", "AQAAAAIAAYagAAAAEHhRqORmMZ26W9EIUSDzb7Keswzf1gj/rJc6WBY9wbRp7p1JWfqZFmMHvqLoyCFNHg==", "7f5080bc-d757-41be-a1d8-69fe79b15505" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5c162d7-bc90-4e54-8e81-4bab41ca2dbe", "AQAAAAIAAYagAAAAENdcBkmZXg9mKVJFfrl25T/UWdVEnvINZboUarTQFqJaUuX279wMQMG/SvFFHUayVw==", "fb08ebba-8c49-4c3e-8bc0-f025d238db70" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "366c0137-4d47-4d2c-8069-b541aa0cbf99", "1" });
        }
    }
}
