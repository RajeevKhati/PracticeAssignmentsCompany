using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Company.Project.EventDomain.Migrations
{
    public partial class AddedEventColumnsAndCommentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserID",
                table: "EventsAndPeople",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedOnDate",
                table: "EventsAndPeople",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "GUID",
                table: "EventsAndPeople",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventsAndPeople",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "EventsAndPeople",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "EventsAndPeople",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserID",
                table: "EventsAndPeople",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedOnDate",
                table: "EventsAndPeople",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "EventsAndPeople",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Events",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DurationInHours",
                table: "Events",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OtherDetails",
                table: "Events",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                table: "Events",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<bool>(
                name: "Type",
                table: "Events",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Comments",
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
                    Content = table.Column<string>(nullable: false),
                    EventID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("ae9c2cf4-dbcb-4c8b-9ab8-568e71bc5b79"), new DateTimeOffset(new DateTime(2021, 9, 28, 17, 4, 58, 969, DateTimeKind.Unspecified).AddTicks(1221), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("6c6df98b-38e9-4fa8-8aac-5476d941a919"), new DateTimeOffset(new DateTime(2021, 9, 28, 17, 4, 58, 969, DateTimeKind.Unspecified).AddTicks(2351), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("20f6b53b-e569-4afe-8bbf-7fb577b1d814"), new DateTimeOffset(new DateTime(2021, 9, 28, 17, 4, 58, 969, DateTimeKind.Unspecified).AddTicks(2405), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("21771663-e828-4ed9-9de2-738c52e1066e"), new DateTimeOffset(new DateTime(2021, 9, 28, 17, 4, 58, 969, DateTimeKind.Unspecified).AddTicks(2409), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("77bde19f-8fc5-4489-b99a-f7503e83098f"), new DateTimeOffset(new DateTime(2021, 9, 28, 17, 4, 58, 969, DateTimeKind.Unspecified).AddTicks(2413), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("d0ba40df-ec71-4575-a6f1-658db318ea3e"), new DateTimeOffset(new DateTime(2021, 9, 28, 17, 4, 58, 969, DateTimeKind.Unspecified).AddTicks(2417), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "EventsAndPeople",
                keyColumns: new[] { "PersonID", "EventID" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("8e254b3e-5191-46aa-ac6e-356f5ad2e500"), new DateTimeOffset(new DateTime(2021, 9, 28, 17, 4, 58, 969, DateTimeKind.Unspecified).AddTicks(2692), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "EventsAndPeople",
                keyColumns: new[] { "PersonID", "EventID" },
                keyValues: new object[] { 2, 3 },
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("944ed77e-6679-495c-8287-b37a1e8a3299"), new DateTimeOffset(new DateTime(2021, 9, 28, 17, 4, 58, 969, DateTimeKind.Unspecified).AddTicks(3184), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("aea7381a-edb0-4eb9-b928-46555a905adf"), new DateTimeOffset(new DateTime(2021, 9, 28, 17, 4, 58, 966, DateTimeKind.Unspecified).AddTicks(8203), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("54f9c957-03b9-4003-8e62-5bf9916f0701"), new DateTimeOffset(new DateTime(2021, 9, 28, 17, 4, 58, 969, DateTimeKind.Unspecified).AddTicks(826), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("6c32211a-30eb-479c-9034-9a4c05da865d"), new DateTimeOffset(new DateTime(2021, 9, 28, 17, 4, 58, 969, DateTimeKind.Unspecified).AddTicks(882), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("e57766b3-5e4b-44e0-8e30-0e281051348f"), new DateTimeOffset(new DateTime(2021, 9, 28, 17, 4, 58, 969, DateTimeKind.Unspecified).AddTicks(887), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("5878ed5a-83c6-43ba-aa69-776a17e3daff"), new DateTimeOffset(new DateTime(2021, 9, 28, 17, 4, 58, 969, DateTimeKind.Unspecified).AddTicks(890), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("974e564d-6c0f-4c13-b5ff-2b86b7df6e8d"), new DateTimeOffset(new DateTime(2021, 9, 28, 17, 4, 58, 969, DateTimeKind.Unspecified).AddTicks(892), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_EventID",
                table: "Comments",
                column: "EventID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropColumn(
                name: "CreatedByUserID",
                table: "EventsAndPeople");

            migrationBuilder.DropColumn(
                name: "CreatedOnDate",
                table: "EventsAndPeople");

            migrationBuilder.DropColumn(
                name: "GUID",
                table: "EventsAndPeople");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventsAndPeople");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "EventsAndPeople");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EventsAndPeople");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserID",
                table: "EventsAndPeople");

            migrationBuilder.DropColumn(
                name: "ModifiedOnDate",
                table: "EventsAndPeople");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "EventsAndPeople");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "DurationInHours",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "OtherDetails",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Events");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("a8467e01-cbe7-4fe2-a644-4529f4185aaa"), new DateTimeOffset(new DateTime(2021, 9, 26, 1, 19, 41, 527, DateTimeKind.Unspecified).AddTicks(3882), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("7498c51f-e7ed-4e84-89ba-3545d71cc9de"), new DateTimeOffset(new DateTime(2021, 9, 26, 1, 19, 41, 527, DateTimeKind.Unspecified).AddTicks(5162), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("3bb73d53-c9ca-4af6-990e-d319543d5550"), new DateTimeOffset(new DateTime(2021, 9, 26, 1, 19, 41, 527, DateTimeKind.Unspecified).AddTicks(5227), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("8e357081-bbe6-461f-8e7d-fcf2e4e72f8d"), new DateTimeOffset(new DateTime(2021, 9, 26, 1, 19, 41, 527, DateTimeKind.Unspecified).AddTicks(5232), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("48b13cfa-cbe5-4d6f-a5ce-25c052269b0f"), new DateTimeOffset(new DateTime(2021, 9, 26, 1, 19, 41, 527, DateTimeKind.Unspecified).AddTicks(5235), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("36abfa40-f10b-4c7a-86d1-874f8036e5e5"), new DateTimeOffset(new DateTime(2021, 9, 26, 1, 19, 41, 527, DateTimeKind.Unspecified).AddTicks(5238), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("9608df64-6cb0-4ccf-bd82-0617d544525b"), new DateTimeOffset(new DateTime(2021, 9, 26, 1, 19, 41, 525, DateTimeKind.Unspecified).AddTicks(2265), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("5ee3bd89-6375-4e7a-9aa1-db9c46fb4f92"), new DateTimeOffset(new DateTime(2021, 9, 26, 1, 19, 41, 527, DateTimeKind.Unspecified).AddTicks(3504), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("0865eefd-96f5-4cb2-9a5a-dfbb1acdf314"), new DateTimeOffset(new DateTime(2021, 9, 26, 1, 19, 41, 527, DateTimeKind.Unspecified).AddTicks(3552), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("90751c8f-2767-4314-8e61-2c956b4a18e6"), new DateTimeOffset(new DateTime(2021, 9, 26, 1, 19, 41, 527, DateTimeKind.Unspecified).AddTicks(3557), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("60491969-e7a4-45ed-960b-5dd139891b42"), new DateTimeOffset(new DateTime(2021, 9, 26, 1, 19, 41, 527, DateTimeKind.Unspecified).AddTicks(3559), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "GUID", "ModifiedOnDate" },
                values: new object[] { new Guid("58218d60-ff1c-4c50-b0d2-0c13b86ecff0"), new DateTimeOffset(new DateTime(2021, 9, 26, 1, 19, 41, 527, DateTimeKind.Unspecified).AddTicks(3563), new TimeSpan(0, 5, 30, 0, 0)) });
        }
    }
}
