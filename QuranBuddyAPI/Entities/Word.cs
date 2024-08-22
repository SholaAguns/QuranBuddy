namespace QuranBuddyAPI.Entities
{
    public class Word
    {

        public int Id { get; set; }

        public string TranslatedText { get; set; }

        public ICollection<Verse> Verses { get; set; }
    }
}
