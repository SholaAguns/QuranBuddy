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
using System.Data.Entity.Core;

namespace QuranBuddyAPI_Tests.ServiceTests.FlashcardSetService_Tests
{
    public class When_Calling_DeleteFlashcardSetAsync
    {

            private DbContextOptions<QuranDBContext> _options = new DbContextOptionsBuilder<QuranDBContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            private FakeContext _context;



            public When_Calling_DeleteFlashcardSetAsync()
            {
                _context = new FakeContext(_options);

            }

            [Fact]
            public async Task Then_The_Correct_Set_Should_Be_Deleted()
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

                await flashcardsetService.DeleteFlashcardSetAsync(testId);

                var result = await _context.FlashcardSets.Where(t => t.Id == testId).FirstOrDefaultAsync();

                result.Should().Be(null, "Because the transfer should be deleted");
            }

            [Fact]
            public async Task Then_No_Set_Should_Be_Deleted_When_Set_Does_Not_Exist()
            {
                var testId = Guid.NewGuid();
                var flashcardsetService = new FlashcardSetService(_context);

                var testSet1 = new FlashcardSet
                {
                    Id = Guid.NewGuid(),
                    Type = "Test",
                    FlashcardAmount = 3,
                    Report = new List<bool> { true },
                    UserAnswers = new List<string> { "Test" },
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

                await _context.FlashcardSets.AddAsync(testSet1);
                await _context.FlashcardSets.AddAsync(testSet2);
                await _context.SaveChangesAsync();

                Func<Task> act = async () => await flashcardsetService.DeleteFlashcardSetAsync(testId);
                await act.Should().ThrowAsync<ObjectNotFoundException>();

            var result = await _context.FlashcardSets.ToListAsync();

                result.Count().Should().Be(2, "Because no sets should be deleted");

        }

        
    }
}
