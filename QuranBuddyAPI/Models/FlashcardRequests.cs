using System.ComponentModel.DataAnnotations;

namespace QuranBuddyAPI.Models
{
    public class FlashcardRequest
    {
        [Range(2, 50, ErrorMessage = "Amount must be between 5 and 50.")]
        public int Amount { get; set; }

        [AllowedValues("Quran", "Arabic", ErrorMessage = "Type must be one of the following values: Quran, Arabic.")]
        public string Type { get; set; }

    }

    public class FlashcardRequestByRange
    {
        [Range(2, 50, ErrorMessage = "Amount must be between 5 and 50.")]
        public int Amount { get; set; }

        [AllowedValues("Quran", "Arabic", ErrorMessage = "Type must be one of the following values: Quran, Arabic.")]
        public string Type { get; set; }

        [Range(1, 114, ErrorMessage = "Amount must be between 5 and 50.")]
        public int RangeStart { get; set; }

        [Range(1, 114, ErrorMessage = "Amount must be between 5 and 50.")]
        [AllowedRangeEndAttribute("RangeStart", ErrorMessage = "RangeEnd must be greater than or equal to RangeStart.")]
        public int RangeEnd { get; set; }
    }

    public class FlashcardRequestByIds
    {
        [Range(2, 50, ErrorMessage = "Amount must be between 5 and 50.")]
        public int Amount { get; set; }

        [AllowedValues("Quran", "Arabic", ErrorMessage = "Type must be one of the following values: Quran, Arabic.")]
        public string Type { get; set; }

        [AllowedIdsEndAttribute(1, 114, ErrorMessage = "Each ID must be between 1 and 114.")]
        public List<int> IdList { get; set; }
    }

    public class FlashcardRequestByNames
    {
        [Range(2, 50, ErrorMessage = "Amount must be between 5 and 50.")]
        public int Amount { get; set; }

        [AllowedValues("Quran", "Arabic", ErrorMessage = "Type must be one of the following values: Quran, Arabic.")]
        public string Type { get; set; }

        [AllowedNamesLengthEndAttribute(20, ErrorMessage = "Name length limit is 20 characters")]
        public List<string> NameList { get; set; }

    }

    public class FlashcardSetUpdateNameRequest
    {
        [StringLength(60, ErrorMessage = "Id length limit is 36 characters")]
        public Guid Id { get; set; }

        [StringLength(60, ErrorMessage = "Name length limit is 60 characters")]
        public string? Name { get; set; }
    }

    public class FlashcardSetAnswersRequest
    {
        [StringLength(60, ErrorMessage = "Id length limit is 36 characters")]
        public Guid Id { get; set; }

        [AllowedNamesLengthEndAttribute(30, ErrorMessage = "Name length limit is 30 characters")]
        public List<string> UserAnswers { get; set; }
    }
}
