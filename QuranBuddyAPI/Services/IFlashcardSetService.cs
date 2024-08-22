using Microsoft.AspNetCore.Mvc;
using QuranBuddyAPI.Models;
using QuranBuddyAPI.Entities;

namespace QuranBuddyAPI.Services
{
    public interface IFlashcardSetService
    {
        public Task<ICollection<FlashcardSet>> GetAllFlashcardSetsAsync();

        public Task<FlashcardSet> GetFlashcardSetByIdAsync(Guid id);

        public Task<ICollection<FlashcardSet>> GetFlashcardSetByNameAsync(string name);
        
        public Task UpdateFlashcardSetNameAsync(FlashcardSetUpdateNameRequest flashcardRequest);

        public Task SetFlashcardSetAnwsersAsync(FlashcardSetAnswersRequest flashcardRequest);
    }
}
