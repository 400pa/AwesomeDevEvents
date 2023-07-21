using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AwesomeDevEvents.API.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DevEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Start_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DevEventsSpeaker",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TalkTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TalkDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedinProfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DevEventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevEventsSpeaker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DevEventsSpeaker_DevEvents_DevEventId",
                        column: x => x.DevEventId,
                        principalTable: "DevEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DevEventsSpeaker_DevEventId",
                table: "DevEventsSpeaker",
                column: "DevEventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DevEventsSpeaker");

            migrationBuilder.DropTable(
                name: "DevEvents");
        }
    }
}
