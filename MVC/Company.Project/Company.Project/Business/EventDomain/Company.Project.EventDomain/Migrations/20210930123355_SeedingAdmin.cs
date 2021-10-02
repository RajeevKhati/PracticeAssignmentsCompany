using Microsoft.EntityFrameworkCore.Migrations;

namespace Company.Project.EventDomain.Migrations
{
    public partial class SeedingAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "5c419c48-eef3-4dca-ba2c-b8e51619a661", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "c6c11fd8-a9fc-4693-b0c7-84ff70ee201e", "myadmin@bookevents.com", true, "admin", false, null, "myadmin@bookevents.com", "myadmin@bookevents.com", "AQAAAAEAACcQAAAAEMYnMxgsBX9Q11W7GP/J+GsoXqo79BdI+POWygdfniByJ288d9ZWCN0Q/Zd8IiTpYw==", null, false, "51a15552-5fe4-4bf6-b7e0-41254057c5cb", false, "myadmin@bookevents.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb9", "2c5e174e-3b0e-446f-86af-483d56fd7210" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb9", "2c5e174e-3b0e-446f-86af-483d56fd7210" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9");
        }
    }
}
