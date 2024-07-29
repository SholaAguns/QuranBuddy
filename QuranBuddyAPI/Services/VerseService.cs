using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QuranBuddyAPI.Contexts;
using QuranBuddyAPI.Models;
using RestSharp;

namespace QuranBuddyAPI.Services
{
    public class VerseService : IVerseService
    {
        private readonly QuranDBContext _context;

        public VerseService(QuranDBContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Verse>> GetVersesByChapterNameAsync(string chapterName)
        {
            return await _context.Verses.Where(v => v.Chapter.Name == chapterName).ToListAsync();
        }

        public async Task<Verse> GetVerseByIdAsync(int verseId)
        {
            return await _context.Verses.Where(v => v.Id == verseId).SingleOrDefaultAsync();
        }

        public async Task<Verse> GetVerseByKeyAsync(string key)
        {
            return await _context.Verses.Where(v => v.VerseKey == key).SingleOrDefaultAsync();
        }

        public async Task<ICollection<Verse>> GetVersesByChapterIdAsync(int chapterId)
        {
            return await _context.Verses.Where(v => v.ChapterId == chapterId).ToListAsync();
             
        }

        public async Task PopulateVersesAsync()
        {
            var client = new RestClient(new RestClientOptions("https://api.quran.com"));
            var chapters = _context.Chapters.Distinct().ToList();


            foreach (var chapter in chapters)
            {


                int currentPage = 1;
                int totalPages = 1;



                do
                {
                    var request = new RestRequest("/api/v4/verses/by_chapter/" + chapter.Id, Method.Get);
                    request.AddQueryParameter("translations", 131);
                    request.AddQueryParameter("fields", "text_uthmani,image_url");
                    request.AddQueryParameter("page", currentPage.ToString());
                    request.AddHeader("Accept", "application/json");

                    var response = await client.ExecuteAsync(request);


                    if (response.IsSuccessful)
                    {

                        var apiResponse = JsonConvert.DeserializeObject<VerseApiResponse>(response.Content);
                        var verses = apiResponse?.Verses;
                        var pagination = apiResponse?.Pagination;

                        if (verses != null)
                        {

                            foreach (var verse in verses)
                            {
                                verse.Chapter = chapter;
                                verse.ChapterId = chapter.Id;
                                _context.Verses.Add(verse);

                            }
                            

                            totalPages = pagination.TotalPages;
                            currentPage++;


                            await _context.SaveChangesAsync();

                        }

                    }
                    else
                    {
                        throw new Exception("Failed to retrieve verses from the API");
                    }
                }
                while (currentPage <= totalPages);
            }

        }
    }
}
