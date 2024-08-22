using QuranBuddyAPI.Entities;
using QuranBuddyAPI.Models;

namespace QuranBuddyAPI.Services
{
    public interface IVerseService
    {
        public Task PopulateVersesAsync();

        public Task<Verse> GetVerseByIdAsync(int verseId);

        public Task<Verse> GetVerseByKeyAsync(string key);

        public Task<ICollection<Verse>> GetVersesByChapterNameAsync(string chapterName);

        public Task<ICollection<Verse>> GetVersesByChapterIdAsync(int chapterId);


    }
}
