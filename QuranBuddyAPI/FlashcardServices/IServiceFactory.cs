namespace QuranBuddyAPI.FlashcardServices
{
    public interface IServiceFactory
    {
        IFlashcardService GetFlashcardService(string type);
    }
}
