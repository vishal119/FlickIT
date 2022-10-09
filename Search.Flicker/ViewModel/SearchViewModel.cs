using System;
using System.Windows.Input;
using Microsoft.Practices.Unity;
using Util.Common;
using Foundation.Core.Interfaces;
using Foundation.Core.Models;
using System.ComponentModel;

namespace Search.Flicker.ViewModel
{
    public class SearchViewModel : NotifyPropertyChanged
    {

        #region Public Members
        public SearchParameters SearchParameters
        {
            get { return _searchParameters; }
            set { SetField(ref _searchParameters, value); }
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetField(ref _isEnabled, value);
        }

        public bool IsError
        {
            get => _isError;
            set => SetField(ref _isError, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetField(ref _errorMessage, value);
        }
        #endregion
        /// <summary>
        /// ICommand to search
        /// </summary>
        public ICommand SearchCommand { get; set; }

        #region Constructors
        public SearchViewModel(IUnityContainer container)
        {
            _searchController = container.Resolve<ISearchController>();
            _modelProvider = container.Resolve<IModelProvider<SearchParameters>>();
            SearchParameters = _modelProvider.GetInitialModel();
            SearchCommand = new Command(OnSearchCommand);
            SearchParameters.PropertyChanged += SearchParameters_PropertyChanged;
            IsError = false;
            IsEnabled = false;
        }

        /// <summary>
        /// To enable or disable search text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchParameters_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SearchTag")
            {
                if (SearchParameters.SearchTag.Length > 0)
                {
                    IsEnabled = true;
                }
                else
                {
                    IsEnabled = false;
                }
            }
        }


        #endregion


        /// <summary>
        /// Search the entered text
        /// </summary>
        /// <param name="obj"></param>
        public async void OnSearchCommand(object obj)
        {
            try
            {
                IsError = false;
                await _searchController.Search();
            }
            catch (Exception e)
            {
                IsError = true;
                ErrorMessage = $"ERROR: Unable to fetch images, make sure you are entering valid text!!";
                Console.WriteLine(e);
            }
        }

        #region Private members
        private bool _isError;
        private string _errorMessage;
        private ISearchController _searchController;
        private IModelProvider<SearchParameters> _modelProvider;
        private SearchParameters _searchParameters;
        private  bool _isEnabled;
        #endregion
    }
}
