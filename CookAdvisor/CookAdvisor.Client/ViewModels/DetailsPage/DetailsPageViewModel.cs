namespace CookAdvisor.Client.ViewModels
{
    using Helpers;
    using Managers;

    public class DetailsPageViewModel : BaseViewModel
    {
        private IData contentManager;
        private DetailRecipeViewModel recipeToShow;

        public DetailsPageViewModel()
        {
            this.contentManager = new HttpServerData();
        }

        public DetailRecipeViewModel RecipeToShow
        {
            get
            {
                if (this.recipeToShow == null)
                {
                    this.recipeToShow = new DetailRecipeViewModel();
                }

                return this.recipeToShow;
            }
            set
            {
                if (this.recipeToShow == null)
                {
                    this.recipeToShow = new DetailRecipeViewModel();
                }

                this.recipeToShow = value;
                this.RaisePropertyChanged("RecipeToShow");
            }
        }

        public async void GetRecipe(int id)
        {
            var recipe = await this.contentManager.GetRecipe(id);

            var convertRecipe = new DetailRecipeViewModel
            {
                Creator = recipe.Creator,
                Description = recipe.Description,
                Image = recipe.ImageUrl,
                Name = recipe.Name,
                Country = recipe.Country
            };

            RecipeToShow = new DetailRecipeViewModel(convertRecipe);
            this.RaisePropertyChanged("RecipeToShow");
        }
    }
}
