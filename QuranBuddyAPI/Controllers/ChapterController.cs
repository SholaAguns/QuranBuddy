using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuranBuddyAPI.Services;

namespace QuranBuddyAPI.Controllers
{
    [Route("api/chapters")]
    [ApiController]
    public class ChapterController : Controller
    {
        private readonly ChapterService _chapterService;


        public ChapterController(ChapterService chapterService)
        {
            _chapterService = chapterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetChapters()
        {
            var chapters = await _chapterService.GetAllChaptersAsync();

            return Ok(chapters);
        }

        [HttpGet("by-id/{id}", Name = "GetChapterById")]
        public async Task<IActionResult> GetChapterById(int id)
        {

            
                var chapter = await _chapterService.GetChapterByIdAsync(id);

                return Ok(chapter);
            
        }

        [HttpGet("by-name/{name}", Name = "GetChapterByName")]
        public async Task<IActionResult> GetChapterByString(string name)
        {

            var chapters = await _chapterService.GetChaptersByNameAsync(name);

            return Ok(chapters);

        }
    }
}
