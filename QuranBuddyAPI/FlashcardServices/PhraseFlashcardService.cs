using Microsoft.EntityFrameworkCore;
using QuranBuddyAPI.Contexts;
using QuranBuddyAPI.Entities;
using System.Collections;
using System.Collections.Generic;

namespace QuranBuddyAPI.FlashcardServices
{
    public class PhraseFlashcardService : IFlashcardService
    {

        private readonly QuranDBContext _context;
        private string _type = "Phrase";

        public PhraseFlashcardService(QuranDBContext context)
        {
            _context = context;
        }
        public async Task<FlashcardSet> GetFlashcardSetAsync(int amount)
        {
            FlashcardSet flashcardSet = new FlashcardSet();
            flashcardSet.Id = Guid.NewGuid();
            flashcardSet.Type = _type;
            flashcardSet.Name = _type + "_flashcards" + string.Format("{0:yyyy-MM-dd_HH-mm-ss}", DateTime.Now);
            flashcardSet.FlashcardAmount = amount;

            var phrases = await _context.Phrases
            .FromSqlRaw("SELECT * FROM Phrases ORDER BY RANDOM() LIMIT {0}", amount)
            .ToListAsync();

            foreach (Phrase phrase in phrases)
            {

                var flashcard = new Flashcard()
                {
                    Id = Guid.NewGuid(),
                    FlashcardSetId = flashcardSet.Id,
                    FlashcardSet = flashcardSet,
                    Question = phrase.Text,
                    Answer = phrase.Translation,
                    ImageUrl = phrase.ImageUrl
                };

                _context.Flashcards.Add(flashcard);
            }

            _context.FlashcardSets.Add(flashcardSet);
            await _context.SaveChangesAsync();

            return flashcardSet;
        }

        public async Task<FlashcardSet> GetFlashcardSetByIdsAsync(int amount, List<int> idList)
        {
            FlashcardSet flashcardSet = new FlashcardSet();
            flashcardSet.Id = Guid.NewGuid();
            flashcardSet.Type = _type;
            flashcardSet.Name = _type + "_flashcards" + string.Format("{0:yyyy-MM-dd_HH-mm-ss}", DateTime.Now);
            flashcardSet.FlashcardAmount = amount;

            List<Phrase> Phrases = new List<Phrase>();

            var idListString = string.Join(",", idList);

            var phrases = await _context.Phrases
                .FromSqlRaw($"SELECT * FROM Phrases WHERE ChapterId IN ({idListString}) ORDER BY RANDOM() LIMIT {amount}")
                .ToListAsync();

            foreach (Phrase phrase in phrases)
            {

                var flashcard = new Flashcard()
                {
                    Id = Guid.NewGuid(),
                    FlashcardSetId = flashcardSet.Id,
                    FlashcardSet = flashcardSet,
                    Question = phrase.Text,
                    Answer = phrase.Translation,
                    ImageUrl = phrase.ImageUrl
                };

                _context.Flashcards.Add(flashcard);
            }

            _context.FlashcardSets.Add(flashcardSet);
            await _context.SaveChangesAsync();

            return flashcardSet;
        }

        public async Task<FlashcardSet> GetFlashcardSetByJuzAsync(int amount, List<int> juzNumbers)
        {
            FlashcardSet flashcardSet = new FlashcardSet();
            flashcardSet.Id = Guid.NewGuid();
            flashcardSet.Type = _type;
            flashcardSet.Name = _type + "_flashcards" + string.Format("{0:yyyy-MM-dd_HH-mm-ss}", DateTime.Now);
            flashcardSet.FlashcardAmount = amount;

            List<Phrase> Phrases = new List<Phrase>();

            var juzNumbersString = string.Join(",", juzNumbers);

            var phrases = await _context.Phrases
                .FromSqlRaw($"SELECT * FROM Phrases WHERE JuzNumber IN ({juzNumbersString}) ORDER BY RANDOM() LIMIT {amount}")
                .ToListAsync();

            foreach (Phrase phrase in phrases)
            {

                var flashcard = new Flashcard()
                {
                    Id = Guid.NewGuid(),
                    FlashcardSetId = flashcardSet.Id,
                    FlashcardSet = flashcardSet,
                    Question = phrase.Text,
                    Answer = phrase.Translation,
                    ImageUrl = phrase.ImageUrl
                };

                _context.Flashcards.Add(flashcard);
            }

            _context.FlashcardSets.Add(flashcardSet);
            await _context.SaveChangesAsync();

            return flashcardSet;
        }

        public async Task<FlashcardSet> GetFlashcardSetByNamesAsync(int amount, List<string> nameList)
        {
            throw new NotImplementedException();
        }

        public async Task<FlashcardSet> GetFlashcardSetByRangeAsync(int amount, int rangeStart, int rangeEnd)
        {
            FlashcardSet flashcardSet = new FlashcardSet();
            flashcardSet.Id = Guid.NewGuid();
            flashcardSet.Type = _type;
            flashcardSet.Name = _type + "_flashcards" + string.Format("{0:yyyy-MM-dd_HH-mm-ss}", DateTime.Now);
            flashcardSet.FlashcardAmount = amount;

            List<Phrase> Phrases = new List<Phrase>();
            var range = Enumerable.Range(rangeStart, rangeEnd-rangeStart);

            var rangeString = string.Join(",", range);

            var phrases = await _context.Phrases
                .FromSqlRaw($"SELECT * FROM Phrases WHERE ChapterId IN ({rangeString}) ORDER BY RANDOM() LIMIT {amount}")
                .ToListAsync();

            foreach (Phrase phrase in phrases)
            {

                var flashcard = new Flashcard()
                {
                    Id = Guid.NewGuid(),
                    FlashcardSetId = flashcardSet.Id,
                    FlashcardSet = flashcardSet,
                    Question = phrase.Text,
                    Answer = phrase.Translation,
                    ImageUrl = phrase.ImageUrl
                };

                _context.Flashcards.Add(flashcard);
            }

            _context.FlashcardSets.Add(flashcardSet);
            await _context.SaveChangesAsync();

            return flashcardSet;
        }
    }
}
