using HelloCDUT.Core.Http;
using HelloCDUT.Core.Model;
using HelloCDUT.Core.Model.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCDUT.Core.ViewModel
{
    public class LoginPageViewModel : ViewModelBase
    {
        public AccountAndPassword AccountAndPassword { get; set; } 

        public LoginPageViewModel()
        {
            AccountAndPassword = new AccountAndPassword() { Account = "arcsinw", Password = "1234567" };
        }

        private ApiService _apiService = new ApiService();

        public async void Login()
        {
            LoginResponse response = await _apiService.UserLogin(AccountAndPassword.Account, AccountAndPassword.Password);
            if(response!=null)
            {
            }
        }
    }
}
