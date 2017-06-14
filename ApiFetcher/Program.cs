using System;
using System.Collections.Generic;

namespace ApiFetcher
{
    class Program
    {
        static void Main(string[] args)
        {
            new AppRunner().Run();

            Console.ReadLine();
        }

        public class AppRunner
        {
            IDataService _dataService;

            //poor mans DI
            public AppRunner() : this(new DataService()) { }
        
            public AppRunner(IDataService dataService)
            {
                this._dataService = dataService;
            }

            public void Run()
            { 
                var articles = _dataService.GetLatestArticles();
                OutputResult(articles, "Top Ten Recent Articles");

                var frontpageSites = _dataService.GetSitesByEditorial("forside@dr.dk");
                OutputResult(frontpageSites, "FrontPage Edit Sites");
            }

            private void OutputResult(IEnumerable<string> items, string heading)
            {
                Console.WriteLine($"{heading}{System.Environment.NewLine}");

                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine();
            }
        }
    }
    
}
