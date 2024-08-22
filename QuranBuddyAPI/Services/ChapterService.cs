using QuranBuddyAPI.Models;
using QuranBuddyAPI.Entities;
using QuranBuddyAPI.Contexts;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Query;

namespace QuranBuddyAPI.Services
{
    public class ChapterService : IChapterService
    {
        private readonly QuranDBContext _context;

        public ChapterService(QuranDBContext context)
        {
            _context = context;
        }

        public async Task PopulateChaptersAsync()
        {
            var client = new RestClient(new RestClientOptions("https://api.quran.com"));
            var request = new RestRequest("/api/v4/chapters", Method.Get);
            request.AddHeader("Accept", "application/json");

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {

                var apiResponse = JsonConvert.DeserializeObject<ChapterApiResponse>(response.Content);
                var chapters = apiResponse?.Chapters;

                if (chapters != null)
                {

                    foreach (var chapter in chapters)
                    {
                        _context.Chapters.Add(chapter);
 
                    }

                    await _context.SaveChangesAsync();

                }

            }
            else
            {
                throw new Exception("Failed to retrieve chapters from the API");
            }
        }

        public async Task DeleteAllChaptersAsync()
        {
            var chapters = await _context.Chapters.ToListAsync();

            _context.Chapters.RemoveRange(chapters);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Chapter>> GetAllChaptersAsync()
        {
            var chapters = await _context.Chapters.ToListAsync();

            var chapterDtos = chapters.Select(c => new ChapterDto
            {
                Id = c.Id,
                VersesCount = c.VersesCount,
                Name = c.Name,
                NameArabic = c.NameArabic,
                TranslatedName = c.TranslatedName.Name,
                TranslatedLanguage = c.TranslatedName.LanguageName,
                RevelationPlace = c.RevelationPlace,
                BismillahPre = c.BismillahPre,

            }).ToList();

            return chapters;
        }

        public async Task<Chapter> GetChapterByIdAsync(int id)
        {
            var chapter = await _context.Chapters.Where(c => c.Id == id).FirstOrDefaultAsync();

            var chapterDto = new ChapterDto
            {
                Id = chapter.Id,
                VersesCount = chapter.VersesCount,
                Name = chapter.Name,
                NameArabic = chapter.NameArabic,
                TranslatedName = chapter.TranslatedName.Name,
                TranslatedLanguage = chapter.TranslatedName.LanguageName,
                RevelationPlace = chapter.RevelationPlace,
                BismillahPre = chapter.BismillahPre,

            };

            return chapter;
        }

        public async Task<ICollection<Chapter>> GetChaptersByNameAsync(string name)
        {
            var chapters =  await _context.Chapters.Where(c => c.Name.ToLower().Contains(name.ToLower())).ToListAsync();

            var chapterDtos = chapters.Select(c => new ChapterDto
            {
                Id = c.Id,
                VersesCount = c.VersesCount,
                Name = c.Name,
                NameArabic = c.NameArabic,
                TranslatedName = c.TranslatedName.Name,
                TranslatedLanguage = c.TranslatedName.LanguageName,
                RevelationPlace = c.RevelationPlace,
                BismillahPre = c.BismillahPre,

            }).ToList();

            return chapters;
        }


    }
}
