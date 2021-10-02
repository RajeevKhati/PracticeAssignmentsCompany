using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Company.Project.EventDomain.Migrations
{
    public partial class AddedIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("2e34a494-5967-4433-aa5b-a4846236a308"), new DateTimeOffset(new DateTime(2021, 9, 28, 22, 57, 11, 181, DateTimeKind.Unspecified).AddTicks(9562), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("c868a3ae-5a2b-43ea-ac85-75efa83a37f4"), new DateTimeOffset(new DateTime(2021, 9, 28, 22, 57, 11, 182, DateTimeKind.Unspecified).AddTicks(1170), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("ec3b919d-7025-4898-a7e2-b36483132c65"), new DateTimeOffset(new DateTime(2021, 9, 28, 22, 57, 11, 182, DateTimeKind.Unspecified).AddTicks(1231), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("6bc39e0d-d0bd-40b4-a007-0e5f84e8ae7c"), new DateTimeOffset(new DateTime(2021, 9, 28, 22, 57, 11, 182, DateTimeKind.Unspecified).AddTicks(1236), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("0a1c3e1d-1f22-4464-afab-9f621cef2d3c"), new DateTimeOffset(new DateTime(2021, 9, 28, 22, 57, 11, 182, DateTimeKind.Unspecified).AddTicks(1240), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("b46846df-486a-431d-8a33-f3f4cc8417a5"), new DateTimeOffset(new DateTime(2021, 9, 28, 22, 57, 11, 182, DateTimeKind.Unspecified).AddTicks(1244), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "EventsAndPeople",
                keyColumns: new[] { "PersonID", "EventID" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("1daaad12-ed45-4ee0-9c0c-b9aaa73c0dea"), new DateTimeOffset(new DateTime(2021, 9, 28, 22, 57, 11, 182, DateTimeKind.Unspecified).AddTicks(1631), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "EventsAndPeople",
                keyColumns: new[] { "PersonID", "EventID" },
                keyValues: new object[] { 2, 3 },
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("dffaf8a9-acb5-477c-aa70-0a37d818b363"), new DateTimeOffset(new DateTime(2021, 9, 28, 22, 57, 11, 182, DateTimeKind.Unspecified).AddTicks(2316), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("01908f6a-c596-4809-bd3b-c4917dc955bd"), new DateTimeOffset(new DateTime(2021, 9, 28, 22, 57, 11, 179, DateTimeKind.Unspecified).AddTicks(445), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("07eaab66-4c99-4ac4-822c-f0797be0d6f8"), new DateTimeOffset(new DateTime(2021, 9, 28, 22, 57, 11, 181, DateTimeKind.Unspecified).AddTicks(8973), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("7a8dee8c-1bfd-425b-903e-6ee8adc6241a"), new DateTimeOffset(new DateTime(2021, 9, 28, 22, 57, 11, 181, DateTimeKind.Unspecified).AddTicks(9041), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("a24209e4-c159-4e96-9824-29bd030e3c5d"), new DateTimeOffset(new DateTime(2021, 9, 28, 22, 57, 11, 181, DateTimeKind.Unspecified).AddTicks(9047), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("273712a5-0ca2-4d83-a97f-ff128f5e8579"), new DateTimeOffset(new DateTime(2021, 9, 28, 22, 57, 11, 181, DateTimeKind.Unspecified).AddTicks(9051), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("658ad1d1-00ed-4e37-b03d-a5100a0672fc"), new DateTimeOffset(new DateTime(2021, 9, 28, 22, 57, 11, 181, DateTimeKind.Unspecified).AddTicks(9055), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("e7507e5d-972b-4b47-9066-88a25f8e9c7b"), new DateTimeOffset(new DateTime(2021, 9, 28, 17, 53, 55, 502, DateTimeKind.Unspecified).AddTicks(7360), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("942da320-f0d0-4dd1-9109-2bf5bab982c7"), new DateTimeOffset(new DateTime(2021, 9, 28, 17, 53, 55, 502, DateTimeKind.Unspecified).AddTicks(9171), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("21d02769-9587-454d-a5ae-cbdfda72b696"), new DateTimeOffset(new DateTime(2021, 9, 28, 17, 53, 55, 502, DateTimeKind.Unspecified).AddTicks(9231), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("466fbead-f90f-43c7-85c7-3bf4f046fe81"), new DateTimeOffset(new DateTime(2021, 9, 28, 17, 53, 55, 502, DateTimeKind.Unspecified).AddTicks(9235), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("48347c4e-b74c-4c32-bda2-3574c96d3ba6"), new DateTimeOffset(new DateTime(2021, 9, 28, 17, 53, 55, 502, DateTimeKind.Unspecified).AddTicks(9239), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("9605ba54-a9d9-4dba-80e7-bc6a014e0852"), new DateTimeOffset(new DateTime(2021, 9, 28, 17, 53, 55, 502, DateTimeKind.Unspecified).AddTicks(9253), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "EventsAndPeople",
                keyColumns: new[] { "PersonID", "EventID" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("c3e82b9a-29b3-48f6-adab-ea43ae0dbedb"), new DateTimeOffset(new DateTime(2021, 9, 28, 17, 53, 55, 502, DateTimeKind.Unspecified).AddTicks(9605), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "EventsAndPeople",
                keyColumns: new[] { "PersonID", "EventID" },
                keyValues: new object[] { 2, 3 },
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("5716844b-8c1a-4bdf-b144-23bc13b430e9"), new DateTimeOffset(new DateTime(2021, 9, 28, 17, 53, 55, 503, DateTimeKind.Unspecified).AddTicks(175), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("f2f8ca18-897e-4325-b9c0-3f1c645ab180"), new DateTimeOffset(new DateTime(2021, 9, 28, 17, 53, 55, 500, DateTimeKind.Unspecified).AddTicks(3076), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("d0af2852-5cc1-475f-8e91-b11e381e67fa"), new DateTimeOffset(new DateTime(2021, 9, 28, 17, 53, 55, 502, DateTimeKind.Unspecified).AddTicks(6656), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("869d765a-89c7-4983-ad1d-2637f36e33c8"), new DateTimeOffset(new DateTime(2021, 9, 28, 17, 53, 55, 502, DateTimeKind.Unspecified).AddTicks(6724), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("ae1dfe9a-f65c-4a0b-9974-573722bdc2fd"), new DateTimeOffset(new DateTime(2021, 9, 28, 17, 53, 55, 502, DateTimeKind.Unspecified).AddTicks(6729), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("bf5bb279-01f7-4bf2-94d4-a10ad4f41e03"), new DateTimeOffset(new DateTime(2021, 9, 28, 17, 53, 55, 502, DateTimeKind.Unspecified).AddTicks(6732), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("656f3121-d311-4b29-865f-6b835e0f734c"), new DateTimeOffset(new DateTime(2021, 9, 28, 17, 53, 55, 502, DateTimeKind.Unspecified).AddTicks(6735), new TimeSpan(0, 5, 30, 0, 0)) });
        }
    }
}
