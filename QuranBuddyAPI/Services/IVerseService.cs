using QuranBuddyAPI.Models;

namespace QuranBuddyAPI.Services
{
    public interface IVerseService
    {
        public Task PopulateVersesAsync();

        public Task<Verse> GetVerseById(int id);

        public Task<Verse> GetVerseByKey(string key);

        public Task<ICollection<Verse>> GetVersesByChapter(int chapterId);

        
    }
}
