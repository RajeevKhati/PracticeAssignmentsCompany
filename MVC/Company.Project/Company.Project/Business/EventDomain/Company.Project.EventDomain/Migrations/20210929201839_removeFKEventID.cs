using Microsoft.EntityFrameworkCore.Migrations;

namespace Company.Project.EventDomain.Migrations
{
    public partial class removeFKEventID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventsAndPeople_Events_EventID",
                table: "EventsAndPeople");

            migrationBuilder.DropIndex(
                name: "IX_EventsAndPeople_EventID",
                table: "EventsAndPeople");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EventsAndPeople_EventID",
                table: "EventsAndPeople",
                column: "EventID");

            migrationBuilder.AddForeignKey(
                name: "FK_EventsAndPeople_Events_EventID",
                table: "EventsAndPeople",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
