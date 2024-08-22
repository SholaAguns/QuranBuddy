using Newtonsoft.Json;
using QuranBuddyAPI.Models;
using System.ComponentModel.DataAnnotations;




namespace QuranBuddyAPI.Models
{
    
    public class ChapterDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NameArabic { get; set; }

        public string TranslatedName { get; set; }

        public string TranslatedLanguage { get; set; }

        public bool BismillahPre { get; set; }

        public int VersesCount { get; set; }

        public string RevelationPlace { get; set; }


    }


    public class ChapterIdViewModel
    {
        [Range(1, 114, ErrorMessage = "Chapter Id must be between 1 and 114")]
        [Required]
        public int Id { get; set; }

    }

    public class ChapterNameViewModel
    {
        [Length(1, 50, ErrorMessage = "Max name length is 50")]
        [Required]
        public string Name { get; set; }
    }
}

