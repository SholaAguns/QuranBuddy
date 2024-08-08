using QuranBuddyAPI.Models;

namespace QuranBuddyAPI.FlashcardServices
{
    public class DefaultFlashcardService : IFlashcardService
    {
        public Task<FlashcardSet> GetFlashcardSetAsync(int amount)
        {
            throw new NotImplementedException();
        }

        public Task<FlashcardSet> GetFlashcardSetByIdsAsync(int amount, List<int> idList)
        {
            throw new NotImplementedException();
        }

        public Task<FlashcardSet> GetFlashcardSetByNamesAsync(int amount, List<string> nameList)
        {
            throw new NotImplementedException();
        }

        public Task<FlashcardSet> GetFlashcardSetByRangeAsync(int amount, int rangeStart, int rangeEnd)
        {
            throw new NotImplementedException();
        }
    }
}
