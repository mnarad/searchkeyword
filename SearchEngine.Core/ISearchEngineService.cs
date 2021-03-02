using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Core
{
    public interface ISearchEngineService
    {
        string GetSearchResults(SearchInput searchInput);
    }
}
