using Microsoft.EntityFrameworkCore;
using QuranBuddyAPI.Contexts;
using QuranBuddyAPI.Models;
using QuranBuddyAPI.Entities;
using QuranBuddyAPI.Services;
using System;

namespace QuranBuddyAPI.FlashcardServices
{
    public class QuranFlashcardService : IFlashcardService
    {
        private readonly QuranDBContext _context;
        private string _type = "Quran";


        public QuranFlashcardService(QuranDBContext context)
        {
            _context = context;
        }

        private FlashcardSet PopulateFlashcardSet(List<Verse> Verses, FlashcardSet flashcardSet)
        {
            Random random = new Random();
            HashSet<int> uniqueNumbers = new HashSet<int>();

            while (uniqueNumbers.Count < flashcardSet.FlashcardAmount)
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
                    FlashcardSetId = flashcardSet.Id,
                    FlashcardSet = flashcardSet,
                    Question = verse.TextUthmani,
                    Answer = chapter.Name,
                    ImageUrl = verse.ImageUrl,


                };

                _context.Flashcards.Add(flashcard);
                
            }

            return flashcardSet;
        }

        public async Task<FlashcardSet> GetFlashcardSetAsync(int amount)
        {
            
            FlashcardSet flashcardSet = new FlashcardSet();
            flashcardSet.Id = Guid.NewGuid();
            flashcardSet.Type = _type;
            flashcardSet.Name = _type + "_flashcards" + string.Format("{0:yyyy-MM-dd_HH-mm-ss}", DateTime.Now);
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
                    FlashcardSetId = flashcardSet.Id,
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

        public async Task<FlashcardSet> GetFlashcardSetByIdsAsync(int amount, List<int> idList)
        {
            FlashcardSet flashcardSet = new FlashcardSet();
            flashcardSet.Id = Guid.NewGuid();
            flashcardSet.Type = _type;
            flashcardSet.Name = _type + "_flashcards" + string.Format("{0:yyyy-MM-dd_HH-mm-ss}", DateTime.Now);
            flashcardSet.FlashcardAmount = amount;

            List<Verse> Verses = new List<Verse>();

            foreach(var id in idList)
            {
                var chapterVerses = _context.Verses.Where(v => v.ChapterId == id).ToList();

                Verses.AddRange(chapterVerses);

            }

            flashcardSet = PopulateFlashcardSet(Verses, flashcardSet);

            _context.FlashcardSets.Add(flashcardSet);
            await _context.SaveChangesAsync();

            return flashcardSet;
        }

        public async Task<FlashcardSet> GetFlashcardSetByRangeAsync(int amount, int rangeStart, int rangeEnd)
        {
            FlashcardSet flashcardSet = new FlashcardSet();
            flashcardSet.Id = Guid.NewGuid();
            flashcardSet.Type = _type;
            flashcardSet.Name = _type + "_flashcards" + string.Format("{0:yyyy-MM-dd_HH-mm-ss}", DateTime.Now);
            flashcardSet.FlashcardAmount = amount;

            List<Verse> Verses = new List<Verse>();
            

            for (int chapterId = rangeStart; chapterId <= rangeEnd; chapterId++)
            {
                var chapterVerses = _context.Verses.Where(v => v.ChapterId == chapterId).ToList();

                Verses.AddRange(chapterVerses);

            }

            flashcardSet = PopulateFlashcardSet(Verses, flashcardSet);

            _context.FlashcardSets.Add(flashcardSet);
            await _context.SaveChangesAsync();

            return flashcardSet;


        }

        public async Task<FlashcardSet> GetFlashcardSetByNamesAsync(int amount, List<string> nameList)
        {
            FlashcardSet flashcardSet = new FlashcardSet();
            flashcardSet.Id = Guid.NewGuid();
            flashcardSet.Type = _type;
            flashcardSet.Name = _type + "_flashcards" + string.Format("{0:yyyy-MM-dd_HH-mm-ss}", DateTime.Now);
            flashcardSet.FlashcardAmount = amount;

            List<Verse> Verses = new List<Verse>();


            foreach (var name in nameList)
            {
                var chapterVerses = _context.Verses.Where(v => v.Chapter.Name == name).ToList();

                Verses.AddRange(chapterVerses);

            }

            flashcardSet = PopulateFlashcardSet(Verses, flashcardSet);

            _context.FlashcardSets.Add(flashcardSet);
            await _context.SaveChangesAsync();

            return flashcardSet;


        }

        public async Task<FlashcardSet> GetFlashcardSetByJuzAsync(int amount, List<int> idList)
        {
            FlashcardSet flashcardSet = new FlashcardSet();
            flashcardSet.Id = Guid.NewGuid();
            flashcardSet.Type = _type;
            flashcardSet.Name = _type + "_flashcards" + string.Format("{0:yyyy-MM-dd_HH-mm-ss}", DateTime.Now);
            flashcardSet.FlashcardAmount = amount;

            List<Verse> Verses = new List<Verse>();

            foreach (var id in idList)
            {
                var chapterVerses = _context.Verses.Where(v => v.JuzNumber == id).ToList();

                Verses.AddRange(chapterVerses);

            }

            flashcardSet = PopulateFlashcardSet(Verses, flashcardSet);

            _context.FlashcardSets.Add(flashcardSet);
            await _context.SaveChangesAsync();

            return flashcardSet;
        }
    }
}
