﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuranBuddyAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVerseWithVirtualProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flashcard_FlashcardSets_Id",
                table: "Flashcard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flashcard",
                table: "Flashcard");

            migrationBuilder.RenameTable(
                name: "Flashcard",
                newName: "Flashcards");

            migrationBuilder.AddColumn<Guid>(
                name: "FlashcardId",
                table: "Flashcards",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flashcards",
                table: "Flashcards",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Flashcards_FlashcardId",
                table: "Flashcards",
                column: "FlashcardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flashcards_FlashcardSets_FlashcardId",
                table: "Flashcards",
                column: "FlashcardId",
                principalTable: "FlashcardSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flashcards_FlashcardSets_FlashcardId",
                table: "Flashcards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flashcards",
                table: "Flashcards");

            migrationBuilder.DropIndex(
                name: "IX_Flashcards_FlashcardId",
                table: "Flashcards");

            migrationBuilder.DropColumn(
                name: "FlashcardId",
                table: "Flashcards");

            migrationBuilder.RenameTable(
                name: "Flashcards",
                newName: "Flashcard");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flashcard",
                table: "Flashcard",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flashcard_FlashcardSets_Id",
                table: "Flashcard",
                column: "Id",
                principalTable: "FlashcardSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
