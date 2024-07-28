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

        public Task<Verse> GetVerseById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Verse> GetVerseByKey(string key)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Verse>> GetVersesByChapterId(int chapterId)
        {
            return await _context.Verses.Where(v => v.ChapterId == chapterId).ToListAsync();
             
        }

        public async Task PopulateVersesAsync()
        {
            //Console.WriteLine("In verse service");
            var client = new RestClient(new RestClientOptions("https://api.quran.com"));
            var chapters = _context.Chapters.Distinct().ToList();
            foreach (var chapter in chapters)
            {
                var request = new RestRequest("/api/v4/verses/by_chapter/" + chapter.Id, Method.Get);
                request.AddQueryParameter("translations", 131);
                request.AddQueryParameter("fields", "text_uthmani,image_url");
                request.AddHeader("Accept", "application/json");

                var response = await client.ExecuteAsync(request);
                //Console.WriteLine("Request sent");

                if (response.IsSuccessful)
                {

                    var apiResponse = JsonConvert.DeserializeObject<VerseApiResponse>(response.Content);
                    var verses = apiResponse?.Verses;

                    if (verses != null)
                    {

                        foreach (var verse in verses)
                        {
                            verse.Chapter = chapter;
                            verse.ChapterId = chapter.Id;
                            //
                            _context.Verses.Add(verse);
                            chapter.Verses.Add(verse);
                            //Console.WriteLine(verse.Id);
                        }

                        //Console.WriteLine("Done");

                        await _context.SaveChangesAsync();

                    }

                }
                else
                {
                    throw new Exception("Failed to retrieve verses from the API");
                }
            }

        }
    }
}
