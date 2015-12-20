namespace CookAdvisor.Client
{
    using System;
    using CookAdvisor.Client.ViewModels;
    using Pages;
    using Views;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Notifications;
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
            user.Email = this.emailField.UserInput;
            user.Password = this.passwordField.UserInput;
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
            Notifier.ShowToast("SUCCESS!", "You clicked this button.");
            this.Frame.Navigate(typeof(AddRecipePage));
        }

        private void RedirectToRegistration(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RegistrationPage));
        }
    }
}
