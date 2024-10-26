using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using QuranBuddyAPI.Contexts;
using QuranBuddyAPI.Entities;
using QuranBuddyAPI.Services;
using QuranBuddyAPI_Tests.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuranBuddyAPI_Tests.ServiceTests.FlashcardSetService_Tests
{
    public class When_Calling_DeleteFlashcardSetRangeAsync
    {
        private DbContextOptions<QuranDBContext> _options = new DbContextOptionsBuilder<QuranDBContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        private FakeContext _context;



        public When_Calling_DeleteFlashcardSetRangeAsync()
        {
            _context = new FakeContext(_options);

        }

        [Fact]
        public async Task Then_The_Correct_Sets_Should_Be_Deleted()
        {
            var testId1 = Guid.NewGuid();
            var testSet1 = new FlashcardSet
            {
                Id = testId1,
                Type = "Test",
                FlashcardAmount = 3,
                Report = new List<bool> { true },
                UserAnswers = new List<string> { "Test" },
                Flashcards = null,
                Name = "TestSet1",
            };

            var testId2 = Guid.NewGuid();
            var testSet2 = new FlashcardSet
            {
                Id = testId2,
                Type = "Test",
                FlashcardAmount = 3,
                Report = new List<bool> { true },
                UserAnswers = new List<string> { "Test" },
                Flashcards = null,
                Name = "Test",
            };

            await _context.FlashcardSets.AddAsync(testSet1);
            await _context.FlashcardSets.AddAsync(testSet2);
            await _context.SaveChangesAsync();

            var range = new Guid[] { testId1, testId2 };

            var flashcardsetService = new FlashcardSetService(_context);

            await flashcardsetService.DeleteFlashcardSetRangeAsync(range);

            var result1 = await _context.FlashcardSets.Where(t => t.Id == testId1).FirstOrDefaultAsync();
            var result2 = await _context.FlashcardSets.Where(t => t.Id == testId2).FirstOrDefaultAsync();

            result1.Should().Be(null, "Because the set should be deleted");
            result2.Should().Be(null, "Because the set should be deleted");
        }

        [Fact]
        public async Task Then_Sets_That_Exist_Should_Be_Deleted()
        {
            var testId1 = Guid.NewGuid();
            var testId2 = Guid.NewGuid();
            var flashcardsetService = new FlashcardSetService(_context);

            var testSet1 = new FlashcardSet
            {
                Id = testId1,
                Type = "Test",
                FlashcardAmount = 3,
                Report = new List<bool> { true },
                UserAnswers = new List<string> { "Test" },
                Flashcards = null,
                Name = "Test",
            };

            await _context.FlashcardSets.AddAsync(testSet1);
            await _context.SaveChangesAsync();

            var range = new Guid[] { testId1, testId2 };

            await flashcardsetService.DeleteFlashcardSetRangeAsync(range);

            //Func<Task> act = async () => await flashcardsetService.DeleteFlashcardSetRangeAsync(range);
            //await act.Should().ThrowAsync<ObjectNotFoundException>();

            var result = await _context.FlashcardSets.Where(t => t.Id == testId1).FirstOrDefaultAsync();

            result.Should().Be(null, "Because the set should be deleted");

        } 
    }
}
