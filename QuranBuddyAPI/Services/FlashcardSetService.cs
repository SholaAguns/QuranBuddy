using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuranBuddyAPI.Contexts;
using QuranBuddyAPI.Models;
using System.Data.Entity.Core;

namespace QuranBuddyAPI.Services
{
    public class FlashcardSetService : IFlashcardSetService
    {
        private readonly QuranDBContext _context;

        public FlashcardSetService(QuranDBContext context)
        {
            _context = context;
        }

        public async Task<ICollection<FlashcardSetResponse>> GetAllFlashcardSetsAsync()
        {
            var flashcardSets = await _context.FlashcardSets.ToListAsync();

            var flashcardSetResponses = flashcardSets.Select(f => new FlashcardSetResponse
            {
                Id = f.Id,
                Name = f.Name
            }).ToList();

            return flashcardSetResponses;
        }

        public async Task<FlashcardSet> GetFlashcardSetByIdAsync(Guid id)
        {
            return await _context.FlashcardSets.SingleOrDefaultAsync(f => f.Id == id);
        }

        public async Task<ICollection<FlashcardSetResponse>> GetFlashcardSetByNameAsync(string name)
        {
            var flashcardSets = await _context.FlashcardSets.Where(f => f.Name.ToLower().Contains(name.ToLower())).ToListAsync();

            var flashcardSetResponses = flashcardSets.Select(f => new FlashcardSetResponse
            {
                Id = f.Id,
                Name = f.Name
            }).ToList();

            return flashcardSetResponses;

        }

        public async Task SetFlashcardSetAnwsersAsync(FlashcardSetAnswersRequest flashcardRequest)
        {
            var flashcardSet = await _context.FlashcardSets.SingleOrDefaultAsync(f => f.Id == flashcardRequest.Id);

            flashcardSet.UserAnswers = flashcardRequest.UserAnswers;

            for (int i = 0; i < flashcardSet.UserAnswers.Count; i++)
            {
                flashcardSet.Report.Add(flashcardSet.Flashcards[i].Answer == flashcardSet.UserAnswers[i]);
            }

            _context.FlashcardSets.Update(flashcardSet);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateFlashcardSetNameAsync(FlashcardSetUpdateNameRequest flashcardRequest)
        {
            var flashcardSet = await _context.FlashcardSets.SingleOrDefaultAsync(f => f.Id == flashcardRequest.Id);

            if (flashcardSet == null) throw new ObjectNotFoundException();

            flashcardSet.Name = flashcardRequest.Name;

            _context.FlashcardSets.Update(flashcardSet);
            await _context.SaveChangesAsync();

        }
    }
}
