using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace ApiFetcher
{
    public class DataService : IDataService
    {
        
        public IEnumerable<string> GetLatestArticles()
        {
            var client = WebClientFactory.Create();

            var response = client.DownloadString(Constants.DR_LATEST_URL);

            dynamic result = JsonConvert.DeserializeObject(response);

            var dataCollection = (IEnumerable<dynamic>)result.data;

            return dataCollection
                .Select(i => i.title)
                .Select(i => (string)i)
                .Take(10)
                .ToList();
        }

        public IEnumerable<string> GetSitesByEditorial(string editorial)
        {
            var client = WebClientFactory.Create();

            dynamic rawResponse = client.DownloadString(Constants.DR_SITES_URL);

            SitesResponseDto siteResponse = JsonConvert.DeserializeObject<SitesResponseDto>(rawResponse);

            var frontSites = siteResponse.Data
                .Where(s => s.Site_info_collection.Body.Equals(editorial, StringComparison.CurrentCultureIgnoreCase))
                .Select(GetTitleField);
            
            return frontSites.ToList();
        }

        private string GetTitleField(SiteDto dto)
        {
            var title = (!string.IsNullOrWhiteSpace(dto.Title)) 
                ? dto.Title 
                : (!string.IsNullOrWhiteSpace(dto.Name)) ? dto.Name : Constants.NO_DATA;

            return title;
        }
        
    }
}
