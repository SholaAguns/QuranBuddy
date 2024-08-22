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


namespace QuranBuddyAPI_Tests.ServiceTests.ChapterService_Tests
{
    public class When_Calling_GetChapterByIdAsync
    {
        private DbContextOptions<QuranDBContext> _options = new DbContextOptionsBuilder<QuranDBContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        private FakeContext _context;



        public When_Calling_GetChapterByIdAsync()
        {
            _context = new FakeContext(_options);

        }

        [Fact]
        public async Task Then_The_Correct_Chapter_Should_Be_Returned()
        {

            //Arrange
            var testId = 1;
            var testChapter = new Chapter
            {
                Id = testId,
                Name = "Test Chapter",
                NameArabic = "??????????",
                TranslatedName = new TranslatedName { LanguageName = "english", Name = "Translated Name" },
                BismillahPre = false,
                VersesCount = 10,
                RevelationPlace = "makkah"
            };
            var chapterService = new ChapterService(_context);

            //Act
            await _context.Chapters.AddAsync(testChapter);
            await _context.SaveChangesAsync();
            var result = await chapterService.GetChapterByIdAsync(testId);

            //Assert
            result.Id.Should().Be(testId, "Because the correct chapter Id  should be returned");

        }

        [Fact]
        public async Task Then_Null_Should_Be_Returned_When_Chapter_Does_Not_Exist()
        {
            var testId = 180;
            var chapterService = new ChapterService(_context);

            var result = await chapterService.GetChapterByIdAsync(testId);

            result.Should().Be(null, "Because the chapter should not exist and null should be returned");

        }
    }
}
