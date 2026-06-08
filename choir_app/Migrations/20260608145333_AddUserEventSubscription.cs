using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace choir_app.Migrations
{
    /// <inheritdoc />
    public partial class AddUserEventSubscription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserEventSubscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEventSubscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEventSubscriptions_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21aae264-2821-43e8-88cd-0b88fde62dba", "AQAAAAIAAYagAAAAEGlH56ue+oc17YJP75g0Cv7p5v1NLSSMQfebyL+r5iyaDZX5nfPYr0USJh1ph3bbtQ==", "1c1692ad-666d-4157-9bfa-acf65269c9ba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4e51986-5dae-4db7-9a77-332c7da3ef20", "AQAAAAIAAYagAAAAEK3ISAXUeBAqfOFzv/+xR6kCy2+XO9vDlCS+bWlz+M42rj8gDVx237MeRu0BpStnTA==", "4238b956-9964-4b59-82fc-9709667b1bfd" });

            migrationBuilder.CreateIndex(
                name: "IX_UserEventSubscriptions_EventId",
                table: "UserEventSubscriptions",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEventSubscriptions");

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
    }
}
