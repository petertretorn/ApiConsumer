using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiFetcher.Interfaces
{
    public interface IApplicationService
    {
        IEnumerable<string> GetLatestArticleTitles();

        IEnumerable<string> GetSitesByEditorial(string editorial);
    }
}
