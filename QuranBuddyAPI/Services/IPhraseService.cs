using QuranBuddyAPI.Entities;
using QuranBuddyAPI.Models;

namespace QuranBuddyAPI.Services
{
    public interface IPhraseService
    {

        public Task UpdatePhraseAsync(UpdatePhraseRequest request);

        public Task<Phrase> CreatePhraseAsync(CreatePhraseRequest request);

        public Task<Phrase> GetPhraseByIdAsync(Guid id);

        public Task<ICollection<Phrase>> GetPhrasesByJuzAsync(int id);

        public Task<ICollection<Phrase>> GetPhrasesByChapterAsync(int id);

        public Task<ICollection<Phrase>> GetAllPhrasesAsync();

        public Task DeletePhraseAsync(Guid id);

        public Task DeletePhraseRangeAsync(Guid[] ids);
    }
}
