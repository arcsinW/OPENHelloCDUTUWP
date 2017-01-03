using HelloCDUT.Core.Http;
using HelloCDUT.Core.Model;
using HelloCDUT.Core.Model.Input;
using HelloCDUT.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCDUT.Core.ViewModels
{
    public class SignInViewModel : ViewModelBase
    {
        public AccountAndPassword AccountAndPassword { get; set; } 

        public SignInViewModel()
        {
            AccountAndPassword = new AccountAndPassword() { Account = "arcsinw", Password = "1234567" };
        }

        private ApiService _apiService = new ApiService();

        public async void SignIn()
        {
            User user = await _apiService.UserLogin(AccountAndPassword.Account, AccountAndPassword.Password);
            if(user!=null)
            {
                AppEnvironment.Instance.CurrentUser = user;
                
            }
        }

        /// <summary>
        /// Enables or disables the trigger to redirect
        /// to the main page after a successful sign-in.
        /// </summary>
        public bool RedirectToMainPage { get; set; } = true;
    }
}
