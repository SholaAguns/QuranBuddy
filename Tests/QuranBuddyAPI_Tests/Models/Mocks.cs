using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuranBuddyAPI.Models;
using QuranBuddyAPI.Contexts;
using Microsoft.EntityFrameworkCore;
using QuranBuddyAPI.Entities;
using QuranBuddyAPI.Services;
using System.Data.Entity;

namespace QuranBuddyAPI_Tests.Models
{
    public class Mocks
    {
        public async static void PopulateContext(FakeContext fakeContext)
        {

            List<Chapter> chapters = new List<Chapter>
            { 
                new Chapter  {
                Id = 1,
                Name = "Test Chapter",
                NameArabic = "??????????",
                TranslatedName = new TranslatedName { LanguageName = "english", Name = "Translated Name" },
                BismillahPre = false,
                VersesCount = 10,
                RevelationPlace = "makkah"
                },

                new Chapter  {
                Id = 2,
                Name = "Test Chapter 2",
                NameArabic = "??????????",
                TranslatedName = new TranslatedName { LanguageName = "english", Name = "Translated Name" },
                BismillahPre = false,
                VersesCount = 10,
                RevelationPlace = "makkah"
                },

                new Chapter  {
                Id = 3,
                Name = "Test Chapter 3",
                NameArabic = "??????????",
                TranslatedName = new TranslatedName { LanguageName = "english", Name = "Translated Name" },
                BismillahPre = false,
                VersesCount = 10,
                RevelationPlace = "makkah"
                },
            };

                List <Verse> verses = new List<Verse>
            {
                new Verse {
                    Id = 1,
                    VerseKey = "1:1",
                    ChapterId = 1,
                    VerseNumber = 3,
                    HizbNumber = 0,
                    RubElHizbNumber = 0,
                    RukuNumber = 0,
                    ManzilNumber = 0,
                    SajdahNumber = 0,
                    TextUthmani = "????????",
                    ImageUrl = "test url",
                    PageNumber = 0,
                    JuzNumber = 1,
                    Translations = new List<Translation> {new Translation { Id = 12, ResourceId = 0, Text = "sample translation" } }

                },
                new Verse
                {
                    Id = 2,
                    VerseKey = "1:2",
                    ChapterId = 1,
                    VerseNumber = 4,
                    HizbNumber = 0,
                    RubElHizbNumber = 0,
                    RukuNumber = 0,
                    ManzilNumber = 0,
                    SajdahNumber = 0,
                    TextUthmani = "????????",
                    ImageUrl = "test url",
                    PageNumber = 0,
                    JuzNumber = 1,
                    Translations = new List<Translation> {new Translation { Id = 12, ResourceId = 0, Text = "sample translation" } }
                },
                new Verse
                {
                    Id = 3,
                    VerseKey = "1:3",
                    ChapterId = 1,
                    VerseNumber = 5,
                    HizbNumber = 0,
                    RubElHizbNumber = 0,
                    RukuNumber = 0,
                    ManzilNumber = 0,
                    SajdahNumber = 0,
                    TextUthmani = "????????",
                    ImageUrl = "test url",
                    PageNumber = 0,
                    JuzNumber = 1,
                    Translations = new List<Translation> {new Translation { Id = 12, ResourceId = 0, Text = "sample translation" } }
                },
                new Verse {
                    Id = 4,
                    VerseKey = "2:1",
                    ChapterId = 2,
                    VerseNumber = 3,
                    HizbNumber = 0,
                    RubElHizbNumber = 0,
                    RukuNumber = 0,
                    ManzilNumber = 0,
                    SajdahNumber = 0,
                    TextUthmani = "????????",
                    ImageUrl = "test url",
                    PageNumber = 0,
                    JuzNumber = 1,
                    Translations = new List<Translation> {new Translation { Id = 12, ResourceId = 0, Text = "sample translation" } }

                },
                new Verse
                {
                    Id = 5,
                    VerseKey = "2:2",
                    ChapterId = 2,
                    VerseNumber = 4,
                    HizbNumber = 0,
                    RubElHizbNumber = 0,
                    RukuNumber = 0,
                    ManzilNumber = 0,
                    SajdahNumber = 0,
                    TextUthmani = "????????",
                    ImageUrl = "test url",
                    PageNumber = 0,
                    JuzNumber = 1,
                    Translations = new List<Translation> {new Translation { Id = 12, ResourceId = 0, Text = "sample translation" } }
                },
                new Verse
                {
                    Id = 6,
                    VerseKey = "2:3",
                    ChapterId = 2,
                    VerseNumber = 5,
                    HizbNumber = 0,
                    RubElHizbNumber = 0,
                    RukuNumber = 0,
                    ManzilNumber = 0,
                    SajdahNumber = 0,
                    TextUthmani = "????????",
                    ImageUrl = "test url",
                    PageNumber = 0,
                    JuzNumber = 1,
                    Translations = new List<Translation> {new Translation { Id = 12, ResourceId = 0, Text = "sample translation" } }
                },
                new Verse {
                    Id = 7,
                    VerseKey = "3:1",
                    ChapterId = 3,
                    VerseNumber = 3,
                    HizbNumber = 0,
                    RubElHizbNumber = 0,
                    RukuNumber = 0,
                    ManzilNumber = 0,
                    SajdahNumber = 0,
                    TextUthmani = "????????",
                    ImageUrl = "test url",
                    PageNumber = 0,
                    JuzNumber = 1,
                    Translations = new List<Translation> {new Translation { Id = 12, ResourceId = 0, Text = "sample translation" } }

                },
                new Verse
                {
                    Id = 8,
                    VerseKey = "3:2",
                    ChapterId = 3,
                    VerseNumber = 4,
                    HizbNumber = 0,
                    RubElHizbNumber = 0,
                    RukuNumber = 0,
                    ManzilNumber = 0,
                    SajdahNumber = 0,
                    TextUthmani = "????????",
                    ImageUrl = "test url",
                    PageNumber = 0,
                    JuzNumber = 1,
                    Translations = new List<Translation> {new Translation { Id = 12, ResourceId = 0, Text = "sample translation" } }
                },
                new Verse
                {
                    Id = 9,
                    VerseKey = "2:3",
                    ChapterId = 3,
                    VerseNumber = 5,
                    HizbNumber = 0,
                    RubElHizbNumber = 0,
                    RukuNumber = 0,
                    ManzilNumber = 0,
                    SajdahNumber = 0,
                    TextUthmani = "????????",
                    ImageUrl = "test url",
                    PageNumber = 0,
                    JuzNumber = 1,
                    Translations = new List<Translation> {new Translation { Id = 12, ResourceId = 0, Text = "sample translation" } }
                }

            };


            foreach (var chapter in chapters)
            {
                await fakeContext.Chapters.AddAsync(chapter);
            }


            foreach (var verse in verses)
            {
                await fakeContext.Verses.AddAsync(verse);
            }

            await fakeContext.SaveChangesAsync();
        }
    }

    public class FakeContext : QuranDBContext
    {
        public FakeContext(DbContextOptions<QuranDBContext> options) : base(options) { }

    }
}
