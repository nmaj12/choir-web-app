using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace choir_app.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "73ca6643-30ad-4364-979d-e200a7f47774", "admin@choir.pl", true, true, false, null, "ADMIN@CHOIR.PL", "ADMIN@CHOIR.PL", "AQAAAAIAAYagAAAAEHngQQy+jcRIwbiEbsznpHGAxmARGMvj0Zw6uovhaM/+ob8kAuaXSLFRNbNDqeH1uA==", null, false, "4e11d6b8-eccf-4536-829d-b070b61b5efa", false, "admin@choir.pl" });

            migrationBuilder.InsertData(
                table: "FileResources",
                columns: new[] { "Id", "FileName", "FilePath", "FileType", "UploadedAt" },
                values: new object[] { 1, "nuty.pdf", "/files/pdf/nuty.pdf", "pdf", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GalleryImages",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "Title", "UploadedById" },
                values: new object[] { 1, new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "/gallery/photo1.jpg", "Koncert 2025", "1" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Content", "CreatedAt", "Title" },
                values: new object[] { 2, "Próby w piątki zamiast środy", new DateTime(2026, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zmiana harmonogramu" });

            migrationBuilder.InsertData(
                table: "ChoirMembers",
                columns: new[] { "Id", "IsActive", "JoinDate", "Notes", "UserId", "Voice" },
                values: new object[] { 1, true, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin chór", "1", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChoirMembers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FileResources",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GalleryImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 1, 9, 11, 54, 712, DateTimeKind.Local).AddTicks(5658));
        }
    }
}
