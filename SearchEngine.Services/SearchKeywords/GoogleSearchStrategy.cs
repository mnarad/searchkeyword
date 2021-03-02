using System.Collections.Generic;
using SearchEngine.Services.Helper;
using SearchEngine.Core;
using SearchEngineService.Services.SearchKeywords;
using System.Configuration;

namespace SearchEngine.Services.SearchKeywords
{
    public class GoogleSearchStrategy : ISearchKeywordsStrategy
    {
        private const string searchstring = "searchStringInGoogleResponse";
        private string uri = "googleURL";
        Dictionary<int, string> searchResultURLDictionary = new Dictionary<int, string>();
        string resultString = "";
        public string GetSearchResults(SearchInput searchInput)
        {
            var counter = 0;
            IServiceHelper serviceHelper = new SearchEngineHelper();
            var searchResponse = serviceHelper.GetSearchResultsAsync(searchInput, ConfigurationManager.AppSettings.Get(uri));
            string searchResponseinString = searchResponse.Result;
            //searchResponse.ToString().Contains();
            var listofIndexes = serviceHelper.AllIndexesOf(searchResponseinString, ConfigurationManager.AppSettings.Get(searchstring));
            foreach (var position in listofIndexes)
            {
                searchResultURLDictionary.Add(counter, searchResponseinString.Substring(position + 14, (searchResponseinString.Substring(position + 14).IndexOf("/"))));
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
