using System.Collections.Generic;

namespace ApiFetcher
{
    interface IDataService
    {
        IEnumerable<string> GetLatestArticles();

        IEnumerable<string> GetSitesByEditorial(string editorial);
    }
}
