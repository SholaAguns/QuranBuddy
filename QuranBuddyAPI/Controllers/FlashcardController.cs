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

            Console.WriteLine("Service type: " +  flashcardService.GetType());

            var flashcardSet = flashcardService.GetFlashcardSetAsync(flashcardRequest.Amount);

            return Ok(flashcardSet);
        }
    }
}
