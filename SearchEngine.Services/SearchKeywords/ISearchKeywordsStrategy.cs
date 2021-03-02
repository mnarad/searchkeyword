using System.Collections.Generic;
using SearchEngine.Core;

namespace SearchEngineService.Services.SearchKeywords

{
    public interface ISearchKeywordsStrategy
    {
        string GetSearchResults(SearchInput keywords);
    }
}
