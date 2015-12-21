namespace CookAdvisor.Client.Views
{
    using Pages;
    using ViewModels;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;
    public sealed partial class RecipesView : Page
    {
        public RecipesView()
        {
            this.InitializeComponent();
            this.ViewModel = new RecipesPageViewModel();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddRecipePage));
        }

        private void RecipeDoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            var grid = sender as Grid;
            var recipeId = grid.Tag;
            this.Frame.Navigate(typeof(DetailsPage), recipeId);
        }

        private void RefreshEvent(object sender, RoutedEventArgs e)
        {
            this.ViewModel.Refresh();
        }
    }
}
