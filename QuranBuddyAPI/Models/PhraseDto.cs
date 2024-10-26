namespace QuranBuddyAPI.Models
{
    public class PhraseDto
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public int ChapterId { get; set; }

        public int JuzNumber { get; set; }

        public string? ImageUrl { get; set; }

        public string Translation { get; set; }
    }
}
