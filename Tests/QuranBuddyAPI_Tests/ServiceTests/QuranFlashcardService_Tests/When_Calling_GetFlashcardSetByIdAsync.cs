using Microsoft.EntityFrameworkCore;
using QuranBuddyAPI.Contexts;
using QuranBuddyAPI.FlashcardServices;
using FluentAssertions;
using QuranBuddyAPI.Models;
using QuranBuddyAPI_Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuranBuddyAPI_Tests.ServiceTests.QuranFlashcardService_Tests
{
    public class When_Calling_GetFlashcardSetByIdAsync
    {
        private DbContextOptions<QuranDBContext> _options = new DbContextOptionsBuilder<QuranDBContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        public FakeContext _context;



        public When_Calling_GetFlashcardSetByIdAsync()
        {
            _context = new FakeContext(_options);

        }

        [Fact]
        public async Task Then_A_FlashcardSet_With_3_Flashcards_Should_Be_Returned()
        {
            int flashcardAmount = 3;
            var idList = new List<int>() { 1, 2, 3 };
            var flashcardService = new QuranFlashcardService(_context);
            Mocks.PopulateContext(_context);

            var result = await flashcardService.GetFlashcardSetByIdsAsync(flashcardAmount, idList);

            result.Flashcards.Count().Should().Be(3, "Because the set name should be updated");
            result.Should().NotBeNull();
            result.Id.Should().NotBeEmpty();
            result.Type.Should().Be("Quran", "Because it should");


        }
    }
}
