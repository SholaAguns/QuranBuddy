using QuranBuddyAPI.Models;

namespace QuranBuddyAPI.FlashcardServices
{
    public interface IFlashcardService
    {
        Task<FlashcardSet> GetFlashcardSetAsync(int amount);
    }
}
