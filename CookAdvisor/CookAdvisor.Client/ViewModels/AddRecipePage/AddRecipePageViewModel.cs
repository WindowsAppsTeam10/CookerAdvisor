namespace CookAdvisor.Client.ViewModels
{
    using CookAdvisor.Client.ViewModels.Contracts;
    using Data.Models.Recipes;
    using Helpers;
    using Managers;
    using Models;
    using System.Collections.Generic;
    using System.Windows.Input;

    public class AddRecipePageViewModel : IPageViewModel
    {
        private ICommand saveCommand;
        private IData data;

        public AddRecipePageViewModel()
            : this(new HttpServerData())
        {

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
                    this.saveCommand = new DelegateCommand<AddRecipeViewModel>((newRecipe) =>
                    {
                        var recipeToAdd = new RecipeRequestModel
                        {
                            Country = null,
                            Creator = null,
                            Description = newRecipe.Description,
                            ImageUrl = newRecipe.ImageUrl,
                            Name = newRecipe.Name,
                            Products = new List<string>(newRecipe.Products)
                        };

                        this.data.AddRecipe(recipeToAdd);
                    });
                }
                return this.saveCommand;
            }
        }
    }
}
