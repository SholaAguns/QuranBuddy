using AutoMapper;
using QuranBuddyAPI.Entities;
using QuranBuddyAPI.Models;

namespace QuranBuddyAPI.Profiles
{
    public class VerseProfile : Profile
    {
        public VerseProfile()
        {
            CreateMap<Verse, VerseDto>();


        }
    }
}
