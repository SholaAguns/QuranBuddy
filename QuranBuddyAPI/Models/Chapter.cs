﻿using Newtonsoft.Json;
using QuranBuddyAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace QuranBuddyAPI.Models
{
    public class Chapter
    {

        [JsonProperty("id")]
        [Key]
        public int Id { get; set; }

        public virtual ICollection<Verse> Verses { get; set; }

        [JsonProperty("name_complex")]
        public string Name { get; set; }

        [JsonProperty("name_arabic")] 
        public string NameArabic { get; set; }

        [JsonProperty("translated_name")]
        public TranslatedName TranslatedName { get; set; }

        [JsonProperty("bismillah_pre")] 
        public bool BismillahPre {  get; set; }

        [JsonProperty("verses_count")] 
        public int VersesCount { get; set; }

        [JsonProperty("revelation_place")] 
        public string RevelationPlace { get; set; }


        public Chapter()
        {
            Verses = new HashSet<Verse>();
        }

    }

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


    public class ChapterApiResponse
    {
        [JsonProperty("chapters")]
        public List<Chapter> Chapters { get; set; }
    }

    public class TranslatedName
    {
        [JsonProperty("language_name")]
        public string LanguageName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
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

