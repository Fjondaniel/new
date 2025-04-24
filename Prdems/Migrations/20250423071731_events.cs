using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prdems.Migrations
{
    /// <inheritdoc />
    public partial class Events : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDescription = table.Column<string>(type:"nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type:"nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type:"DateTime", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attendee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                }
            );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");
        }
    }
}
