using Microsoft.AspNetCore.Mvc;
using QuranBuddyAPI.Services;

namespace QuranBuddyAPI.Controllers
{
    [Route("api/verses")]
    [ApiController]
    public class VerseController : Controller
    {
        private readonly VerseService _verseService;


        public VerseController(VerseService verseService )
        {
            _verseService = verseService;
        }

        [HttpGet("by-chapter-id/{id}", Name = "GetVersesByChapterId")]
        public async Task<IActionResult> GetVersesChapterById(int id)
        {


            var verses = _verseService.GetVersesByChapterId(id);

            return Ok(verses);

        }
    }
}
