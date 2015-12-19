namespace CookAdvisor.Client
{
    using CookAdvisor.Client.ViewModels;
    using Pages;
    using Views;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
            this.ViewModel = new LoginPageViewModel();
        }

        public LoginPageViewModel ViewModel
        {
            get { return this.DataContext as LoginPageViewModel; }
            set { this.DataContext = value; }
        }

        private void LoginUser(object sender, RoutedEventArgs e)
        {
            var user = this.ViewModel.LoginModel;
            user.Email = "test@test.test";
            user.Password = "123123";
            Login(user.Email, user.Password);
        }

        private async void Login(string username, string password)
        {
            var canLogin = await this.ViewModel.LoginUserSuccessful(username, password);
            if (canLogin)
            {
                this.Frame.Navigate(typeof(RecipesView));
            }
            else
            {
                //error
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddRecipePage));
        }

        private void RedirectToRegistration(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RegistrationPage));
        }


    }
}
