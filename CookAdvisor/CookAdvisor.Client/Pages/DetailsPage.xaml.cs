namespace CookAdvisor.Client.Pages
{
    using ViewModels;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    public sealed partial class DetailsPage : Page
    {
        public DetailsPage()
        {
            this.InitializeComponent();
            this.ViewModel = new DetailsPageViewModel();
        }

        public DetailsPageViewModel ViewModel
        {
            get { return this.DataContext as DetailsPageViewModel; }
            set { this.DataContext = value; }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var recipeId = (int)e.Parameter;

            this.ViewModel.GetRecipe(recipeId);
        }
    }
}
