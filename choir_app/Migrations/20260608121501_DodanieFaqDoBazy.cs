using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace choir_app.Migrations
{
    /// <inheritdoc />
    public partial class DodanieFaqDoBazy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "204b6beb-ebfe-4eb9-a3a3-7cf6666b8a30", "AQAAAAIAAYagAAAAEBeK+3kq4D4CWPOo2X7dkM8e6D3SaQeFWJEvRMvY7+O3TNRofh9yZ6G1KwXfS0rJ5g==", "80417f7b-95fd-41d0-a0ea-ad22dd7286e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c0d12441-55e6-4c4b-bc8e-896d38f3d390", "AQAAAAIAAYagAAAAENVltb8JhU21U+4lFdnhZlnU+7dhYjFbH9gvonYzEicQkbLDsRlCHbVK0NcGcAENzg==", "5f16c8d9-cc3b-4c80-855e-6fe69e0522a5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c95b6b6-8ac4-47e5-a9e5-dde4edb6d5c2", "AQAAAAIAAYagAAAAENVzHtYi2mj8YTUImcy/tOXOmu4iCeCBebgzMO596HN0o+hH5ebTTcOd/hDk0//b0w==", "39466028-8bc1-48ad-b162-93759f63329e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0e8d7f8-0725-4f7f-82a0-90d840542c31", "AQAAAAIAAYagAAAAEPyxMH9M/1edRAKKLnOejujyrJexr9wi74hzwimFwnj8EjELcUXdPU83tTNuR4IFgg==", "523df951-88f3-4906-845b-3861e84f8e03" });
        }
    }
}
