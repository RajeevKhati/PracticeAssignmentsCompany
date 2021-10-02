using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Company.Project.EventDomain.Migrations
{
    public partial class AddedDateAndTimeAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
