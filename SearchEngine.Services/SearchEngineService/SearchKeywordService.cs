using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SearchEngine.Core;
using SearchEngine.Services.Factory;
using SearchEngineService.Services.SearchKeywords;

namespace SearchEngine.Services.SearchEngineService
{
    public class SearchKeywordService : ISearchEngineService
    {   
        public string GetSearchResults(SearchInput searchInput)
        {
            ISearchKeywordsStrategy searchKeywordsStrategy = FactorySearchEngine.CreateSearchEngine(searchInput.SearchEngineType);
            return searchKeywordsStrategy.GetSearchResults(searchInput);
        }
    }
}
