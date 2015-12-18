namespace CookAdvisor.Client.Views
{
    using Common;
    using Managers;
    using Managers.Contracts;
    using Models;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Net;
    using System.Threading.Tasks;
    using ViewModels;
    using Windows.UI.Xaml.Controls;

    public sealed partial class RecipesView : Page
    {
        private IRemoteDataManager remoteClient;
        private int skip = 0;
        private int take = 3;

        public RecipesView()
        {
            this.InitializeComponent();
            this.ViewModel = new RecipesPageViewModel();
            this.remoteClient = new RemoteDataManager(GlobalConstants.DefaultApiBaseAddress);
            this.ViewModel.RecipeList = new ObservableCollection<RecipeListItemModel>
            {
                new RecipeListItemModel
                {
                    Name = "1"
                },
                new RecipeListItemModel
                {
                    Name = "2"
                }
            };
            this.ViewModel.RecipeList.Add(new RecipeListItemModel
            {
                Name = "peshodfa"
            });
        }

        public RecipesPageViewModel ViewModel
        {
            get
            {
                return this.DataContext as RecipesPageViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        public async void GetRecipes()
        {
            var response = await this.remoteClient.Get(string.Format(GlobalConstants.GetRecipesFormatEndpoint, this.skip, this.take));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseItems = await response.Content.ReadAsStringAsync();
                var items = JsonConvert.DeserializeObject<ObservableCollection<RecipeListItemModel>>(responseItems);
                this.ViewModel.RecipeList = items;
            }
        }
    }
}
