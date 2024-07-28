using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuranBuddyAPI.Migrations
{
    /// <inheritdoc />
    public partial class TranslationsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TranslatedText",
                table: "Verses");

            migrationBuilder.DropColumn(
                name: "Transliteration",
                table: "Verses");

            migrationBuilder.DropColumn(
                name: "RevelationCount",
                table: "Chapters");

            migrationBuilder.RenameColumn(
                name: "ImageWidth",
                table: "Verses",
                newName: "RukuNumber");

            migrationBuilder.RenameColumn(
                name: "TranslatedName",
                table: "Chapters",
                newName: "TranslatedName_Name");

            migrationBuilder.AddColumn<int>(
                name: "HizbNumber",
                table: "Verses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ManzilNumber",
                table: "Verses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PageNumber",
                table: "Verses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RubElHizbNumber",
                table: "Verses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SajdahNumber",
                table: "Verses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TranslatedName_LanguageName",
                table: "Chapters",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Translation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    VerseId = table.Column<int>(type: "INTEGER", nullable: false),
                    ResourceId = table.Column<int>(type: "INTEGER", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translation", x => new { x.VerseId, x.Id });
                    table.ForeignKey(
                        name: "FK_Translation_Verses_VerseId",
                        column: x => x.VerseId,
                        principalTable: "Verses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Translation");

            migrationBuilder.DropColumn(
                name: "HizbNumber",
                table: "Verses");

            migrationBuilder.DropColumn(
                name: "ManzilNumber",
                table: "Verses");

            migrationBuilder.DropColumn(
                name: "PageNumber",
                table: "Verses");

            migrationBuilder.DropColumn(
                name: "RubElHizbNumber",
                table: "Verses");

            migrationBuilder.DropColumn(
                name: "SajdahNumber",
                table: "Verses");

            migrationBuilder.DropColumn(
                name: "TranslatedName_LanguageName",
                table: "Chapters");

            migrationBuilder.RenameColumn(
                name: "RukuNumber",
                table: "Verses",
                newName: "ImageWidth");

            migrationBuilder.RenameColumn(
                name: "TranslatedName_Name",
                table: "Chapters",
                newName: "TranslatedName");

            migrationBuilder.AddColumn<string>(
                name: "TranslatedText",
                table: "Verses",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Transliteration",
                table: "Verses",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RevelationCount",
                table: "Chapters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
