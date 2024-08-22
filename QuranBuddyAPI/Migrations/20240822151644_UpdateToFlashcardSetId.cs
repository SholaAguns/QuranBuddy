using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuranBuddyAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToFlashcardSetId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flashcards_FlashcardSets_FlashcardId",
                table: "Flashcards");

            migrationBuilder.RenameColumn(
                name: "FlashcardId",
                table: "Flashcards",
                newName: "FlashcardSetId");

            migrationBuilder.RenameIndex(
                name: "IX_Flashcards_FlashcardId",
                table: "Flashcards",
                newName: "IX_Flashcards_FlashcardSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flashcards_FlashcardSets_FlashcardSetId",
                table: "Flashcards",
                column: "FlashcardSetId",
                principalTable: "FlashcardSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flashcards_FlashcardSets_FlashcardSetId",
                table: "Flashcards");

            migrationBuilder.RenameColumn(
                name: "FlashcardSetId",
                table: "Flashcards",
                newName: "FlashcardId");

            migrationBuilder.RenameIndex(
                name: "IX_Flashcards_FlashcardSetId",
                table: "Flashcards",
                newName: "IX_Flashcards_FlashcardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flashcards_FlashcardSets_FlashcardId",
                table: "Flashcards",
                column: "FlashcardId",
                principalTable: "FlashcardSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
