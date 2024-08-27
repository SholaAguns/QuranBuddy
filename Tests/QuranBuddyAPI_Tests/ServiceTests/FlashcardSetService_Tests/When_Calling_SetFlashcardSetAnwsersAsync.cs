using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using QuranBuddyAPI.Contexts;
using QuranBuddyAPI.Entities;
using QuranBuddyAPI.Models;
using QuranBuddyAPI.Services;
using QuranBuddyAPI_Tests.Models;

namespace QuranBuddyAPI_Tests.ServiceTests.FlashcardSetService_Tests
{
    public class When_Calling_SetFlashcardSetAnwsersAsync
    {
        private DbContextOptions<QuranDBContext> _options = new DbContextOptionsBuilder<QuranDBContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        private FakeContext _context;



        public When_Calling_SetFlashcardSetAnwsersAsync()
        {
            _context = new FakeContext(_options);

        }

        [Fact]
        public async Task Then_The_Correct_Set_Report_Should_Be_Filled_As_Expected()
        {
            var testId = Guid.NewGuid();
            var testSet1 = new FlashcardSet
            {
                Id = testId,
                Type = "Test",
                FlashcardAmount = 3,
                Flashcards = new List<Flashcard>
                {   new Flashcard { Id = Guid.NewGuid(), Question = "Test1", Answer = "Test2", FlashcardSetId = testId, ImageUrl = "Some url" },
                    new Flashcard { Id = Guid.NewGuid(), Question = "Test3", Answer = "Test4", FlashcardSetId = testId, ImageUrl = "Some url"}
                },
                Name = "TestSet1",
            };
            var setAnswersRequest = new FlashcardSetAnswersRequest
            {
                Id = testId,
                UserAnswers = new List<string> { "Test2", "Test" }
            };

            await _context.FlashcardSets.AddAsync(testSet1);
            await _context.SaveChangesAsync();

            var flashcardsetService = new FlashcardSetService(_context);

            await flashcardsetService.SetFlashcardSetAnwsersAsync(setAnswersRequest);

            testSet1.UserAnswers.Should().NotBeEmpty("Because the set user answers Report Should be filled");
            testSet1.Report.Should().NotBeEmpty("Because the set Report Should be filled");
            
        }

    }
}
