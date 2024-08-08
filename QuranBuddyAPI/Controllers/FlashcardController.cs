using Microsoft.AspNetCore.Mvc;
using QuranBuddyAPI.FlashcardServices;
using QuranBuddyAPI.Models;
using QuranBuddyAPI.Services;

namespace QuranBuddyAPI.Controllers
{
    [Route("api/flashcards")]
    [ApiController]
    public class FlashcardController : Controller
    {
        private readonly IServiceFactory _serviceFactory;


        public FlashcardController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }


        [HttpPost]
        public async Task<IActionResult> GetFlashcard(FlashcardRequest flashcardRequest)
        {
            var flashcardService = _serviceFactory.GetFlashcardService(flashcardRequest.Type);

            

            var flashcardSet = flashcardService.GetFlashcardSetAsync(flashcardRequest.Amount);

            return Ok(flashcardSet);
        }

        [HttpPost("by-range")]
        public async Task<IActionResult> GetFlashcardByRange(FlashcardRequestByRange flashcardRequest)
        {
            var flashcardService = _serviceFactory.GetFlashcardService(flashcardRequest.Type);

           

            var flashcardSet = flashcardService.GetFlashcardSetByRangeAsync(flashcardRequest.Amount, flashcardRequest.RangeStart, flashcardRequest.RangeEnd);

            return Ok(flashcardSet);
        }

        [HttpPost("by-ids")]
        public async Task<IActionResult> GetFlashcardByIds(FlashcardRequestByIds flashcardRequest)
        {
            var flashcardService = _serviceFactory.GetFlashcardService(flashcardRequest.Type);

            var flashcardSet = flashcardService.GetFlashcardSetByIdsAsync(flashcardRequest.Amount, flashcardRequest.IdList);

            return Ok(flashcardSet);
        }

        [HttpPost("by-names")]
        public async Task<IActionResult> GetFlashcardByNames(FlashcardRequestByNames flashcardRequest)
        {
            var flashcardService = _serviceFactory.GetFlashcardService(flashcardRequest.Type);

            var flashcardSet = flashcardService.GetFlashcardSetByNamesAsync(flashcardRequest.Amount, flashcardRequest.NameList);

            return Ok(flashcardSet);
        }
    }
}
