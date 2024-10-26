using AutoMapper;
using QuranBuddyAPI.Entities;
using QuranBuddyAPI.Models;

namespace QuranBuddyAPI.Profiles
{
    public class PhraseProfile : Profile
    {
        public PhraseProfile()
        {
            CreateMap<Phrase, PhraseDto>();


        }
    }
}
