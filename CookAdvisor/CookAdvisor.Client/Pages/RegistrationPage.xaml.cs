namespace CookAdvisor.Client.Pages
{
    using CookAdvisor.Client.ViewModels;
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
            if (email == null)
            {
                //
            }

            var password = this.passwordField.UserInput;
            if(password == null)
            {
                //
            }

            var confirmPassword = this.confirmPasswordField.UserInput;
            if(confirmPassword == null)
            {
                //
            }

            // add email validation regex
            if (password != confirmPassword)
            {
                // Show error
                return;
            }

            var result = await this.ViewModel.RegisterUserSuccessful(email, password);
            if (result)
            {
                this.Frame.Navigate(typeof(LoginPage));
            }
            else
            {
                // error
            }
        }
    }
}
