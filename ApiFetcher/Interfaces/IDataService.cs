using System.Collections.Generic;

using ApiFetcher.Dtos;

namespace ApiFetcher.Interfaces
{
    public interface IDataService
    {
        Result<IEnumerable<ArticleDto>> GetLatestArticles();

        Result<IEnumerable<SiteDto>> GetAllSites();
    }
}
