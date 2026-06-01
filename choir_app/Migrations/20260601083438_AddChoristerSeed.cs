using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace choir_app.Migrations
{
    /// <inheritdoc />
    public partial class AddChoristerSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f955614-6799-40a2-820d-f9c4c6cb9311", "AQAAAAIAAYagAAAAEDCpHK00uJMJsrFDS/nZ2xg+Q/EV2KFs3pzjVMWx3poW/SgeyjFcJFbN9cGbuhE+5w==", "e1169eab-8fe9-4351-b597-1986862fd929" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2", 0, "48eb39df-2a4a-4443-829d-5f63a97a271b", "jan.kowalski@choir.pl", true, true, false, null, "JAN.KOWALSKI@CHOIR.PL", "JAN.KOWALSKI@CHOIR.PL", "AQAAAAIAAYagAAAAEAFShhLVB/DVB/fAVRsO4FwOw34nb9W2X/Be3oedLYJjD8WLkD2/XhVD6r/vnbApOg==", null, false, "791b56ce-4e4a-459d-8cdd-1b028aef2587", false, "jan.kowalski@choir.pl" });

            migrationBuilder.InsertData(
                table: "ChoirMembers",
                columns: new[] { "Id", "IsActive", "JoinDate", "Notes", "UserId", "Voice" },
                values: new object[] { 2, true, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jan Kowalski", "2", 4 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChoirMembers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75b85f35-8125-45e2-b607-f102ef50cda5", "AQAAAAIAAYagAAAAEGfXTwIXZQH74mYzqKOqHYA/+RMONiMrmXRGn7DKmz5dbwN+mHRJUiqRxcZwKF7UoQ==", "0ae13f52-baab-41ce-a954-907a5373c72d" });
        }
    }
}
