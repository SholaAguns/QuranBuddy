using Microsoft.AspNetCore.Mvc;
using QuranBuddyAPI.Models;

namespace QuranBuddyAPI.Services
{
    public interface IFlashcardSetService
    {
        public Task<ICollection<FlashcardSetResponse>> GetAllFlashcardSetsAsync();

        public Task<FlashcardSet> GetFlashcardSetByIdAsync(Guid id);

        public Task<ICollection<FlashcardSetResponse>> GetFlashcardSetByNameAsync(string name);
        
        public Task UpdateFlashcardSetNameAsync(FlashcardSetUpdateNameRequest flashcardRequest);

        public Task SetFlashcardSetAnwsersAsync(FlashcardSetAnswersRequest flashcardRequest);
    }
}
