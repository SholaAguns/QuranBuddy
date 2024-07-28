using Microsoft.AspNetCore.Mvc;
using QuranBuddyAPI.Services;

namespace QuranBuddyAPI.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly ChapterService _chapterService;
        private readonly VerseService _verseService;

        public AdminController(ChapterService chapterService, VerseService verseService)
        {
            _chapterService = chapterService;
            _verseService = verseService;
        }

        [HttpPost("populate-chapters")]
        public async Task<IActionResult> PopulateChapters()
        {
            await _chapterService.PopulateChaptersAsync();
            return Ok("Chapters populated successfully");
        }

        [HttpPost("populate-verses")]
        public async Task<IActionResult> PopulateVerses()
        {
            await _verseService.PopulateVersesAsync();
            return Ok("Verses populated successfully");
        }

        [HttpDelete("delete-all-chapters")]
        public async Task<IActionResult> DeleteAllChapters()
        {
            await _chapterService.DeleteAllChaptersAsync();
            return Ok("All chapters deleted successfully");
        }
    }
}
