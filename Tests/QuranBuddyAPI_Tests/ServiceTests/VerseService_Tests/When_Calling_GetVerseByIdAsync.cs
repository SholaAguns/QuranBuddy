using Microsoft.EntityFrameworkCore;
using QuranBuddyAPI.Contexts;
using QuranBuddyAPI.Models;
using QuranBuddyAPI.Entities;
using QuranBuddyAPI.Services;
using QuranBuddyAPI_Tests.Models;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuranBuddyAPI_Tests.ServiceTests.VerseService_Tests
{
    public class When_Calling_GetVerseByIdAsync
    {

        private DbContextOptions<QuranDBContext> _options;
        private FakeContext _context;



        public When_Calling_GetVerseByIdAsync()
        {
            _options = new DbContextOptionsBuilder<QuranDBContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
            _context = new FakeContext(_options);

        }

        [Fact]
        public async Task Then_The_Correct_Verse_Should_Be_Returned()
        {

            //Arrange
            var testChapter = new Chapter
            {
                Id = 2,
                Name = "Test Chapter",
                NameArabic = "??????????",
                TranslatedName = new TranslatedName { LanguageName = "english", Name = "Translated Name" },
                BismillahPre = false,
                VersesCount = 10,
                RevelationPlace = "makkah"
            };
            List<Verse> verses = new List<Verse>
            {
                new Verse {
                    Id = 15,
                    VerseKey = "2:3",
                    ChapterId = 2,
                    VerseNumber = 3,
                    HizbNumber = 0,
                    RubElHizbNumber = 0,
                    RukuNumber = 0,
                    ManzilNumber = 0,
                    SajdahNumber = 0,
                    TextUthmani = "????????",
                    ImageUrl = "test url",
                    PageNumber = 0,
                    JuzNumber = 1,
                    Translations = new List<Translation> {new Translation { Id = 12, ResourceId = 0, Text = "sample translation" } }

                },
                new Verse
                {
                    Id = 16,
                    VerseKey = "2:4",
                    ChapterId = 2,
                    VerseNumber = 4,
                    HizbNumber = 0,
                    RubElHizbNumber = 0,
                    RukuNumber = 0,
                    ManzilNumber = 0,
                    SajdahNumber = 0,
                    TextUthmani = "????????",
                    ImageUrl = "test url",
                    PageNumber = 0,
                    JuzNumber = 1,
                    Translations = new List<Translation> {new Translation { Id = 12, ResourceId = 0, Text = "sample translation" } }
                },
                new Verse
                {
                    Id = 17,
                    VerseKey = "2:5",
                    ChapterId = 2,
                    VerseNumber = 5,
                    HizbNumber = 0,
                    RubElHizbNumber = 0,
                    RukuNumber = 0,
                    ManzilNumber = 0,
                    SajdahNumber = 0,
                    TextUthmani = "????????",
                    ImageUrl = "test url",
                    PageNumber = 0,
                    JuzNumber = 1,
                    Translations = new List<Translation> {new Translation { Id = 12, ResourceId = 0, Text = "sample translation" } }
                }
            };


            var verseService = new VerseService(_context);

            //Act
            await _context.Chapters.AddAsync(testChapter);

            foreach (var verse in verses)
            {
                await _context.Verses.AddAsync(verse);
            }


            await _context.SaveChangesAsync();

            var result = await verseService.GetVerseByIdAsync(15);


            //Assert
            result.Id.Should().Be(15, "Because verse with the correct Id should be returned");

        }

        [Fact]
        public async Task Then_Null_Should_Be_Returned_When_The_Given_Id_Matches_No_Verse()
        {

            //Arrange
            var testChapter = new Chapter
            {
                Id = 2,
                Name = "Test Chapter",
                NameArabic = "??????????",
                TranslatedName = new TranslatedName { LanguageName = "english", Name = "Translated Name" },
                BismillahPre = false,
                VersesCount = 10,
                RevelationPlace = "makkah"
            };
            List<Verse> verses = new List<Verse>
            {
                new Verse {
                    Id = 15,
                    VerseKey = "2:3",
                    ChapterId = 2,
                    VerseNumber = 3,
                    HizbNumber = 0,
                    RubElHizbNumber = 0,
                    RukuNumber = 0,
                    ManzilNumber = 0,
                    SajdahNumber = 0,
                    TextUthmani = "????????",
                    ImageUrl = "test url",
                    PageNumber = 0,
                    JuzNumber = 1,
                    Translations = new List<Translation> {new Translation { Id = 12, ResourceId = 0, Text = "sample translation" } }

                },
                new Verse
                {
                    Id = 16,
                    VerseKey = "2:4",
                    ChapterId = 2,
                    VerseNumber = 4,
                    HizbNumber = 0,
                    RubElHizbNumber = 0,
                    RukuNumber = 0,
                    ManzilNumber = 0,
                    SajdahNumber = 0,
                    TextUthmani = "????????",
                    ImageUrl = "test url",
                    PageNumber = 0,
                    JuzNumber = 1,
                    Translations = new List<Translation> {new Translation { Id = 12, ResourceId = 0, Text = "sample translation" } }
                },
                new Verse
                {
                    Id = 17,
                    VerseKey = "2:5",
                    ChapterId = 2,
                    VerseNumber = 5,
                    HizbNumber = 0,
                    RubElHizbNumber = 0,
                    RukuNumber = 0,
                    ManzilNumber = 0,
                    SajdahNumber = 0,
                    TextUthmani = "????????",
                    ImageUrl = "test url",
                    PageNumber = 0,
                    JuzNumber = 1,
                    Translations = new List<Translation> {new Translation { Id = 12, ResourceId = 0, Text = "sample translation" } }
                }
            };


            var verseService = new VerseService(_context);

            //Act
            await _context.Chapters.AddAsync(testChapter);

            foreach (var verse in verses)
            {
                await _context.Verses.AddAsync(verse);
            }


            await _context.SaveChangesAsync();

            var result = await verseService.GetVerseByIdAsync(80);


            //Assert
            result.Should().Be(null, "Because no verse should be returned");

        }
    }
}
