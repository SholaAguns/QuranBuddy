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
    }
}
