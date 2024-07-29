using FluentAssertions;

namespace QuranBuddyAPI_Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            var testItem = true;

            testItem.Should().Be(true, "because it should be true");

        }
    }
}