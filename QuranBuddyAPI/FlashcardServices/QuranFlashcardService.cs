using Microsoft.EntityFrameworkCore;
using QuranBuddyAPI.Contexts;
using QuranBuddyAPI.Models;
using QuranBuddyAPI.Services;

namespace QuranBuddyAPI.FlashcardServices
{
    public class QuranFlashcardService : IFlashcardService
    {
        private readonly QuranDBContext _context;


        public QuranFlashcardService(QuranDBContext context)
        {
            _context = context;
        }
        public Task<FlashcardSet> GetFlashcardSet(int amount)
        {
            throw new NotImplementedException();
        }

        public async Task<FlashcardSet> GetFlashcardSetAsync(int amount)
        {
            
            FlashcardSet flashcardSet = new FlashcardSet();
            flashcardSet.Id = Guid.NewGuid();
            flashcardSet.Type = "Quran";
            flashcardSet.FlashcardAmount = amount;

            int maxVerseId = _context.Verses.Max(v => v.Id);
            Random random = new Random();
            HashSet<int> uniqueNumbers = new HashSet<int>();



            while (uniqueNumbers.Count < amount)
            {
                int number = random.Next(1, maxVerseId);
                uniqueNumbers.Add(number);
            }

            Console.WriteLine(uniqueNumbers.ToString() + ',');

            foreach (int number in uniqueNumbers)
            {
                Verse verse = _context.Verses.Where(v => v.Id == number).SingleOrDefault();
                var chapter = _context.Chapters.Where(c => c.Id == verse.ChapterId).SingleOrDefault();

                Console.WriteLine("Verse Number: " + number);

                var flashcard = new Flashcard()
                {
                    Id = Guid.NewGuid(),
                    FlashcardId = flashcardSet.Id,
                    FlashcardSet = flashcardSet,
                    Question = verse.TextUthmani,
                    Answer = chapter.Name,
                    ImageUrl = verse.ImageUrl


                };

                _context.Flashcards.Add(flashcard);
                //flashcardSet.Flashcards.Add(flashcard);
            }

           

            _context.FlashcardSets.Add(flashcardSet);
            await _context.SaveChangesAsync();

            return flashcardSet;

        }

        public async Task<FlashcardSet> GetFlashcardSetByRangeAsync(int amount, int rangeStart, int rangeEnd)
        {
            FlashcardSet flashcardSet = new FlashcardSet();
            flashcardSet.Id = Guid.NewGuid();

            List<Verse> Verses = new List<Verse>();
            Random random = new Random();
            HashSet<int> uniqueNumbers = new HashSet<int>();

            for (int chapterId = rangeStart; chapterId <= rangeEnd; chapterId++)
            {
                var chapterVerses = _context.Verses.Where(v => v.ChapterId == chapterId).ToList();

                Verses.AddRange(chapterVerses);

            }

            while (uniqueNumbers.Count < amount)
            {
                int number = random.Next(0, Verses.Count);
                uniqueNumbers.Add(number);
            }


            foreach (int number in uniqueNumbers)
            {
                Verse verse = Verses[number];
                var chapter = _context.Chapters.Where(c => c.Id == verse.ChapterId).SingleOrDefault();

                var flashcard = new Flashcard()
                {
                    Id = Guid.NewGuid(),
                    FlashcardSet = flashcardSet,
                    Question = verse.TextUthmani,
                    Answer = chapter.Name,
                    ImageUrl = verse.ImageUrl,


                };


                flashcardSet.Flashcards.Add(flashcard);
            }

            _context.FlashcardSets.Add(flashcardSet);
            await _context.SaveChangesAsync();

            return flashcardSet;


        }
    }
}
