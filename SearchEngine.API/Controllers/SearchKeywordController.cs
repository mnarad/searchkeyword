using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using SearchEngine.API.Intefaces;
using SearchEngine.Core;

namespace SearchEngine.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchKeywordController : ControllerBase
    {

        private readonly ISearchEngineService _iSearchEngineService;
        private readonly ISearchKeywordHelper _iSearchKeywordHelper;
        //private readonly ILogger<SearchKeywordController> _logger;
        private readonly ILoggerManager _logger;

        public SearchKeywordController(ILoggerManager logger, ISearchEngineService iSearchEngineService, ISearchKeywordHelper iSearchKeywordHelper)
        {
            _logger = logger;
            _iSearchEngineService = iSearchEngineService;
            _iSearchKeywordHelper = iSearchKeywordHelper;
        }

        [HttpPost("")]

        public ActionResult<string> Search(SearchInput searchInput)
        {
            var response = _iSearchKeywordHelper.GetSearchResults(searchInput, _iSearchEngineService);
            _logger.LogDebug(response);
            return Ok(response);
        }

    }
}
