using Microsoft.EntityFrameworkCore.Migrations;

namespace Company.Project.EventDomain.Migrations
{
    public partial class MadeUserIDStringInEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventsAndPeople_People_PersonID",
                table: "EventsAndPeople");

            migrationBuilder.DropIndex(
                name: "IX_EventsAndPeople_PersonID",
                table: "EventsAndPeople");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Events",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Events",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_EventsAndPeople_PersonID",
                table: "EventsAndPeople",
                column: "PersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_EventsAndPeople_People_PersonID",
                table: "EventsAndPeople",
                column: "PersonID",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
