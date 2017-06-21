using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

using ApiFetcher.Dtos;
using ApiFetcher.Interfaces;
using System.Net;
using System;
using System.Diagnostics;

namespace ApiFetcher.Services
{
    public class DataService : IDataService
    {
        public Result<IEnumerable<ArticleDto>> GetLatestArticles() => GetResponse<ArticlesResponseDto, ArticleDto>(Constants.DR_LATEST_URL);
        
        public Result<IEnumerable<SiteDto>> GetAllSites() => GetResponse<SitesResponseDto, SiteDto>(Constants.DR_SITES_URL);

        private Result<IEnumerable<S>> GetResponse<TResponse, S>(string url) where TResponse : IWebResponse<S>
        {
            WebClient client;

            string rawResponse;

            try
            {
                client = WebClientFactory.Create();
                rawResponse = client.DownloadString(url);
            }
            catch (WebException)
            {
                return Result<IEnumerable<S>>.Fail("Network Failure");
            }

            TResponse response = JsonConvert.DeserializeObject<TResponse>(rawResponse);

            return Result<IEnumerable<S>>.Ok(response.Data.ToList());
        }
    }
}
