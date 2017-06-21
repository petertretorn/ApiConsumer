using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiFetcher.Services
{
    public static class Cache
    {
        private static Dictionary<string, object> _cache = new Dictionary<string, object>();

        static Cache()
        {
            WarmUp();
        }

        private static void WarmUp()
        {
            var articles = new List<string>
            {
                "Luftangreb dræber IS-talsmand i Afghanistan",
                "WEBDOK Jernmanden og den døde nyre",
                "Flyvende læger rykker ud til flere",
                "'May er blevet symbolet på de rige, som ikke bekymrer sig om de fattige'",
                "Optimismen bider sig fast",
                "Dansk golfkomet fortsætter gode takter i USA",
                "Dansk computerhold vinder 1,7 millioner",
                "BAGGRUND Er flygtninge en terrortrussel?",
                "VIDEO Vrede amerikanere i protest mod frifindelse af betjent",
                "S og DF klar til forhandlinger om senere selvpensionering"
            };

            Cache.Update(Constants.ARTICLES_KEY, articles);

            var key = $"{Constants.EDITORIAL_SITES_KEY}_forside@dr.dk";

            Cache.Update(key, new List<string> { "Politik", "Valg2015", "Analyser", "Live", "Valg 2017" });
        }

        public static T Get<T>(string key) where T : class
        {
            if (!_cache.ContainsKey(key))
            {
                return default(T);
            }

            var item = _cache[key] as T;

            return item ?? default(T);
        }

        public static void Update(string key, object value)
        {
            if (!_cache.ContainsKey(key))
            {
                _cache.Add(key, value);
            }
            else
            {
                _cache[key] = value;
            }
        }
    }


}
