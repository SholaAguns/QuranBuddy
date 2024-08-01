using Microsoft.AspNetCore.Mvc;
using QuranBuddyAPI.Models;
using QuranBuddyAPI.Services;
using System.Xml.Linq;

namespace QuranBuddyAPI.Controllers
{
    [Route("api/verses")]
    [ApiController]
    public class VerseController : Controller
    {
        private readonly IVerseService _verseService;


        public VerseController(IVerseService verseService )
        {
            _verseService = verseService;
        }

        [HttpGet("by-chapter-id/{id}", Name = "GetVersesByChapterId")]
        public async Task<IActionResult> GetVersesChapterById(int id)
        {

            var chapterViewModel = new ChapterIdViewModel { Id = id };

            if (!TryValidateModel(chapterViewModel))
            {
                return BadRequest(ModelState);
            }

            var verses = _verseService.GetVersesByChapterIdAsync(id);

            if (verses == null)
            {
                return NoContent();
            }

            return Ok(verses);

        }

        [HttpGet("by-id/{id}", Name = "GetVerseById")]
        public async Task<IActionResult> GetVerseById(int id)
        {


            var verse = _verseService.GetVerseByIdAsync(id);

            if (verse == null)
            {
                return NoContent();
            }

            return Ok(verse);

        }

        [HttpGet("by-chapter-name/{name}", Name = "GetVersesByChapterName")]
        public async Task<IActionResult> GetVersesByChapterName(string name)
        {
            var chapterViewModel = new ChapterNameViewModel { Name = name };

            if (!TryValidateModel(chapterViewModel))
            {
                return BadRequest(ModelState);
            }

            var verses = _verseService.GetVersesByChapterNameAsync(name);

            if (verses == null)
            {
                return NoContent();
            }


            return Ok(verses);

        }
    }
}
