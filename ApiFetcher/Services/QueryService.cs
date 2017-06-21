using System;
using System.Collections.Generic;
using System.Linq;

using ApiFetcher.Dtos;
using ApiFetcher.Interfaces;

namespace ApiFetcher.Services
{
    public class QueryService : IQueryService
    {
        public IEnumerable<string> GetLatestArticleTitles(IEnumerable<ArticleDto> articles) =>
            articles.Select(a => a.Title)
                .Take(10)
                .ToList();

        public IEnumerable<string> GetSitesByEditorial(IEnumerable<SiteDto> sites, string editorial) => 
            GetSitesByPredicate(sites, s => s.Site_info_collection.Body.Equals(editorial));

        private IEnumerable<string> GetSitesByPredicate(IEnumerable<SiteDto> sites, Func<SiteDto, bool> predicate) =>
            sites.Where(predicate)
                .Select(GetTitleField)
                .ToList();

        private string GetTitleField(SiteDto siteDto) => 
            (!string.IsNullOrWhiteSpace(siteDto.Title)) 
            ? siteDto.Title 
            : (!string.IsNullOrWhiteSpace(siteDto.Name)) ? siteDto.Name : Constants.NO_DATA;        
    }
}
