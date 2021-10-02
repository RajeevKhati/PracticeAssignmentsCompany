using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Company.Project.EventDomain.Migrations
{
    public partial class AddedApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EventsAndPeople",
                table: "EventsAndPeople");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EventsAndPeople",
                keyColumns: new[] { "PersonID", "EventID" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "EventsAndPeople",
                keyColumns: new[] { "PersonID", "EventID" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "People",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventsAndPeople",
                table: "EventsAndPeople",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_EventsAndPeople_PersonID",
                table: "EventsAndPeople",
                column: "PersonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EventsAndPeople",
                table: "EventsAndPeople");

            migrationBuilder.DropIndex(
                name: "IX_EventsAndPeople_PersonID",
                table: "EventsAndPeople");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "People");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventsAndPeople",
                table: "EventsAndPeople",
                columns: new[] { "PersonID", "EventID" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedByUserID", "CreatedOnDate", "Date", "Description", "DurationInHours", "GUID", "IsActive", "IsDeleted", "Location", "ModifiedByUserID", "ModifiedOnDate", "OtherDetails", "StartTime", "TitleOfBook", "Type", "UserID" },
                values: new object[,]
                {
                    { 1, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2021, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, new Guid("2e34a494-5967-4433-aa5b-a4846236a308"), false, false, "mahim", 0, new DateTimeOffset(new DateTime(2021, 9, 28, 22, 57, 11, 181, DateTimeKind.Unspecified).AddTicks(9562), new TimeSpan(0, 5, 30, 0, 0)), null, new TimeSpan(0, 0, 0, 0, 0), "positivity", false, 1 },
                    { 2, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2021, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, new Guid("c868a3ae-5a2b-43ea-ac85-75efa83a37f4"), false, false, "bandra", 0, new DateTimeOffset(new DateTime(2021, 9, 28, 22, 57, 11, 182, DateTimeKind.Unspecified).AddTicks(1170), new TimeSpan(0, 5, 30, 0, 0)), null, new TimeSpan(0, 0, 0, 0, 0), "war", false, 1 },
                    { 3, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2021, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, new Guid("ec3b919d-7025-4898-a7e2-b36483132c65"), false, false, "dadar", 0, new DateTimeOffset(new DateTime(2021, 9, 28, 22, 57, 11, 182, DateTimeKind.Unspecified).AddTicks(1231), new TimeSpan(0, 5, 30, 0, 0)), null, new TimeSpan(0, 0, 0, 0, 0), "21 days", false, 5 },
                    { 4, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2020, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, new Guid("6bc39e0d-d0bd-40b4-a007-0e5f84e8ae7c"), false, false, "vasai", 0, new DateTimeOffset(new DateTime(2021, 9, 28, 22, 57, 11, 182, DateTimeKind.Unspecified).AddTicks(1236), new TimeSpan(0, 5, 30, 0, 0)), null, new TimeSpan(0, 0, 0, 0, 0), "rudest book ever", false, 5 },
                    { 5, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2021, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, new Guid("0a1c3e1d-1f22-4464-afab-9f621cef2d3c"), false, false, "vile parle", 0, new DateTimeOffset(new DateTime(2021, 9, 28, 22, 57, 11, 182, DateTimeKind.Unspecified).AddTicks(1240), new TimeSpan(0, 5, 30, 0, 0)), null, new TimeSpan(0, 0, 0, 0, 0), "rag to rich", false, 6 },
                    { 6, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2021, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, new Guid("b46846df-486a-431d-8a33-f3f4cc8417a5"), false, false, "naigaon", 0, new DateTimeOffset(new DateTime(2021, 9, 28, 22, 57, 11, 182, DateTimeKind.Unspecified).AddTicks(1244), new TimeSpan(0, 5, 30, 0, 0)), null, new TimeSpan(0, 0, 0, 0, 0), "rich dad poor dad", false, 3 }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "CreatedByUserID", "CreatedOnDate", "Email", "FullName", "GUID", "IsActive", "IsDeleted", "ModifiedByUserID", "ModifiedOnDate" },
                values: new object[,]
                {
                    { 1, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "adarsh@gmail.com", "adarsh singhai", new Guid("01908f6a-c596-4809-bd3b-c4917dc955bd"), false, false, 0, new DateTimeOffset(new DateTime(2021, 9, 28, 22, 57, 11, 179, DateTimeKind.Unspecified).AddTicks(445), new TimeSpan(0, 5, 30, 0, 0)) },
                    { 2, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "raj@gmail.com", "raj chakra", new Guid("07eaab66-4c99-4ac4-822c-f0797be0d6f8"), false, false, 0, new DateTimeOffset(new DateTime(2021, 9, 28, 22, 57, 11, 181, DateTimeKind.Unspecified).AddTicks(8973), new TimeSpan(0, 5, 30, 0, 0)) },
                    { 3, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "sanket@yahoo.com", "sanket jain", new Guid("7a8dee8c-1bfd-425b-903e-6ee8adc6241a"), false, false, 0, new DateTimeOffset(new DateTime(2021, 9, 28, 22, 57, 11, 181, DateTimeKind.Unspecified).AddTicks(9041), new TimeSpan(0, 5, 30, 0, 0)) },
                    { 4, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "himanshu@yahoo.com", "himanshu jain", new Guid("a24209e4-c159-4e96-9824-29bd030e3c5d"), false, false, 0, new DateTimeOffset(new DateTime(2021, 9, 28, 22, 57, 11, 181, DateTimeKind.Unspecified).AddTicks(9047), new TimeSpan(0, 5, 30, 0, 0)) },
                    { 5, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "deepanshu@gmail.com", "deepanshu jain", new Guid("273712a5-0ca2-4d83-a97f-ff128f5e8579"), false, false, 0, new DateTimeOffset(new DateTime(2021, 9, 28, 22, 57, 11, 181, DateTimeKind.Unspecified).AddTicks(9051), new TimeSpan(0, 5, 30, 0, 0)) },
                    { 6, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "dheeraj@zoho.com", "dheeraj jain", new Guid("658ad1d1-00ed-4e37-b03d-a5100a0672fc"), false, false, 0, new DateTimeOffset(new DateTime(2021, 9, 28, 22, 57, 11, 181, DateTimeKind.Unspecified).AddTicks(9055), new TimeSpan(0, 5, 30, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "EventsAndPeople",
                columns: new[] { "PersonID", "EventID", "CreatedByUserID", "CreatedOnDate", "GUID", "IsActive", "IsDeleted", "ModifiedByUserID", "ModifiedOnDate" },
                values: new object[] { 1, 2, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("1daaad12-ed45-4ee0-9c0c-b9aaa73c0dea"), false, false, 0, new DateTimeOffset(new DateTime(2021, 9, 28, 22, 57, 11, 182, DateTimeKind.Unspecified).AddTicks(1631), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.InsertData(
                table: "EventsAndPeople",
                columns: new[] { "PersonID", "EventID", "CreatedByUserID", "CreatedOnDate", "GUID", "IsActive", "IsDeleted", "ModifiedByUserID", "ModifiedOnDate" },
                values: new object[] { 2, 3, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("dffaf8a9-acb5-477c-aa70-0a37d818b363"), false, false, 0, new DateTimeOffset(new DateTime(2021, 9, 28, 22, 57, 11, 182, DateTimeKind.Unspecified).AddTicks(2316), new TimeSpan(0, 5, 30, 0, 0)) });
        }
    }
}
