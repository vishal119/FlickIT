using BusinessLogic.Flicker.Controller;
using Foundation.Core.Models;
using Microsoft.Practices.Unity;
using NUnit.Framework;

namespace BusinessLogic.Flicker.UnitTests
{
    [TestFixture]
   public class FeedPopulatorTest
   {
        
        private IUnityContainer _container;
        [SetUp]
        public void Setup()
        {
            _container = new UnityContainer();
        }
        [Test]
        public void Test_GetInitialModel_Returns_TheInitialModelFromFeedPopulator()
        {
            var feedPopulator = _container.Resolve<FeedPopulator>();
            Assert.NotNull(feedPopulator);
            Assert.IsNotNull(feedPopulator.FeedModel.FeedItems);
        }

        [Test]
        public void Test_ClearFeed_Returns_EmptyFeedModel()
        {
            //Arrange
            var feedPopulator = new FeedPopulator();

            feedPopulator.FeedModel.FeedItems.Add(new FeedItem { ItemId = "Test1" });
            feedPopulator.FeedModel.FeedItems.Add(new FeedItem { ItemId = "Test2" });
            feedPopulator.FeedModel.FeedItems.Add(new FeedItem { ItemId = "Test3" });

            var actualModel = feedPopulator.FeedModel;

            Assert.IsNotNull(actualModel);
            Assert.AreEqual(3, actualModel.FeedItems.Count);

            //Act
            feedPopulator.ClearFeed();

            actualModel = feedPopulator.FeedModel;

            //Assert
            Assert.IsNotNull(actualModel);
            Assert.AreEqual(0, actualModel.FeedItems.Count);
        }
        [Test]
        public void Test_GetFeedModel_WhenModelIsChanged_Returns_TheUpdatedModel()
        {
            //Arrange
            var feedDtoPopulator = new FeedPopulator();

            feedDtoPopulator.FeedModel.FeedItems.Add(new FeedItem { ItemId = "Testing" });

            //Act
            var actualModel = feedDtoPopulator.GetFeedModel();

            //Assert
            Assert.IsNotNull(actualModel);
            Assert.AreEqual("Testing", actualModel.FeedItems[0].ItemId);
        }
    }
}
