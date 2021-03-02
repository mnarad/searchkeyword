using NUnit.Framework;
using Moq;
using SearchEngine.Core;
using SearchEngine.Services.SearchKeywords;

namespace SearchEngineTest
{
    [TestFixture]
    public class GoogleSearchTests
    {
        [Test]
        public void GoogleSearchSuccesfull()
        {
            var moqSearchInput = new Mock<SearchInput>();
            var gss = new GoogleSearchStrategy();
            moqSearchInput.Object.Keyword = "e-Settlements";
            moqSearchInput.Object.SearchURL = "sympli.com.au";
            var response = gss.GetSearchResults(moqSearchInput.Object);
            Assert.IsNotEmpty(response);
        }

    }
}
