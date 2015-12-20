namespace CookAdvisor.Client.ViewModels
{
    using Helpers;
    using Managers;
    using Managers.Contracts;
    using System.Windows.Input;
    using System.Threading.Tasks;
    using Contracts;
    using LoginPage;

    public class LoginPageViewModel : BaseViewModel, IPageViewModel
    {
        private IData data;
        private ILocalDataManager localClient;
        private UserLoginViewModel userLoginModel;

        public LoginPageViewModel()
        {
            this.data = new HttpServerData();
            this.localClient = new LocalDataManager();
        }

        public async Task<bool> LoginUserSuccessful(string username, string password)
        {
            var userInfo = await this.data.LoginUser(username, password);
            if (userInfo == null)
            {
                return false;
            }

            await this.localClient.InsertUserAsync(userInfo);
            return true;
        }
        
        public UserLoginViewModel LoginModel
        {
            get
            {
                if (this.userLoginModel == null)
                {
                    this.userLoginModel = new UserLoginViewModel();
                }

                return this.userLoginModel;
            }
            set
            {
                this.userLoginModel = value;
            }
        }
    }
}
