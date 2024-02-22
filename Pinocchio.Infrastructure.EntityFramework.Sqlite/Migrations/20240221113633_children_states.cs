using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pinocchio.Infrastructure.EntityFramework.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class children_states : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Children",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ChildStates",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StateDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    ChildId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ChildState = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildStates_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildStates_ChildId",
                table: "ChildStates",
                column: "ChildId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildStates");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Children");
        }
    }
}
