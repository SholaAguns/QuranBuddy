using QuranBuddyAPI.Models;

namespace QuranBuddyAPI.Services
{
    public interface IChapterService
    {

        public Task PopulateChaptersAsync();

        public Task<Chapter> GetChapterByIdAsync(int id);

        public Task<Chapter> GetChapterByNameAsync(string name);

        public Task<ICollection<Chapter>> GetAllChaptersAsync();
    }
}
