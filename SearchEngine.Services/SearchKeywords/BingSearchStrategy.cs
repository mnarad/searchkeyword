using SearchEngine.Core;
using SearchEngine.Services.Helper;
using System.Collections.Generic;
using System.Configuration;

namespace SearchEngineService.Services.SearchKeywords
{
    public class BingSearchStrategy : ISearchKeywordsStrategy
    {
        private string uri = "bingURL";
        private const string searchstring = "searchStringInBingResponse";
        Dictionary<int, string> searchResultURLDictionary = new Dictionary<int, string>();
        string resultString = "";
        public string GetSearchResults(SearchInput searchInput)
        {
            var counter = 0;
            var searchStringValue = ConfigurationManager.AppSettings.Get(searchstring);
            IServiceHelper serviceHelper = new SearchEngineHelper();
            var searchResponse = serviceHelper.GetSearchResultsAsync(searchInput, ConfigurationManager.AppSettings.Get(uri));
            string searchResponseinString = searchResponse.Result;
            //searchResponse.ToString().Contains();
            var listofIndexes = serviceHelper.AllIndexesOf(searchResponseinString, searchStringValue);
            foreach (var position in listofIndexes)
            {
                searchResultURLDictionary.Add(counter, searchResponseinString.Substring(position + searchStringValue.Length, (searchResponseinString.Substring(position + searchStringValue.Length).IndexOf("/"))));
                counter++;
            }
            foreach (var item in searchResultURLDictionary)
            {
                if (item.Value.ToLower().Contains(searchInput.SearchURL.ToLower()))
                {
                    resultString = resultString + item.Key.ToString() + ",";
                }
            }
            if (resultString == "")
                return "0";
            return resultString.Substring(0, resultString.Length - 1);
        }
    }

}
