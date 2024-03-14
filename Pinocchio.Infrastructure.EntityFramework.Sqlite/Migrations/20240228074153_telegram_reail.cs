using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pinocchio.Infrastructure.EntityFramework.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class telegram_reail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TelegramState",
                table: "Parents",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TelegramState",
                table: "Parents");
        }
    }
}
