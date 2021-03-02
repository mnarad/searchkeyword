using SearchEngine.Core;

namespace SearchEngine.API.Intefaces
{
    public interface ISearchKeywordHelper
    {
        string GetSearchResults(SearchInput searchInput, ISearchEngineService _iSearchEngineService);
    }
}
