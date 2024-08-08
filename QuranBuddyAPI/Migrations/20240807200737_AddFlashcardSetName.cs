using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuranBuddyAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddFlashcardSetName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FlashcardSets",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "FlashcardSets");
        }
    }
}
