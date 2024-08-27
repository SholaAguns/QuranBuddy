using Microsoft.EntityFrameworkCore;
using QuranBuddyAPI.Contexts;
using QuranBuddyAPI.Entities;
using QuranBuddyAPI.Services;
using QuranBuddyAPI_Tests.Models;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuranBuddyAPI_Tests.ServiceTests.FlashcardSetService_Tests
{
    public class When_Calling_GetAllFlashcardSetsAsync
    {

        private DbContextOptions<QuranDBContext> _options = new DbContextOptionsBuilder<QuranDBContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        private FakeContext _context;



        public When_Calling_GetAllFlashcardSetsAsync()
        {
            _context = new FakeContext(_options);

        }

        [Fact]
        public async Task Then_3_FlashcardSets_Should_Be_Returned()
        {

            //Arrange
            var testSet1 = new FlashcardSet
            {
                Id = Guid.NewGuid(),
                Type = "Test",
                FlashcardAmount = 3,
                Report = new List<bool> { true },
                UserAnswers = new List<string> { "Test"},
                Flashcards = null,
                Name = "Test",               
            };

            var testSet2 = new FlashcardSet
            {
                Id = Guid.NewGuid(),
                Type = "Test",
                FlashcardAmount = 3,
                Report = new List<bool> { true },
                UserAnswers = new List<string> { "Test" },
                Flashcards = null,
                Name = "Test",
            };

            var testSet3 = new FlashcardSet
            {
                Id = Guid.NewGuid(),
                Type = "Test",
                FlashcardAmount = 3,
                Report = new List<bool> { true },
                UserAnswers = new List<string> { "Test" },
                Flashcards = null,
                Name = "Test",
            };
            //Act
            await _context.FlashcardSets.AddAsync(testSet1);
            await _context.FlashcardSets.AddAsync(testSet2);
            await _context.FlashcardSets.AddAsync(testSet3);
            await _context.SaveChangesAsync();

            var flashcardsetService = new FlashcardSetService(_context);

            var result = await flashcardsetService.GetAllFlashcardSetsAsync();

            //Assert
            result.Count.Should().Be(3, "Because 3 sets should be returned");

        }
    }
}
