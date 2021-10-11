using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Company.Project.EventDomain.Migrations
{
    public partial class CommentNotificationTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommentNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GUID = table.Column<Guid>(nullable: false),
                    CreatedOnDate = table.Column<DateTimeOffset>(nullable: false),
                    ModifiedOnDate = table.Column<DateTimeOffset>(nullable: false),
                    CreatedByUserID = table.Column<int>(nullable: false),
                    ModifiedByUserID = table.Column<int>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    EventOwnerId = table.Column<string>(nullable: true),
                    CommentContent = table.Column<string>(nullable: true),
                    NameOfPersonWhoCommented = table.Column<string>(nullable: true),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentNotifications", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "0dc580ac-7321-4f42-8d21-a349492488d0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f01bf581-8a37-450c-9daa-bc73e0319eb8", "AQAAAAEAACcQAAAAEG3S68wICs8Y+E0YmbZHGY0ToIyuiM5atmXNIeo414sONlyDFs9q7vhObSPkx4nrlQ==", "6a4cbb09-3915-48f2-9c8e-88532fb6ddf6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentNotifications");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "5c419c48-eef3-4dca-ba2c-b8e51619a661");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c6c11fd8-a9fc-4693-b0c7-84ff70ee201e", "AQAAAAEAACcQAAAAEMYnMxgsBX9Q11W7GP/J+GsoXqo79BdI+POWygdfniByJ288d9ZWCN0Q/Zd8IiTpYw==", "51a15552-5fe4-4bf6-b7e0-41254057c5cb" });
        }
    }
}
