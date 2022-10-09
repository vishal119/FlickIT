using APIServices.Flicker.Interfaces;
using APIServices.Twitter.Interfaces;
using BootStrapper.ApplicationUI.ViewModel;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using System.Reflection;
using System.Windows;

namespace BootStrapper.FlickerConsole.OnStart
{
    public class BootStrap
    {
        private IUnityContainer _container;

        public void Initialize()
        {
            _container = CreateContainer();
            SetupAPIRequiredParameters();
            InitializeMainWindowView();
        }

        /// <summary>
        /// Sets up the Service accessor with the API Key
        /// </summary>
        private void SetupAPIRequiredParameters()
        {
            var serviceAccess = _container.Resolve<IFlickrAPIService>();
            var twitterAccess = _container.Resolve<ITwitterAPIServices>();
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            string apiKey = configuration.AppSettings.Settings["APIKey"].Value;
            var consumerKey = configuration.AppSettings.Settings["ConsumerKey"].Value;
            var consumerSecretToken = configuration.AppSettings.Settings["ConsumerSecretToken"].Value;
            serviceAccess.SetApiKey(apiKey);
            twitterAccess.SetApiKey(consumerKey, consumerSecretToken);
        }

        /// <summary>
        /// Loads the configuration from the Unity file
        /// </summary>
        /// <param name="container"></param>
        private void LoadConfiguration(IUnityContainer container)
        {
            var configuration =
                ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            var unityConfigurationSection = (UnityConfigurationSection)configuration.GetSection("unity");
            container.LoadConfiguration(unityConfigurationSection);
        }

        /// <summary>
        /// Creates unity container
        /// </summary>
        /// <returns><<see cref="UnityContainer"/>></returns>
        protected IUnityContainer CreateContainer()
        {
            var container = new UnityContainer();
            LoadConfiguration(container);
            return container;
        }

        /// <summary>
        /// Initializes the Application main window
        /// </summary>
        protected void InitializeMainWindowView()
        {
            Application.Current.MainWindow = _container.Resolve<Window>();
            Application.Current.MainWindow.DataContext = _container.Resolve<ApplicationViewModel>();
            Application.Current.MainWindow?.Show();
        }
    }
}
