using AutoMapper;
using QuranBuddyAPI.Entities;
using QuranBuddyAPI.Models;

namespace QuranBuddyAPI.Profiles
{
    public class ChapterProfile : Profile
    {
        public ChapterProfile()
        {
            CreateMap<Chapter, ChapterDto>();


        }
    
        
    }
}
