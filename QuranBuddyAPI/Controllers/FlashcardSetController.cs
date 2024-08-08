using Microsoft.AspNetCore.Mvc;
using QuranBuddyAPI.FlashcardServices;
using QuranBuddyAPI.Models;
using QuranBuddyAPI.Services;


namespace QuranBuddyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashcardSetController : ControllerBase
    {
        private readonly IFlashcardSetService _flashbackSetService;


        public FlashcardSetController(IFlashcardSetService flashbackSetService)
        {
            _flashbackSetService = flashbackSetService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFlashcardSets()
        {
            var flashcardSets = await _flashbackSetService.GetAllFlashcardSetsAsync();

            return Ok(flashcardSets);
        }

        [HttpGet("by-id/{id}")]
        public async Task<IActionResult> GetFlashcardSetById(Guid id)
        {
            var flashcardSet = await _flashbackSetService.GetFlashcardSetByIdAsync(id);


            if (flashcardSet == null) return NotFound();

            return Ok(flashcardSet);
        }

        [HttpGet("by-name/{name}")]
        public async Task<IActionResult> GetFlashcardSetByName(string name)
        {
            var flashcardSet = await _flashbackSetService.GetFlashcardSetByNameAsync(name);


            if (flashcardSet == null) return NotFound();

            return Ok(flashcardSet);
        }

        [HttpPut("{name}")]
        public async Task<IActionResult> UpdateFlashcardSetName(FlashcardSetUpdateNameRequest flashcardRequest)
        {
            var flashcardSet = await _flashbackSetService.GetFlashcardSetByIdAsync(flashcardRequest.Id);

            if (flashcardSet == null) return NotFound();

            await _flashbackSetService.UpdateFlashcardSetNameAsync(flashcardRequest);

            return Ok(flashcardSet);
        }






        public Task UpdateFlashcardSetNameAsync(FlashcardSetUpdateNameRequest flashcardRequest);

        public Task SetFlashcardSetAnwsersAsync(FlashcardSetAnswersRequest flashcardRequest);

    }
}
