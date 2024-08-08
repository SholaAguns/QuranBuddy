using QuranBuddyAPI.Models;

namespace QuranBuddyAPI.Services
{
    public interface IVerseService
    {
        public Task PopulateVersesAsync();

        public Task<VerseDto> GetVerseByIdAsync(int verseId);

        public Task<VerseDto> GetVerseByKeyAsync(string key);

        public Task<ICollection<VerseDto>> GetVersesByChapterNameAsync(string chapterName);

        public Task<ICollection<VerseDto>> GetVersesByChapterIdAsync(int chapterId);


    }
}
