using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace choir_app.Migrations
{
    /// <inheritdoc />
    public partial class AddFaqTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FaqEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaqEntries", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df7b7276-0b31-43c4-981e-48b2a1c9569b", "AQAAAAIAAYagAAAAEFACDYQqmqmPYv+5WRclDeF/ZC7wLQRGghfTurl2Wn/QW000NKLks50LRviNo+G6zA==", "9688eb9e-0ffd-497f-b4d4-7e0f9dbe6b37" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3db9a30-85a3-4307-ac75-da54a103d619", "AQAAAAIAAYagAAAAEKyfpkQlT+tnE9vCXoyz4ISZwxka3ZBt+mJPX1llwszlatcGUQdytyRsiu/Cw/Vjmw==", "6979d111-b83e-43b2-a25b-e46510b92013" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FaqEntries");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f03f4a5-91eb-4279-8ab0-0f109d1f0d7d", "AQAAAAIAAYagAAAAEDPaznTRG0ERA420IyDYd7m1SjFMsGl+bsp6dJ1tCu4N98jzSA8nvI8Lx7OrtyGD3A==", "9a851a1b-6f5c-4d69-8c70-7a73a12043f5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f498763c-b0aa-4f48-a59e-9e1d84a42d3f", "AQAAAAIAAYagAAAAEGpUoZbyH/JwfIivYXbdOlDK+ZbnyW/Q3PbH0jqlEXaUiSIFIm8heP5pa+MLLxxmNg==", "33075b37-4129-4fb3-9090-395cb6b7f14e" });
        }
    }
}
