namespace CookAdvisor.Client.Pages
{
    using CookAdvisor.Client.ViewModels;
    using Notifications;
    using System.Text.RegularExpressions;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            this.InitializeComponent();
            this.ViewModel = new RegisterPageViewModel();
        }

        public RegisterPageViewModel ViewModel
        {
            get { return this.DataContext as RegisterPageViewModel; }
            set { this.DataContext = value; }
        }

        private async void RegisterUser(object sender, RoutedEventArgs e)
        {
            // check for null
            var email = this.emailField.UserInput;
            if (email == string.Empty)
            {
                Notifier.ShowToast("ERROR!", "We need your email!");
                return;
            }

            var password = this.passwordField.UserInput;
            if(password == string.Empty)
            {
                Notifier.ShowToast("ERROR!", "We need your password!");
                return;
            }

            var confirmPassword = this.confirmPasswordField.UserInput;
            if(confirmPassword == string.Empty)
            {
                Notifier.ShowToast("ERROR!", "Please confirm that pass!");
                return;
            }

            if (!Regex.Match(email, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$").Success)
            {
                Notifier.ShowToast("ERROR!", "This ain't no email.");
                return;
            }
            // add email validation regex
            if (password != confirmPassword)
            {
                Notifier.ShowToast("ERROR!", "Passwords don't match.");
                return;
            }

            var result = await this.ViewModel.RegisterUserSuccessful(email, password);
            if (result)
            {
                Notifier.ShowToast("SUCCESS!", "You just became a cook!");
                this.Frame.Navigate(typeof(LoginPage));
            }
            else
            {
                Notifier.ShowToast("ERROR!", "Registration failed :(");
                return;
            }
        }
    }
}
