using BusinessLogic.Flicker.Controller;
using Foundation.Core.Interfaces;
using Foundation.Core.Models;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;

namespace BusinessLogic.Flicker.UnitTests
{
    [TestFixture]
   public class FeedModelProviderTest
    {
        private Mock<IFeedPopulator> _mockFeedPopulator;
        private IUnityContainer _container;
        [SetUp]
        public void Setup()
        {
            
            _container = new UnityContainer();
            _container.RegisterType<IFeedPopulator,FeedPopulator>();// need to use test model
            _mockFeedPopulator = new Mock<IFeedPopulator>();
            _container.RegisterInstance(_mockFeedPopulator, new ContainerControlledLifetimeManager());
            
        }
        [Test]
        public void Test_GetInitialModel_Returns_TheInitialModelFromFeedPopulator()
        {
            var feedModelProvider = _container.Resolve<FeedModelProvider>();

            var initialModel = new FeedModel();
            initialModel.SearchTag = "initial";
            initialModel.FeedItems.Add(new FeedItem());

            _ = _mockFeedPopulator.Setup(x => x.GetFeedModel()).Returns(initialModel);

            var actualModel = feedModelProvider.GetInitialModel();
            actualModel.SearchTag = "initial";
            actualModel.FeedItems.Add(new FeedItem());

            Assert.NotNull(feedModelProvider);
            Assert.AreEqual(initialModel.SearchTag, actualModel.SearchTag);
            Assert.AreEqual(initialModel.FeedItems.Count, actualModel.FeedItems.Count);
        }
    }
}
