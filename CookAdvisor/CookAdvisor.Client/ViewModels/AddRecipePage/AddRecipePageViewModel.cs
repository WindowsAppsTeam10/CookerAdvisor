namespace CookAdvisor.Client.ViewModels
{
    using CookAdvisor.Client.ViewModels.Contracts;
    using Data.Models.Recipes;
    using Helpers;
    using Managers;
    using Managers.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Windows.Input;
    using Windows.Devices.Geolocation;
    public class AddRecipePageViewModel : IPageViewModel
    {
        private ICommand saveCommand;
        private AddRecipeViewModel newRecipe;
        private IData data;
        private ILocalDataManager localClient;

        public AddRecipePageViewModel()
            : this(new HttpServerData())
        {
            this.localClient = new LocalDataManager();
            this.NewRecipe = new AddRecipeViewModel();
        }
        
        public AddRecipePageViewModel(IData data)
        {
            this.data = data;
        }

        public AddRecipeViewModel NewRecipe { get; set; }

        public ICommand SaveCommand
        {
            get
            {
                if (this.saveCommand == null)
                {
                    this.saveCommand = new DelegateCommand<AddRecipeViewModel>(async (newRecipe) =>
                    {
                        var currentUser = await localClient.GetUserAsync();
                        var geolocator = new Geolocator();
                        var access = await Geolocator.RequestAccessAsync();
                        var geoposition = await geolocator.GetGeopositionAsync();

                        if (newRecipe.Description == null ||
                            newRecipe.ImageUrl == null ||
                            newRecipe.Name == null ||
                            newRecipe.ProductsAsString == string.Empty ||
                            string.IsNullOrWhiteSpace(newRecipe.ProductsAsString))
                        {
                            return;
                        }

                        var response = this.data.AddRecipe(new RecipeRequestModel()
                        {
                            Country = "Bulgaria",
                            CreatorEmail = currentUser.UserName,
                            Description = newRecipe.Description,
                            ImageUrl = newRecipe.ImageUrl,
                            Name = newRecipe.Name,
                            Products = new List<string>(newRecipe.ProductsAsString.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries))
                        });

                        if (response != null)
                        {

                        }
                    });
                }
                return this.saveCommand;
            }
        }


        //public async void GetLocation()
        //{
        //    foreach (var task in BackgroundTaskRegistration.AllTasks)
        //    {
        //        if (task.Value.Name == GlobalConstants.LocationBackgroundTaskName)
        //        {
        //            task.Value.Completed += new BackgroundTaskCompletedEventHandler(OnCompleted);
        //            break;
        //        }
        //    }
        //}
        
        //private void OnCompleted(IBackgroundTaskRegistration task, BackgroundTaskCompletedEventArgs args)
        //{
        //    //GetCountryName(args.CheckResult);
        //}

        //private string GetCountryName()
        //{
        //    return string.Empty;
        //}
    }
}
