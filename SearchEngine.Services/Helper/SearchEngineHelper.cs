using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SearchEngine.Core;


namespace SearchEngine.Services.Helper
{
    public interface IServiceHelper
    {
        Task<string> GetSearchResultsAsync(SearchInput searchInput, string uri);

        List<int> AllIndexesOf(string str, string value);

    }
    public class SearchEngineHelper : IServiceHelper
    {
        public Task<string> GetSearchResultsAsync(SearchInput searchInput, string uri)
        {
            string completeuri = uri + searchInput.Keyword;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(completeuri);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader s = new StreamReader(resp.GetResponseStream(), Encoding.ASCII);
            string result = s.ReadToEnd();
            return Task.FromResult(result);
            //return result;
        }

        public List<int> AllIndexesOf(string str, string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("the string to find may not be empty", "value");
            List<int> indexes = new List<int>();
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }


    }
}
