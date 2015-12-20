namespace CookAdvisor.Client.Views
{
    using ViewModels;
    using Windows.UI.Xaml.Controls;
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
    }
}
