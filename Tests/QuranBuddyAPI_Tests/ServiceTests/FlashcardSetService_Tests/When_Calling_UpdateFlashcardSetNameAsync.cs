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
    public class When_Calling_UpdateFlashcardSetNameAsync
    {

        private DbContextOptions<QuranDBContext> _options = new DbContextOptionsBuilder<QuranDBContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        private FakeContext _context;



        public When_Calling_UpdateFlashcardSetNameAsync()
        {
            _context = new FakeContext(_options);

        }

        [Fact]
        public async Task Then_The_Set_Name_Should_Be_Updated()
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

            var setNameRequest = new FlashcardSetUpdateNameRequest
            {
                Id = testId,
                Name = "New_name",

            };

            var flashcardsetService = new FlashcardSetService(_context);

            await flashcardsetService.UpdateFlashcardSetNameAsync(setNameRequest);

            //Assert
            testSet1.Name.Should().Be("New_name", "Because the set name should be updated");
        }


    }
}
