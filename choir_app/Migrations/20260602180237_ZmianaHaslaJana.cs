using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace choir_app.Migrations
{
    /// <inheritdoc />
    public partial class ZmianaHaslaJana : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0b9c0bd-4a82-41ef-8b53-7e34f0ae1a8c", "AQAAAAIAAYagAAAAEBHgy0VJAu6BpV1E3iXuSRnyrkQgWYHGItrw77vBDPzlqHcNV5vewJt9rx/vwrRszw==", "88dbcc42-ada8-4845-bcca-2d4f751dba51" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf15de15-c1d9-4d52-9860-80426cf0c669", "AQAAAAIAAYagAAAAEEd7Qaj2ww96V1qprIp2S30OqMyePwvU6/9XT5MBnZRHNCRhwmTBkYWYPJsmidf1CA==", "507c0aac-5606-4f79-a901-69decea20275" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f955614-6799-40a2-820d-f9c4c6cb9311", "AQAAAAIAAYagAAAAEDCpHK00uJMJsrFDS/nZ2xg+Q/EV2KFs3pzjVMWx3poW/SgeyjFcJFbN9cGbuhE+5w==", "e1169eab-8fe9-4351-b597-1986862fd929" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48eb39df-2a4a-4443-829d-5f63a97a271b", "AQAAAAIAAYagAAAAEAFShhLVB/DVB/fAVRsO4FwOw34nb9W2X/Be3oedLYJjD8WLkD2/XhVD6r/vnbApOg==", "791b56ce-4e4a-459d-8cdd-1b028aef2587" });
        }
    }
}
