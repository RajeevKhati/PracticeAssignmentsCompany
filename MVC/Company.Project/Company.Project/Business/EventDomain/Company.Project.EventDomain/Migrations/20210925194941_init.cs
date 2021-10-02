using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Company.Project.EventDomain.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
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
                    TitleOfBook = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
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
                    FullName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventsAndPeople",
                columns: table => new
                {
                    PersonID = table.Column<int>(nullable: false),
                    EventID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsAndPeople", x => new { x.PersonID, x.EventID });
                    table.ForeignKey(
                        name: "FK_EventsAndPeople_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventsAndPeople_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedByUserID", "CreatedOnDate", "Date", "GUID", "IsActive", "IsDeleted", "Location", "ModifiedByUserID", "ModifiedOnDate", "TitleOfBook", "UserID" },
                values: new object[,]
                {
                    { 1, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2021, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a8467e01-cbe7-4fe2-a644-4529f4185aaa"), false, false, "mahim", 0, new DateTimeOffset(new DateTime(2021, 9, 26, 1, 19, 41, 527, DateTimeKind.Unspecified).AddTicks(3882), new TimeSpan(0, 5, 30, 0, 0)), "positivity", 1 },
                    { 2, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2021, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7498c51f-e7ed-4e84-89ba-3545d71cc9de"), false, false, "bandra", 0, new DateTimeOffset(new DateTime(2021, 9, 26, 1, 19, 41, 527, DateTimeKind.Unspecified).AddTicks(5162), new TimeSpan(0, 5, 30, 0, 0)), "war", 1 },
                    { 3, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2021, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3bb73d53-c9ca-4af6-990e-d319543d5550"), false, false, "dadar", 0, new DateTimeOffset(new DateTime(2021, 9, 26, 1, 19, 41, 527, DateTimeKind.Unspecified).AddTicks(5227), new TimeSpan(0, 5, 30, 0, 0)), "21 days", 5 },
                    { 4, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2020, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8e357081-bbe6-461f-8e7d-fcf2e4e72f8d"), false, false, "vasai", 0, new DateTimeOffset(new DateTime(2021, 9, 26, 1, 19, 41, 527, DateTimeKind.Unspecified).AddTicks(5232), new TimeSpan(0, 5, 30, 0, 0)), "rudest book ever", 5 },
                    { 5, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2021, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("48b13cfa-cbe5-4d6f-a5ce-25c052269b0f"), false, false, "vile parle", 0, new DateTimeOffset(new DateTime(2021, 9, 26, 1, 19, 41, 527, DateTimeKind.Unspecified).AddTicks(5235), new TimeSpan(0, 5, 30, 0, 0)), "rag to rich", 6 },
                    { 6, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2021, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("36abfa40-f10b-4c7a-86d1-874f8036e5e5"), false, false, "naigaon", 0, new DateTimeOffset(new DateTime(2021, 9, 26, 1, 19, 41, 527, DateTimeKind.Unspecified).AddTicks(5238), new TimeSpan(0, 5, 30, 0, 0)), "rich dad poor dad", 3 }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "CreatedByUserID", "CreatedOnDate", "Email", "FullName", "GUID", "IsActive", "IsDeleted", "ModifiedByUserID", "ModifiedOnDate" },
                values: new object[,]
                {
                    { 1, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "adarsh@gmail.com", "adarsh singhai", new Guid("9608df64-6cb0-4ccf-bd82-0617d544525b"), false, false, 0, new DateTimeOffset(new DateTime(2021, 9, 26, 1, 19, 41, 525, DateTimeKind.Unspecified).AddTicks(2265), new TimeSpan(0, 5, 30, 0, 0)) },
                    { 2, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "raj@gmail.com", "raj chakra", new Guid("5ee3bd89-6375-4e7a-9aa1-db9c46fb4f92"), false, false, 0, new DateTimeOffset(new DateTime(2021, 9, 26, 1, 19, 41, 527, DateTimeKind.Unspecified).AddTicks(3504), new TimeSpan(0, 5, 30, 0, 0)) },
                    { 3, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "sanket@yahoo.com", "sanket jain", new Guid("0865eefd-96f5-4cb2-9a5a-dfbb1acdf314"), false, false, 0, new DateTimeOffset(new DateTime(2021, 9, 26, 1, 19, 41, 527, DateTimeKind.Unspecified).AddTicks(3552), new TimeSpan(0, 5, 30, 0, 0)) },
                    { 4, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "himanshu@yahoo.com", "himanshu jain", new Guid("90751c8f-2767-4314-8e61-2c956b4a18e6"), false, false, 0, new DateTimeOffset(new DateTime(2021, 9, 26, 1, 19, 41, 527, DateTimeKind.Unspecified).AddTicks(3557), new TimeSpan(0, 5, 30, 0, 0)) },
                    { 5, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "deepanshu@gmail.com", "deepanshu jain", new Guid("60491969-e7a4-45ed-960b-5dd139891b42"), false, false, 0, new DateTimeOffset(new DateTime(2021, 9, 26, 1, 19, 41, 527, DateTimeKind.Unspecified).AddTicks(3559), new TimeSpan(0, 5, 30, 0, 0)) },
                    { 6, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "dheeraj@zoho.com", "dheeraj jain", new Guid("58218d60-ff1c-4c50-b0d2-0c13b86ecff0"), false, false, 0, new DateTimeOffset(new DateTime(2021, 9, 26, 1, 19, 41, 527, DateTimeKind.Unspecified).AddTicks(3563), new TimeSpan(0, 5, 30, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "EventsAndPeople",
                columns: new[] { "PersonID", "EventID" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "EventsAndPeople",
                columns: new[] { "PersonID", "EventID" },
                values: new object[] { 2, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_EventsAndPeople_EventID",
                table: "EventsAndPeople",
                column: "EventID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventsAndPeople");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
