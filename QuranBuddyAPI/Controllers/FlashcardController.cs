using AutoMapper;
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
        private readonly IMapper _mapper;


        public FlashcardController(IServiceFactory serviceFactory, IMapper mapper)
        {
            _serviceFactory = serviceFactory;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> GetFlashcard(FlashcardRequest flashcardRequest)
        {
            var flashcardService = _serviceFactory.GetFlashcardService(flashcardRequest.Type);

            

            var flashcardSet = await flashcardService.GetFlashcardSetAsync(flashcardRequest.Amount);

            var flashcardSetDto = _mapper.Map<FlashcardSetDto>(flashcardSet);

            return Ok(flashcardSetDto);
        }

        [HttpPost("by-range")]
        public async Task<IActionResult> GetFlashcardByRange(FlashcardRequestByRange flashcardRequest)
        {
            var flashcardService = _serviceFactory.GetFlashcardService(flashcardRequest.Type);

           

            var flashcardSet = await flashcardService.GetFlashcardSetByRangeAsync(flashcardRequest.Amount, flashcardRequest.RangeStart, flashcardRequest.RangeEnd);

            var flashcardSetDto = _mapper.Map<FlashcardSetDto>(flashcardSet);

            return Ok(flashcardSetDto);
        }

        [HttpPost("by-ids")]
        public async Task<IActionResult> GetFlashcardByIds(FlashcardRequestByIds flashcardRequest)
        {
            var flashcardService = _serviceFactory.GetFlashcardService(flashcardRequest.Type);

            var flashcardSet = await flashcardService.GetFlashcardSetByIdsAsync(flashcardRequest.Amount, flashcardRequest.IdList);

            var flashcardSetDto = _mapper.Map<FlashcardSetDto>(flashcardSet);

            return Ok(flashcardSetDto);
        }

        [HttpPost("by-names")]
        public async Task<IActionResult> GetFlashcardByNames(FlashcardRequestByNames flashcardRequest)
        {
            var flashcardService = _serviceFactory.GetFlashcardService(flashcardRequest.Type);

            var flashcardSet = await flashcardService.GetFlashcardSetByNamesAsync(flashcardRequest.Amount, flashcardRequest.NameList);

            var flashcardSetDto = _mapper.Map<FlashcardSetDto>(flashcardSet);

            return Ok(flashcardSetDto);
        }

        [HttpPost("by-juz")]
        public async Task<IActionResult> GetFlashcardByJuz(FlashcardRequestByIds flashcardRequest)
        {
            var flashcardService = _serviceFactory.GetFlashcardService(flashcardRequest.Type);

            var flashcardSet = await flashcardService.GetFlashcardSetByJuzAsync(flashcardRequest.Amount, flashcardRequest.IdList);

            var flashcardSetDto = _mapper.Map<FlashcardSetDto>(flashcardSet);

            return Ok(flashcardSetDto);
        }
    }
}
