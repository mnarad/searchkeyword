using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using SearchEngine.API.Intefaces;
using SearchEngine.Core;
using System;

namespace SearchEngine.API.Helpers
{
    public class SearchKeywordHelper : ISearchKeywordHelper
    {
        private readonly IMemoryCache _cache;

        public SearchKeywordHelper(IMemoryCache cache)
        {
            _cache = cache;
        }
        public string GetSearchResults(SearchInput searchInput, ISearchEngineService _iSearchEngineService)
        {
            string cachedOutputValue;
            if (!_cache.TryGetValue(searchInput.SearchEngineType, out cachedOutputValue))
            {
                string urlpositionsinresult = _iSearchEngineService.GetSearchResults(searchInput);
                _cache.Set(searchInput.SearchEngineType, urlpositionsinresult, DateTime.Now.AddHours(1));
                return urlpositionsinresult;
            }
            return cachedOutputValue;
        }
}
}
