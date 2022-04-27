using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notes_Website.Data.Migrations
{
    public partial class addition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AmendmentModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Note_Part = table.Column<int>(type: "int", nullable: false),
                    NoteModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmendmentModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AmendmentModels_NoteModel_NoteModelId",
                        column: x => x.NoteModelId,
                        principalTable: "NoteModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "NoteModel",
                keyColumn: "Id",
                keyValue: 4,
                column: "Added",
                value: new DateTime(2022, 2, 15, 11, 25, 50, 430, DateTimeKind.Local).AddTicks(7352));

            migrationBuilder.UpdateData(
                table: "NoteModel",
                keyColumn: "Id",
                keyValue: 5,
                column: "Added",
                value: new DateTime(2022, 2, 14, 11, 25, 50, 430, DateTimeKind.Local).AddTicks(7375));

            migrationBuilder.UpdateData(
                table: "NoteModel",
                keyColumn: "Id",
                keyValue: 6,
                column: "Added",
                value: new DateTime(2022, 2, 18, 11, 25, 50, 430, DateTimeKind.Local).AddTicks(7377));

            migrationBuilder.UpdateData(
                table: "NoteModel",
                keyColumn: "Id",
                keyValue: 7,
                column: "Added",
                value: new DateTime(2022, 2, 19, 11, 25, 50, 430, DateTimeKind.Local).AddTicks(7379));

            migrationBuilder.UpdateData(
                table: "NoteModel",
                keyColumn: "Id",
                keyValue: 8,
                column: "Added",
                value: new DateTime(2022, 2, 18, 11, 25, 50, 430, DateTimeKind.Local).AddTicks(7380));

            migrationBuilder.CreateIndex(
                name: "IX_AmendmentModels_NoteModelId",
                table: "AmendmentModels",
                column: "NoteModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmendmentModels");

            migrationBuilder.UpdateData(
                table: "NoteModel",
                keyColumn: "Id",
                keyValue: 4,
                column: "Added",
                value: new DateTime(2022, 2, 10, 21, 43, 59, 434, DateTimeKind.Local).AddTicks(2560));

            migrationBuilder.UpdateData(
                table: "NoteModel",
                keyColumn: "Id",
                keyValue: 5,
                column: "Added",
                value: new DateTime(2022, 2, 9, 21, 43, 59, 434, DateTimeKind.Local).AddTicks(2572));

            migrationBuilder.UpdateData(
                table: "NoteModel",
                keyColumn: "Id",
                keyValue: 6,
                column: "Added",
                value: new DateTime(2022, 2, 13, 21, 43, 59, 434, DateTimeKind.Local).AddTicks(2574));

            migrationBuilder.UpdateData(
                table: "NoteModel",
                keyColumn: "Id",
                keyValue: 7,
                column: "Added",
                value: new DateTime(2022, 2, 14, 21, 43, 59, 434, DateTimeKind.Local).AddTicks(2575));

            migrationBuilder.UpdateData(
                table: "NoteModel",
                keyColumn: "Id",
                keyValue: 8,
                column: "Added",
                value: new DateTime(2022, 2, 13, 21, 43, 59, 434, DateTimeKind.Local).AddTicks(2577));
        }
    }
}
