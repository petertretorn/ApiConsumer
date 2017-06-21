using ApiFetcher.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiFetcher.Services
{
    public class ApplicationService : IApplicationService
    {
        private IDataService _dataService;
        private IQueryService _queryService;

        public ApplicationService() : this(new DataService(), new QueryService()) { }

        public ApplicationService(IDataService dataService, IQueryService queryService)
        {
            this._dataService = dataService;
            this._queryService = queryService;
        }

        public IEnumerable<string> GetLatestArticleTitles()
        {
            var result = _dataService.GetLatestArticles();

            IEnumerable<string> articlesTitles;

            if (result.IsSuccess)
            {
                articlesTitles = _queryService.GetLatestArticleTitles(result.Content);
                Cache.Update(Constants.ARTICLES_KEY, articlesTitles);
            }
            else
            {
                articlesTitles = Cache.Get<IEnumerable<string>>(Constants.ARTICLES_KEY);
            }

            return articlesTitles;
        }

        public IEnumerable<string> GetSitesByEditorial(string editorial)
        {
            var result = _dataService.GetAllSites();

            IEnumerable<string> editorialSites;

            var cacheKey = $"{Constants.EDITORIAL_SITES_KEY}_{editorial}";

            if (result.IsSuccess)
            {
                editorialSites = _queryService.GetSitesByEditorial(result.Content, editorial);
                Cache.Update(cacheKey, editorialSites);
            }
            else
            {
                editorialSites = Cache.Get<IEnumerable<string>>(cacheKey);
            }

            return editorialSites;
        }
    }
}
