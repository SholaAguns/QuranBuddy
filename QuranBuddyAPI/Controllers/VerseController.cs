using Microsoft.AspNetCore.Mvc;
using QuranBuddyAPI.Services;
using System.Xml.Linq;

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


            var verses = _verseService.GetVersesByChapterIdAsync(id);

            return Ok(verses);

        }

        [HttpGet("by-id/{id}", Name = "GetVerseById")]
        public async Task<IActionResult> GetVerseById(int id)
        {


            var verse = _verseService.GetVerseByIdAsync(id);

            return Ok(verse);

        }

        [HttpGet("by-chapter-name/{name}", Name = "GetVersesByChapterName")]
        public async Task<IActionResult> GetVersesByChapterName(string name)
        {


            var verses = _verseService.GetVersesByChapterNameAsync(name);

            return Ok(verses);

        }
    }
}
