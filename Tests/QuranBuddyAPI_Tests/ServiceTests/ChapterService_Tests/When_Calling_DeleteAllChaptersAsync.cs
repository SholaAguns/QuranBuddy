using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using QuranBuddyAPI.Contexts;
using QuranBuddyAPI.Models;
using QuranBuddyAPI.Services;
using QuranBuddyAPI_Tests.Models;

namespace QuranBuddyAPI_Tests.ServiceTests.ChapterService_Tests
{
    public class When_Calling_DeleteAllChaptersAsync
    {

        private DbContextOptions<QuranDBContext> _options = new DbContextOptionsBuilder<QuranDBContext>()
    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
    .Options;
        private FakeContext _context;



        public When_Calling_DeleteAllChaptersAsync()
        {
            _context = new FakeContext(_options);

        }

        [Fact]
        public async Task Then_0_Chapters_Should_Be_Returned()
        {

            //Arrange
            var testChapter1 = new Chapter
            {
                Id = 15,
                Name = "Test Chapter",
                NameArabic = "??????????",
                TranslatedName = new TranslatedName { LanguageName = "english", Name = "Translated Name" },
                BismillahPre = false,
                VersesCount = 10,
                RevelationPlace = "makkah"
            };
            var testChapter2 = new Chapter
            {
                Id = 16,
                Name = "Test Chapter 2",
                NameArabic = "??????????",
                TranslatedName = new TranslatedName { LanguageName = "english", Name = "Translated Name" },
                BismillahPre = false,
                VersesCount = 10,
                RevelationPlace = "makkah"
            };
            var testChapter3 = new Chapter
            {
                Id = 17,
                Name = "Different Chapter",
                NameArabic = "??????????",
                TranslatedName = new TranslatedName { LanguageName = "english", Name = "Translated Name" },
                BismillahPre = false,
                VersesCount = 10,
                RevelationPlace = "makkah"
            };
            var chapterService = new ChapterService(_context);

            //Act
            await _context.Chapters.AddAsync(testChapter1);
            await _context.Chapters.AddAsync(testChapter2);
            await _context.Chapters.AddAsync(testChapter3);
            await _context.SaveChangesAsync();

            await chapterService.DeleteAllChaptersAsync();

            var result = await _context.Chapters.ToListAsync();

            //Assert
            result.Count.Should().Be(0, "Because 0 chapters should be returned");

        }
    }
}
