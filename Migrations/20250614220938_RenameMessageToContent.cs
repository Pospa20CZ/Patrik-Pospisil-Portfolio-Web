using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patrik_Pospisil_Portfolio_Web.Migrations
{
    /// <inheritdoc />
    public partial class RenameMessageToContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "ContactMessages");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ContactMessages",
                newName: "DateSent");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "ContactMessages",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "ContactMessages");

            migrationBuilder.RenameColumn(
                name: "DateSent",
                table: "ContactMessages",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "ContactMessages",
                type: "TEXT",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }
    }
}
