using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuranBuddyAPI.Models
{
    public class Verse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        public int ChapterId { get; set; }

        public virtual Chapter Chapter { get; set; }

        [JsonProperty("verse_number")]
        public int VerseNumber { get; set; }

        [JsonProperty("verse_key")]
        public string VerseKey { get; set; }

        [JsonProperty("hizb_number")]
        public int HizbNumber { get; set; }

        [JsonProperty("rub_el_hizb_number")]
        public int RubElHizbNumber { get; set; }

        [JsonProperty("ruku_number")]
        public int RukuNumber { get; set; }

        [JsonProperty("manzil_number")]
        public int ManzilNumber { get; set; }

        [JsonProperty("sajdah_number")]
        public int? SajdahNumber { get; set; }

        [JsonProperty("text_uthmani")]
        public string TextUthmani { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("page_number")]
        public int PageNumber { get; set; }

        [JsonProperty("juz_number")]
        public int JuzNumber { get; set; }

        [JsonProperty("translations")]
        public ICollection<Translation> Translations { get; set; }

        public Verse()
        {
            Translations = new HashSet<Translation>();
        }


    }

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

    public class VerseApiResponse
    {
        [JsonProperty("verses")]
        public List<Verse> Verses { get; set; }

        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }

    public class Translation
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("resource_id")]
        public int ResourceId { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class Pagination
    {
        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        [JsonProperty("current_page")]
        public int CurrentPage { get; set; }

        [JsonProperty("next_page")]
        public int? NextPage { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("total_records")]
        public int TotalRecords { get; set; }
    }
}
