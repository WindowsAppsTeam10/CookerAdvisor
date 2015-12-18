namespace CookAdvisor.Client.ViewModels
{
    using Common;
    using CookAdvisor.Client.Models;
    using Managers;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class RecipesPageViewModel
    {
        private ObservableCollection<RecipeListItemModel> recipeList;
        private IContentManager contentManager;

        public RecipesPageViewModel()
        {
            this.contentManager = new ContentManager(new RemoteDataManager(GlobalConstants.DefaultApiBaseAddress));
            this.Refresh();
        }

        public IEnumerable<RecipeListItemModel> RecipeList
        {
            get
            {
                if (this.recipeList == null)
                {
                    this.recipeList = new ObservableCollection<RecipeListItemModel>();
                }

                return this.recipeList;
            }
            set
            {
                if (this.recipeList == null)
                {
                    this.recipeList = new ObservableCollection<RecipeListItemModel>();
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
            this.RecipeList = await this.contentManager.GetRecipes(0, 10);
        }
    }
}
