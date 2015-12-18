namespace CookAdvisor.Client.ViewModels
{
    using CookAdvisor.Client.Models;
    using System.Collections.ObjectModel;
    public class RecipesPageViewModel
    {
        private ObservableCollection<RecipeListItemModel> recipeList;

        public ObservableCollection<RecipeListItemModel> RecipeList
        {
            get
            {
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

    }
}
