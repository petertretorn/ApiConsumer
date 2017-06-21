using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApiFetcher.Services;
using System.Collections.Generic;
using ApiFetcher;
using System.Collections;

namespace Tests
{
    [TestClass]
    public class CacheTests
    {
        
        [TestMethod]
        public void Can_Fetch_Item_From_Cache()
        {
            var expected = new List<string> { "item1", "item2", "item3" };

            Cache.Update(Constants.ARTICLES_KEY, expected);

            var actual = Cache.Get<IEnumerable<string>>(Constants.ARTICLES_KEY);
            
            CollectionAssert.AreEquivalent((ICollection)expected, (ICollection)actual);
        }


        [TestMethod]
        public void Fetching_Unknown_Key_From_Cache_Does_Not_Crash()
        {
            var expected = default(IEnumerable<string>);

            var actual = Cache.Get<IEnumerable<string>>("some_unknown_key");

            CollectionAssert.AreEquivalent((ICollection)expected, (ICollection)actual);
        }
    }
}
