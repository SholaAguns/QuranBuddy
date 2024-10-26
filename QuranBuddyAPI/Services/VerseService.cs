﻿using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QuranBuddyAPI.Contexts;
using QuranBuddyAPI.Models;
using QuranBuddyAPI.Entities;
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

            var verses = await _context.Verses.Where(v => v.Chapter.Name == chapterName).ToListAsync();

            return verses;

        }

        public async Task<Verse> GetVerseByIdAsync(int verseId)
        {
            var verse =  await _context.Verses.Where(v => v.Id == verseId).SingleOrDefaultAsync();

            return verse;
        }

        public async Task<Verse> GetVerseByKeyAsync(string key)
        {
            var verse =  await _context.Verses.Where(v => v.VerseKey == key).SingleOrDefaultAsync();


            return verse;
        }

        public async Task<ICollection<Verse>> GetVersesByChapterIdAsync(int chapterId)
        {
            var verses =  await _context.Verses.Where(v => v.ChapterId == chapterId).ToListAsync();

            return verses;

        }

        public async Task PopulateVersesAsync()
        {
            var client = new RestClient(new RestClientOptions("https://api.quran.com"));
            var chapters = _context.Chapters.Distinct().ToList();
            //var chapters = allChapters.GetRange(0, 1);


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
                        //var trackedChapter = await _context.Chapters.FindAsync(chapter.Id);
                        //var trackedChapter = await _context.Chapters.Where(c => c.Id == chapter.Id).FirstOrDefaultAsync();

                        //Console.WriteLine("Chapter name is:" + trackedChapter.Name);

                        if (verses != null)
                        {
                           

                            foreach (var verse in verses)
                            {
                                verse.ChapterId = chapter.Id;
                                verse.Chapter = chapter;
                                //Console.WriteLine("Verse is in chapter: " + verse.Chapter.Name); 
                                _context.Verses.Add(verse);

                            }
                            

                            totalPages = pagination.TotalPages;
                            currentPage++;


                            await _context.SaveChangesAsync();

                        }
                        else
                        {
                            throw new Exception("Verses and chapter must exist");
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
