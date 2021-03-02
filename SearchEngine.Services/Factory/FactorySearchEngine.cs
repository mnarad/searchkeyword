using SearchEngine.Core;
using SearchEngine.Services.SearchKeywords;
using SearchEngineService.Services.SearchKeywords;

namespace SearchEngine.Services.Factory
{
    public static class FactorySearchEngine
    {
        public static ISearchKeywordsStrategy CreateSearchEngine(SearchEngineType searchEngineType)
        {
            switch (searchEngineType)
            {
                case SearchEngineType.Bing:
                    return new BingSearchStrategy();
                case SearchEngineType.Google:
                    return new GoogleSearchStrategy();
                case SearchEngineType.Yahoo:
                    return new YahooSearchStrategey();
                default:
                    return new GoogleSearchStrategy();
            }
        }
    }
}
