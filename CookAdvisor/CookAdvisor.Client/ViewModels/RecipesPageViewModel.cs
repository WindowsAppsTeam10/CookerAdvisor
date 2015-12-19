﻿namespace CookAdvisor.Client.ViewModels
{
    using Common;
    using System.Linq;
    using Managers;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Contracts;
    public class RecipesPageViewModel : IPageViewModel
    {
        private ObservableCollection<RecipeViewModel> recipeList;
        private IData contentManager;

        public RecipesPageViewModel()
        {
            this.contentManager = new HttpServerData(new RemoteDataService(GlobalConstants.DefaultApiBaseAddress));
            this.Refresh();
        }

        public string SearchFilter { get; set; }

        public IEnumerable<RecipeViewModel> RecipeList
        {
            get
            {
                if (this.recipeList == null)
                {
                    this.recipeList = new ObservableCollection<RecipeViewModel>();
                }

                return this.recipeList;
            }
            set
            {
                if (this.recipeList == null)
                {
                    this.recipeList = new ObservableCollection<RecipeViewModel>();
                }

                this.recipeList.Clear();
                foreach (var recipe in value)
                {
                    this.recipeList.Add(recipe);
                }
            }
        }

        private async void Refresh()
        {
            var result = await this.contentManager.GetRecipes(0, 10);
            this.RecipeList = result.Select(m => new RecipeViewModel(m));
        }
    }
}
