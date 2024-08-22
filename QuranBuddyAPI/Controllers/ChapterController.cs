using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuranBuddyAPI.Services;
using QuranBuddyAPI.Models;
using QuranBuddyAPI.Entities;
using AutoMapper;

namespace QuranBuddyAPI.Controllers
{
    [Route("api/chapters")]
    [ApiController]
    public class ChapterController : Controller
    {
        private readonly IChapterService _chapterService;
        private readonly IMapper _mapper;


        public ChapterController(IChapterService chapterService, IMapper mapper)
        {
            _chapterService = chapterService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetChapters()
        {
            var chapters = await _chapterService.GetAllChaptersAsync();

            var chapterDtos = _mapper.Map<ICollection<ChapterDto>>(chapters);

            return Ok(chapterDtos);
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

            var chapterDto = _mapper.Map<ICollection<ChapterDto>>(chapter);

            return Ok(chapterDto);

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

            var chapterDtos = _mapper.Map<ICollection<ChapterDto>>(chapters);

            return Ok(chapterDtos);

        }
    }
}
