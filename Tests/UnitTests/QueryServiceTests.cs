using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApiFetcher.Services;
using ApiFetcher.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using ApiFetcher;

namespace Tests
{
    [TestClass]
    public class QueryServiceTests
    {
        [TestMethod]
        public void Can_Find_Ten_Most_Recent_Articles_By_Title()
        {
            //arrange
            var sut = new QueryService();
            var articles = GenerateArticles();

            //act
            var actual = sut.GetLatestArticleTitles(articles);

            var expected = articles
                .Select(a => a.Title)
                .Take(10)
                .ToList();

            //assert
            CollectionAssert.AreEquivalent((ICollection)expected, (ICollection)actual);
        }

        [TestMethod]
        public void Can_Find_Sites_By_Editorial()
        {
            //arrange
            var sut = new QueryService();

            var editorial = "forside@dr.dk";

            var sites = new List<SiteDto>
            {
                new SiteDto
                {
                    Title = "SiteTitle_1",
                    Site_info_collection = new SiteInfoCollectionDto() { Body = editorial }
                },
                new SiteDto
                {
                    Title = "SiteTitle_2",
                    Site_info_collection = new SiteInfoCollectionDto() { Body = "other" }
                },
                new SiteDto
                {
                    Title = "SiteTitle_3",
                    Site_info_collection = new SiteInfoCollectionDto() { Body = editorial }
                }
            };

            //act
            var actual = sut.GetSitesByEditorial(sites, editorial);

            //assert
            var expected = new List<string> { "SiteTitle_1", "SiteTitle_3" };

            CollectionAssert.AreEquivalent((ICollection)expected, (ICollection)actual);
        }

        [TestMethod]
        public void Can_Find_Sites_By_Editorial_When_Title_Is_Not_Present()
        {
            //arrange
            var sut = new QueryService();

            var editorial = "frontpage_edit";

            var sites = new List<SiteDto>
            {
                new SiteDto
                {
                    Name = "SiteTitle_1",
                    Site_info_collection = new SiteInfoCollectionDto() { Body = editorial }
                },
                new SiteDto
                {
                    Title = "SiteTitle_2",
                    Site_info_collection = new SiteInfoCollectionDto() { Body = "other" }
                },
                new SiteDto
                {
                    Site_info_collection = new SiteInfoCollectionDto() { Body = editorial }
                }
            };

            //act
            var actual = sut.GetSitesByEditorial(sites, editorial);

            //assert
            var expected = new List<string> { "SiteTitle_1", Constants.NO_DATA };

            CollectionAssert.AreEquivalent((ICollection)expected, (ICollection)actual);
        }



        private IEnumerable<ArticleDto> GenerateArticles()
        {
            var articles = new List<ArticleDto>();

            for (int i = 0; i < 25; i++)
            {
                articles.Add(new ArticleDto() { Title = $"Title_{i}" });
            }

            return articles;
        }
    }
}
