using NUnit.Framework;
using Moq;
using SearchEngine.Core;
using SearchEngine.Services.SearchKeywords;
using System;


namespace SearchEngineTest
{
    [TestFixture]
    public class YahooSearchTests
    {
        [Test]
        public void YahooSearchSuccesfull()
        {
            var moqSearchInput = new Mock<SearchInput>();
            var gss = new YahooSearchStrategey();
            Assert.Throws<NotImplementedException>(() => gss.GetSearchResults(moqSearchInput.Object));
            
        }
    }
}

