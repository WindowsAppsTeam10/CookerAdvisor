namespace CookAdvisor.Client
{
    using Common;
    using CookAdvisor.Client.ViewModels;
    using Managers;
    using Managers.Contracts;
    using Models;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
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

    }
}
