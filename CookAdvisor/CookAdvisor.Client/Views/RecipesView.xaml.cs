namespace CookAdvisor.Client.Views
{
    using ViewModels;
    using Windows.UI.Xaml;
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

        private void OnProductsFilterClick(object sender, RoutedEventArgs e)
        {
            //if (this.HiddenDropdown.Height.Value == 0)
            //{
            //    this.HiddenDropdown.Height = new GridLength(50);
            //}

            //this.HiddenDropdown.Height = new GridLength(this.HiddenDropdown.Height.Value + 50);
        }
    }
}
