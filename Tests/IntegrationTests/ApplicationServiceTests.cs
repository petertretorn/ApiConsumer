using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApiFetcher.Services;
using System.Collections;
using ApiFetcher.Interfaces;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class ApplicationServiceTests
    {
        private IApplicationService _sut;

        [TestInitialize]
        public void SetUp()
        {
            _sut = new ApplicationService(new DataService(), new QueryService());
        }

        [TestMethod]
        public void Can_Get_Most_Recent_Article_Titles()
        {
            var actual = _sut.GetLatestArticleTitles();

            CollectionAssert.AllItemsAreNotNull((ICollection)actual);
        }

        [TestMethod]
        public void Can_Get_Sites_By_Editorial()
        {
            var actual = _sut.GetSitesByEditorial("forside@dr.dk");

            var expected = new List<string> { "Politik", "Valg2015", "Analyser", "Live", "Valg 2017" };

            CollectionAssert.AreEquivalent((ICollection)expected, (ICollection)actual);
        }
    }
}
