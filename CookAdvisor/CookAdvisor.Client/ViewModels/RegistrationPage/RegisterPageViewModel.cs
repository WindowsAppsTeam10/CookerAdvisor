namespace CookAdvisor.Client.ViewModels
{
    using CookAdvisor.Client.Helpers;
    using Managers;
    using System.Threading.Tasks;
    using System.Windows.Input;
    public class RegisterPageViewModel : BaseViewModel
    {
        private ICommand saveCommand;
        private IData data;
        private RegisterFormViewModel userRegisterModel;

        public RegisterPageViewModel()
        {
            this.data = new HttpServerData();
        }
        
        public async Task<bool> RegisterUserSuccessful(string username, string password)
        {
            return await this.data.RegisterUser(username, password);
        }

        public RegisterFormViewModel RegisterFormVM
        {
            get
            {
                if (this.userRegisterModel == null)
                {
                    this.userRegisterModel = new RegisterFormViewModel();
                }

                return this.userRegisterModel;
            }
            set
            {
                this.userRegisterModel = value;
            }
        }
    }
}
