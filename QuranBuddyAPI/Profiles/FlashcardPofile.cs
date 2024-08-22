using AutoMapper;
using QuranBuddyAPI.Entities;
using QuranBuddyAPI.Models;

namespace QuranBuddyAPI.Profiles
{
    public class FlashcardPofile : Profile
    {
        public FlashcardPofile()
        {
            CreateMap<Flashcard, FlashcardDto>();
            CreateMap<FlashcardSet, FlashcardSetDto>();


        }
    }
}
