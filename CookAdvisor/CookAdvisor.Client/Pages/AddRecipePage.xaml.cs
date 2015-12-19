namespace CookAdvisor.Client.Views
{
    using CookAdvisor.Client.ViewModels;
    using Windows.UI.Xaml.Controls;

    public sealed partial class AddRecipePage : Page
    {
        public AddRecipePage()
        {
            this.InitializeComponent();
            this.ViewModel = new AddRecipePageViewModel();
        }

        public AddRecipePageViewModel ViewModel
        {
            get { return this.DataContext as AddRecipePageViewModel; }
            set { this.DataContext = value; }
        }
    }
}
