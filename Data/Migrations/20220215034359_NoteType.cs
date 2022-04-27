using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notes_Website.Data.Migrations
{
    public partial class NoteType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NoteTypeId",
                table: "NoteModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "NoteTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "NoteTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Personal" },
                    { 2, "School" },
                    { 3, "Random" },
                    { 4, "Important" },
                    { 5, "Other" }
                });

            migrationBuilder.InsertData(
                table: "NoteModel",
                columns: new[] { "Id", "Added", "Note", "NoteTypeId", "Note_Part", "Title" },
                values: new object[,]
                {
                    { 4, new DateTime(2022, 2, 10, 21, 43, 59, 434, DateTimeKind.Local).AddTicks(2560), "Johns birthday is soon.", 1, 1, "Remember" },
                    { 5, new DateTime(2022, 2, 9, 21, 43, 59, 434, DateTimeKind.Local).AddTicks(2572), "Look over notes for the test.", 2, 1, "Test Help" },
                    { 6, new DateTime(2022, 2, 13, 21, 43, 59, 434, DateTimeKind.Local).AddTicks(2574), "Link to website.", 3, 1, "Note Title" },
                    { 7, new DateTime(2022, 2, 14, 21, 43, 59, 434, DateTimeKind.Local).AddTicks(2575), "Don't miss today's meeting.", 4, 1, "Upcoming Meeting" },
                    { 8, new DateTime(2022, 2, 13, 21, 43, 59, 434, DateTimeKind.Local).AddTicks(2577), "To fix the ....", 5, 1, "Car Help" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoteModel_NoteTypeId",
                table: "NoteModel",
                column: "NoteTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_NoteModel_NoteTypes_NoteTypeId",
                table: "NoteModel",
                column: "NoteTypeId",
                principalTable: "NoteTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoteModel_NoteTypes_NoteTypeId",
                table: "NoteModel");

            migrationBuilder.DropTable(
                name: "NoteTypes");

            migrationBuilder.DropIndex(
                name: "IX_NoteModel_NoteTypeId",
                table: "NoteModel");

            migrationBuilder.DeleteData(
                table: "NoteModel",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "NoteModel",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "NoteModel",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "NoteModel",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "NoteModel",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "NoteTypeId",
                table: "NoteModel");
        }
    }
}
