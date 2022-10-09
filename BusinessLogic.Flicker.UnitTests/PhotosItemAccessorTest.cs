using BusinessLogic.Flicker.Controller;
using Foundation.Core.Interfaces;
using Foundation.Core.Models;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Flicker.UnitTests
{
    [TestFixture]
    public class PhotosItemAccessorTest
    {
        private IUnityContainer _container;
        private Mock<IFeedItemAccessor> _mockFeedItemAccessor;
        [SetUp]
        public void Setup()
        {
            _container = new UnityContainer();
            //--- Need to create test class , not use actual implementation------------//
            //_container.RegisterType<IAPIService, APIInteractor>();
            //_container.RegisterType<IQueryBuilder, APIQueryBuilder>();
            //_container.RegisterType<IQueryManager, APIQueryManager>();
            //_container.RegisterType<IInMemoryCache, InMemoryCache>();
            _mockFeedItemAccessor = new Mock<IFeedItemAccessor>();
            _container.RegisterInstance(_mockFeedItemAccessor, new ContainerControlledLifetimeManager());
        }
        [Test]
        public async System.Threading.Tasks.Task Test_GetFeedsItemAsync_Returns_IEnumerableOfFeedItemsAsync()
        {
            var photoItemsAccessor = new PhotosItemAccessor(_container);
            var searchParameter = new SearchParameters() { SearchTag = "" };
            var feedModelProvider = _container.Resolve<PhotosItemAccessor>();
            var initialListOfFeedItems = new List<FeedItem>() { new FeedItem { Url = "flickr", Title = "test1" },
                                                                           new FeedItem { Title = "test1", Url = "flickr" } };
            _mockFeedItemAccessor.Setup(x => x.GetFeedItemsAsync(searchParameter)).ReturnsAsync(initialListOfFeedItems);

            var actualListOfFeedItems = await photoItemsAccessor.GetFeedItemsAsync(searchParameter);

            var initalCount = initialListOfFeedItems.Count;
            var actualCount = actualListOfFeedItems.ToList().Count();

            var actualModelInList = actualListOfFeedItems.ToList();

            Assert.AreEqual(initalCount, actualCount);

            for (int i = 0; i < actualCount; i++)
            {
                Assert.AreEqual(initialListOfFeedItems[i].Url, actualModelInList[i].Url);
                Assert.AreEqual(initialListOfFeedItems[i].Title, actualModelInList[i].Title);
            }
        }
    }

}
