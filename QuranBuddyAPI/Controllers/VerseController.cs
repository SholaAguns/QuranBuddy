using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuranBuddyAPI.Entities;
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
        private readonly IMapper _mapper;


        public VerseController(IVerseService verseService, IMapper mapper)
        {
            _verseService = verseService;
            _mapper = mapper;
        }

        [HttpGet("by-chapter-id/{id}", Name = "GetVersesByChapterId")]
        public async Task<IActionResult> GetVersesChapterById(int id)
        {

            var chapterViewModel = new ChapterIdViewModel { Id = id };

            if (!TryValidateModel(chapterViewModel))
            {
                return BadRequest(ModelState);
            }

            var verses = await _verseService.GetVersesByChapterIdAsync(id);

            if (verses == null)
            {
                return NoContent();
            }

            var verseDtos = _mapper.Map<ICollection<VerseDto>>(verses);

            return Ok(verseDtos);

        }

        [HttpGet("by-id/{id}", Name = "GetVerseById")]
        public async Task<IActionResult> GetVerseById(int id)
        {


            var verse = await _verseService.GetVerseByIdAsync(id);

            if (verse == null)
            {
                return NoContent();
            }

            var verseDto = _mapper.Map<VerseDto>(verse);

            return Ok(verseDto);

        }

        [HttpGet("by-chapter-name/{name}", Name = "GetVersesByChapterName")]
        public async Task<IActionResult> GetVersesByChapterName(string name)
        {
            var chapterViewModel = new ChapterNameViewModel { Name = name };

            if (!TryValidateModel(chapterViewModel))
            {
                return BadRequest(ModelState);
            }

            var verses = await _verseService.GetVersesByChapterNameAsync(name);

            if (verses == null)
            {
                return NoContent();
            }


            var verseDtos = _mapper.Map<ICollection<VerseDto>>(verses);

            return Ok(verseDtos);

        }
    }
}
