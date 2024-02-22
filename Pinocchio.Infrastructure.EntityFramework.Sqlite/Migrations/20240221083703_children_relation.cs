using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pinocchio.Infrastructure.EntityFramework.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class children_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParentChatId",
                table: "Children",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Children_ParentChatId",
                table: "Children",
                column: "ParentChatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Parents_ParentChatId",
                table: "Children",
                column: "ParentChatId",
                principalTable: "Parents",
                principalColumn: "ChatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Children_Parents_ParentChatId",
                table: "Children");

            migrationBuilder.DropIndex(
                name: "IX_Children_ParentChatId",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "ParentChatId",
                table: "Children");
        }
    }
}
