namespace CookAdvisor.Client.ViewModels
{
    using Helpers;
    using System.Windows.Input;
    using Windows.Web.Http;

    public class LoginViewModel : BaseViewModel
    {
        private ICommand loginCommand;
        private HttpClient httpClient;

        public LoginViewModel()
        {
            this.httpClient = new HttpClient();
        }

        // TODO: Implement
        public ICommand LoginCommand { get; set; }
    }
}
