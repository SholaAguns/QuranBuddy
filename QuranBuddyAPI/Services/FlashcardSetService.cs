using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuranBuddyAPI.Contexts;
using QuranBuddyAPI.Models;
using QuranBuddyAPI.Entities;
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

        public async Task<ICollection<FlashcardSet>> GetAllFlashcardSetsAsync()
        {
            var flashcardSets = await _context.FlashcardSets.ToListAsync();

            return flashcardSets;
        }

        public async Task<FlashcardSet> GetFlashcardSetByIdAsync(Guid id)
        {
            return await _context.FlashcardSets.SingleOrDefaultAsync(f => f.Id == id);
        }

        public async Task<ICollection<FlashcardSet>> GetFlashcardSetByNameAsync(string name)
        {
            var flashcardSets = await _context.FlashcardSets.Where(f => f.Name.ToLower().Contains(name.ToLower())).ToListAsync();

     

            return flashcardSets;

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

        public async Task DeleteFlashcardSetAsync(Guid id)
        {
            var flashcardset = await _context.FlashcardSets.SingleOrDefaultAsync(f => f.Id == id);

            if (flashcardset == null) throw new ObjectNotFoundException();

            _context.FlashcardSets.Remove(flashcardset);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteFlashcardSetRangeAsync(Guid[] ids)
        {
            List<FlashcardSet> flashcardSets = new List<FlashcardSet>();

            foreach(var id in ids)
            {
                flashcardSets.Add(await _context.FlashcardSets.SingleOrDefaultAsync(f => f.Id == id));
            }

            _context.FlashcardSets.RemoveRange(flashcardSets);

            await _context.SaveChangesAsync();
        }


    }
}
