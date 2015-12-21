namespace CookAdvisor.Client.ViewModels
{
    public class DetailRecipeViewModel
    {
        public DetailRecipeViewModel()
        {

        }

        public DetailRecipeViewModel(DetailRecipeViewModel convertRecipe)
        {
            this.Name = convertRecipe.Name;
            this.Image = convertRecipe.Image;
            this.Description = convertRecipe.Description;
            this.Creator = convertRecipe.Creator;
            this.Country = convertRecipe.Country;
        }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public string Creator { get; set; }

        public string Country { get; set; }
    }
}
