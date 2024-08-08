using QuranBuddyAPI.Models;

namespace QuranBuddyAPI.FlashcardServices
{
    public interface IFlashcardService
    {
        Task<FlashcardSet> GetFlashcardSetAsync(int amount);

        Task<FlashcardSet> GetFlashcardSetByRangeAsync(int amount, int rangeStart, int rangeEnd);

        Task<FlashcardSet> GetFlashcardSetByIdsAsync(int amount, List<int> idList);

        Task<FlashcardSet> GetFlashcardSetByNamesAsync(int amount, List<string> nameList);
    }
}
