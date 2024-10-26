using Microsoft.EntityFrameworkCore;
using QuranBuddyAPI.Contexts;
using QuranBuddyAPI.Entities;
using QuranBuddyAPI.Models;
using System.Data.Entity.Core;


namespace QuranBuddyAPI.Services
{
    public class PhraseService : IPhraseService
    {

        private readonly QuranDBContext _context;

        public PhraseService(QuranDBContext context)
        {
            _context = context;
        }

        public async  Task<Phrase> CreatePhraseAsync(CreatePhraseRequest request)
        {
            var phrase = new Phrase()
            {
                Id = Guid.NewGuid(),
                Text = request.Text,
                Translation = request.Translation,
                ImageUrl = request.ImageUrl,
                ChapterId = request.ChapterId,
                JuzNumber = request.JuzNumber
            };

            _context.Phrases.Add(phrase);

            await _context.SaveChangesAsync();

            return phrase;
        }

        public async Task DeletePhraseAsync(Guid id)
        {
            var phrase = await _context.Phrases.SingleOrDefaultAsync(p => p.Id == id);

            if (phrase == null) throw new ObjectNotFoundException();

            _context.Phrases.Remove(phrase);

            await _context.SaveChangesAsync();
        }

        public async Task DeletePhraseRangeAsync(Guid[] ids)
        {
            List<Phrase> phraseRange = new List<Phrase>();

            foreach (var id in ids)
            {
                var phrase = await _context.Phrases.SingleOrDefaultAsync(p => p.Id == id);

                if (phrase != null) phraseRange.Add(phrase);

            }

            _context.Phrases.RemoveRange(phraseRange);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Phrase>> GetAllPhrasesAsync()
        {
            var phrases = await _context.Phrases.ToListAsync();

            return phrases;
        }

        public async Task<ICollection<Phrase>> GetPhrasesByChapterAsync(int id)
        {

            return await _context.Phrases.Where(p => p.ChapterId == id).ToListAsync();
        }

        public async Task<Phrase> GetPhraseByIdAsync(Guid id)
        {
            return await _context.Phrases.Where(c => c.Id == id).SingleOrDefaultAsync();

        }

        public async Task<ICollection<Phrase>> GetPhrasesByJuzAsync(int juzNumber)
        {
            return await _context.Phrases.Where(p => p.JuzNumber == juzNumber).ToListAsync();
        }

        public async Task UpdatePhraseAsync(UpdatePhraseRequest request)
        {
            var phrase = await _context.Phrases.SingleOrDefaultAsync(p => p.Id == request.Id);

            if (phrase == null) throw new ObjectNotFoundException();

            phrase.Text = request.Text;
            phrase.Translation = request.Translation;
            phrase.ImageUrl = request.ImageUrl;
            phrase.ChapterId = request.ChapterId;
            phrase.JuzNumber = request.JuzNumber;

            _context.Phrases.Update(phrase);
            await _context.SaveChangesAsync();
        }
    }
}
