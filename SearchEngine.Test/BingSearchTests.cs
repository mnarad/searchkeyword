using NUnit.Framework;
using Moq;
using SearchEngine.Core;
using SearchEngineService.Services.SearchKeywords;

namespace SearchEngineTest
{
    [TestFixture]
    public class BingSearchTests
    {
        [Test]
        public void BingSearchSuccesful()
        {
            var moqSearchInput = new Mock<SearchInput>();
            var bss = new BingSearchStrategy();
            moqSearchInput.Object.Keyword = "e-settlements";
            moqSearchInput.Object.SearchURL = "microsoft.com";
            var response = bss.GetSearchResults(moqSearchInput.Object);
            Assert.IsNotEmpty(response);
        }
    }
}
