using Microsoft.AspNetCore.Mvc;
using QuranBuddyAPI.FlashcardServices;
using QuranBuddyAPI.Models;
using QuranBuddyAPI.Services;
using AutoMapper;
using QuranBuddyAPI.Entities;


namespace QuranBuddyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashcardSetController : ControllerBase
    {
        private readonly IFlashcardSetService _flashbackSetService;
        private readonly IMapper _mapper;


        public FlashcardSetController(IFlashcardSetService flashbackSetService, IMapper mapper)
        {
            _flashbackSetService = flashbackSetService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetFlashcardSets()
        {
            var flashcardSets = await _flashbackSetService.GetAllFlashcardSetsAsync();

            var flashcardSetDtos = _mapper.Map<ICollection<FlashcardSetDto>>(flashcardSets);

            return Ok(flashcardSetDtos);
        }

        [HttpGet("by-id/{id}")]
        public async Task<IActionResult> GetFlashcardSetById(Guid id)
        {
            var flashcardSet = await _flashbackSetService.GetFlashcardSetByIdAsync(id);


            if (flashcardSet == null) return NotFound();

            var flashcardSetDto = _mapper.Map<FlashcardSetDto>(flashcardSet);

            return Ok(flashcardSetDto);
        }

        [HttpGet("by-name/{name}")]
        public async Task<IActionResult> GetFlashcardSetByName(string name)
        {
            var flashcardSet = await _flashbackSetService.GetFlashcardSetByNameAsync(name);


            if (flashcardSet == null) return NotFound();

            var flashcardSetDto = _mapper.Map<FlashcardSetDto>(flashcardSet);

            return Ok(flashcardSetDto);
        }

        [HttpPut("update-name")]
        public async Task<IActionResult> UpdateFlashcardSetName(FlashcardSetUpdateNameRequest flashcardRequest)
        {
            var flashcardSet = await _flashbackSetService.GetFlashcardSetByIdAsync(flashcardRequest.Id);

            if (flashcardSet == null) return NotFound();

            await _flashbackSetService.UpdateFlashcardSetNameAsync(flashcardRequest);

            var flashcardSetDto = _mapper.Map<FlashcardSetDto>(flashcardSet);

            return Ok(flashcardSetDto);
        }

        [HttpPost("set-answers")]
        public async Task<IActionResult> SetFlashcardSetAnwsers(FlashcardSetAnswersRequest flashcardRequest)
        {
            var flashcardSet = await _flashbackSetService.GetFlashcardSetByIdAsync(flashcardRequest.Id);

            if (flashcardSet == null) return NotFound();

            await _flashbackSetService.SetFlashcardSetAnwsersAsync(flashcardRequest);

            var flashcardSetDto = _mapper.Map<FlashcardSetDto>(flashcardSet);

            return Ok(flashcardSetDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlashcardSet(Guid id)
        {
            var flashcardSet = await _flashbackSetService.GetFlashcardSetByIdAsync(id);


            if (flashcardSet == null) return NotFound();

            await _flashbackSetService.DeleteFlashcardSetAsync(id);

            return NoContent();
        }


        [HttpPost("delete-range")]
        public async Task<IActionResult> DeleteFlashcardSetRange(FlashcardSetDeleteRangeRequest flashcardRequest)
        {

            await _flashbackSetService.DeleteFlashcardSetRangeAsync(flashcardRequest.Ids);

            return NoContent();
        }





    }
}
