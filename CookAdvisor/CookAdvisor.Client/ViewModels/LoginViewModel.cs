namespace CookAdvisor.Client.ViewModels
{
    using Helpers;
    using Managers;
    using Managers.Contracts;
    using Models;
    using System.Windows.Input;

    public class LoginViewModel : BaseViewModel, IPageViewModel
    {
        private ICommand loginCommand;
        private UserLoginModel userLoginModel;
        private IDataManager client;

        public LoginViewModel()
        {
            this.userLoginModel = new UserLoginModel();
            this.client = new RemoteDataManager("http://localhost:55247/");
        }

        // TODO: Implement
        public ICommand LoginCommand
        {
            get
            {
                if (this.loginCommand == null)
                {
                    this.loginCommand = new DelegateCommand<UserLoginModel>(async (user) =>
                    {
                        var userDataAsJson = await this.client.Post("api/token", user);

                    });
                }

                return this.loginCommand;
            }
        }
        
        public UserLoginModel LoginModel
        {
            get
            {
                return this.userLoginModel;
            }
            set
            {
                this.userLoginModel = value;
            }
        }
    }
}
