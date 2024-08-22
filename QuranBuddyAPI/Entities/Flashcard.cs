namespace QuranBuddyAPI.Entities
{
    public class Flashcard
    {
        public Guid Id { get; set; }

        public Guid FlashcardSetId { get; set; }

        public virtual FlashcardSet FlashcardSet { get; set; }
        public string Question { get; set; }

        public string Answer { get; set; }

        public string ImageUrl { get; set; }
    }

    public class FlashcardSet
    {
        public Guid Id { get; set; }

        public string Type { get; set; }

        public string? Name { get; set; }


        public virtual List<Flashcard>? Flashcards { get; set; }

        public int FlashcardAmount { get; set; }

        public List<string> UserAnswers { get; set; } = new List<string>();

        public List<bool> Report { get; set; } = new List<bool>();

    }
}
