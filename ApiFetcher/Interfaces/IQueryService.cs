using ApiFetcher.Dtos;
using System.Collections.Generic;

namespace ApiFetcher.Interfaces
{
    public interface IQueryService
    {
        IEnumerable<string> GetLatestArticleTitles(IEnumerable<ArticleDto> articles);

        IEnumerable<string> GetSitesByEditorial(IEnumerable<SiteDto> sites, string editorial);
    }
}