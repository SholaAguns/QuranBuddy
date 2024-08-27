using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using QuranBuddyAPI.Contexts;
using QuranBuddyAPI.Entities;
using QuranBuddyAPI.Services;
using QuranBuddyAPI_Tests.Models;

namespace QuranBuddyAPI_Tests.ServiceTests.FlashcardSetService_Tests
{
    public class When_Calling_GetFlashcardSetByIdAsync
    {

        private DbContextOptions<QuranDBContext> _options = new DbContextOptionsBuilder<QuranDBContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        private FakeContext _context;



        public When_Calling_GetFlashcardSetByIdAsync()
        {
            _context = new FakeContext(_options);

        }

        [Fact]
        public async Task Then_The_Correct_Set_Should_Be_Returned()
        {
            var testId = Guid.NewGuid();
            var testSet1 = new FlashcardSet
            {
                Id = testId,
                Type = "Test",
                FlashcardAmount = 3,
                Report = new List<bool> { true },
                UserAnswers = new List<string> { "Test" },
                Flashcards = null,
                Name = "TestSet1",
            };

            await _context.FlashcardSets.AddAsync(testSet1);
            await _context.SaveChangesAsync();

            var flashcardsetService = new FlashcardSetService(_context);

            var result = await flashcardsetService.GetFlashcardSetByIdAsync(testId);

            //Assert
            result.Id.Should().Be(testId, "Because the correct set Id  should be returned");
        }

        [Fact]
        public async Task Then_Null_Should_Be_Returned_When_Set_Does_Not_Exist()
        {
            var testId = Guid.NewGuid();
            var flashcardsetService = new FlashcardSetService(_context);

            var result = await flashcardsetService.GetFlashcardSetByIdAsync(testId);

            result.Should().Be(null, "Because the chapter should not exist and null should be returned");

        }

    }
}
