using System;
using System.Collections.Generic;

using ApiFetcher.Interfaces;
using ApiFetcher.Services;
using System.Threading;
using System.Threading.Tasks;

namespace ApiFetcher
{

    public class ClientApp
    {
        private IApplicationService _service;
        
        public ClientApp() : this(new ApplicationService()) { }

        public ClientApp(IApplicationService applicationService)
        {
            this._service = applicationService;
        }

        public void Run()
        {
            var articles = _service.GetLatestArticleTitles();

            OutputResult(articles, "Top Ten Recent Articles:");

            var frontpageSites = _service.GetSitesByEditorial("forside@dr.dk");

            OutputResult(frontpageSites, "FrontPage Edit Sites:");
        }

        private void OutputResult(IEnumerable<string> items, string heading)
        {
            Console.WriteLine($"{heading}{Environment.NewLine}");

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }
    }
}   