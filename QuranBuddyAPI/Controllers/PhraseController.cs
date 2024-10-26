using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuranBuddyAPI.Entities;
using QuranBuddyAPI.Models;
using QuranBuddyAPI.Services;

namespace QuranBuddyAPI.Controllers
{
    [Route("api/phrase")]
    [ApiController]
    public class PhraseController : Controller
    {
        private readonly IPhraseService _phraseService;
        private readonly IMapper _mapper;


        public PhraseController(IPhraseService phraseService, IMapper mapper)
        {
            _phraseService = phraseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPhrases()
        {
            var phrases = await _phraseService.GetAllPhrasesAsync();

            var phrasesDtos = _mapper.Map<ICollection<PhraseDto>>(phrases);

            return Ok(phrasesDtos);
        }

        [HttpGet("by-id/{id}", Name = "GetPhraseById")]
        public async Task<IActionResult> GetPhrasesById(Guid id)
        {
            var phrase = await _phraseService.GetPhraseByIdAsync(id);

            if (phrase == null) return NotFound();

            var phraseDto = _mapper.Map<PhraseDto>(phrase);

            return Ok(phraseDto);

        }

        [HttpGet("by-juz/{juzNumber}", Name = "GetPhrasesByJuz")]
        public async Task<IActionResult> GetPhrasesByJuz(int juzNumber)
        {
            var phrases = await _phraseService.GetPhrasesByJuzAsync(juzNumber);

            var phrasesDtos = _mapper.Map<ICollection<PhraseDto>>(phrases);

            return Ok(phrasesDtos);

        }

        [HttpGet("by-chapter/{chapterId}", Name = "GetPhrasesByChapter")]
        public async Task<IActionResult> GetPhrasesByChapter(int chapterId)
        {
            var phrases = await _phraseService.GetPhrasesByChapterAsync(chapterId);

            var phrasesDtos = _mapper.Map<ICollection<PhraseDto>>(phrases);

            return Ok(phrasesDtos);

        }

        [HttpPut("update-phrase")]
        public async Task<IActionResult> UpdateFlashcardSetName(UpdatePhraseRequest updateRequest)
        {
            var phrase = await _phraseService.GetPhraseByIdAsync(updateRequest.Id);

            if (phrase == null) return NotFound();

            await _phraseService.UpdatePhraseAsync(updateRequest);

            var phraseDto = _mapper.Map<PhraseDto>(phrase);

            return Ok(phraseDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhrase(Guid id)
        {
            var phrase = await _phraseService.GetPhraseByIdAsync(id);


            if (phrase == null) return NotFound();

            await _phraseService.DeletePhraseAsync(id);

            return NoContent();
        }


        [HttpPost("delete-range")]
        public async Task<IActionResult> DeleteFlashcardSetRange(Guid[] ids)
        {

            await _phraseService.DeletePhraseRangeAsync(ids);

            return NoContent();
        }

        [HttpPost()]
        public async Task<IActionResult> CreatePhrase(CreatePhraseRequest createRequest)
        {
            var phrase = await _phraseService.CreatePhraseAsync(createRequest);

            var phraseDto = _mapper.Map<PhraseDto>(phrase);

            return Ok(phraseDto);
        }
    }
}
