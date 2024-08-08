using QuranBuddyAPI.Models;

namespace QuranBuddyAPI.Services
{
    public interface IChapterService
    {

        public Task PopulateChaptersAsync();

        public Task<ChapterDto> GetChapterByIdAsync(int id);

        public Task<ICollection<ChapterDto>> GetChaptersByNameAsync(string name);

        public Task<ICollection<ChapterDto>> GetAllChaptersAsync();
    }
}
