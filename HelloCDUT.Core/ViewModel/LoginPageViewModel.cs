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
        public AccountAndPassword AccountAndPassword { get; set; } = new AccountAndPassword() { Account = "arcsinw", Password = "1234567" };

        private ApiService _apiService = new ApiService();

        public void Login()
        {
            _apiService.UserLogin(AccountAndPassword.Account, AccountAndPassword.Password);

        } 
    }
}
