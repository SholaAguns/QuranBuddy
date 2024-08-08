using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuranBuddyAPI.Services;
using QuranBuddyAPI.Models;

namespace QuranBuddyAPI.Controllers
{
    [Route("api/chapters")]
    [ApiController]
    public class ChapterController : Controller
    {
        private readonly IChapterService _chapterService;


        public ChapterController(IChapterService chapterService)
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
            var chapterViewModel = new ChapterIdViewModel { Id = id };



            if (!TryValidateModel(chapterViewModel))
            {
                return BadRequest(ModelState);
            }

            var chapter = await _chapterService.GetChapterByIdAsync(id);

            if (chapter == null)
            {
                return NotFound();
            }

            return Ok(chapter);
            
        }

        [HttpGet("by-name/{name}", Name = "GetChapterByName")]
        public async Task<IActionResult> GetChapterByString(string name)
        {
            var chapterViewModel = new ChapterNameViewModel { Name = name };

            if (!TryValidateModel(chapterViewModel))
            {
                return BadRequest(ModelState);
            }
            var chapters = await _chapterService.GetChaptersByNameAsync(name);

            return Ok(chapters);

        }
    }
}
