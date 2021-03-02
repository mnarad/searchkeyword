using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine.Core
{
    public class SearchInput
    {
        public string Keyword { get; set; }

        public string SearchURL { get; set; }
        public SearchEngineType SearchEngineType { get; set; }
    }
}
