using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuranBuddyAPI.Models
{
    

    public class VerseDto
    {
        public int Id { get; set; }
        public int ChapterId { get; set; }
        public string ChapterName { get; set; }
        public string TextUthmani { get; set; }
        public string ImageUrl { get; set; }

        public int VerseNumber { get; set; }
        public string VerseKey { get; set; }

        public int JuzNumber { get; set; }
    }

    
}
