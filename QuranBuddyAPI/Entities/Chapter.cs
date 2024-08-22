using Newtonsoft.Json;
using QuranBuddyAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace QuranBuddyAPI.Entities
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
        public bool BismillahPre { get; set; }

        [JsonProperty("verses_count")]
        public int VersesCount { get; set; }

        [JsonProperty("revelation_place")]
        public string RevelationPlace { get; set; }

        public Chapter()
        {
            Verses = new HashSet<Verse>();
        }

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
}
