namespace QuranBuddyAPI.Models
{
    public class CreatePhraseRequest
    {
       public string Text { get; set; }

        public string ImageUrl { get; set; }

        public int ChapterId { get; set; }

        public int JuzNumber { get; set; }

        public string Translation { get; set; }

    }

    public class UpdatePhraseRequest
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public string ImageUrl { get; set; }

        public int ChapterId { get; set; }

        public int JuzNumber { get; set; }

        public string Translation { get; set; }
    }

    public class DeletePhraseRangeRequest
    {
        public Guid[] Ids { get; set; }
    }
}
