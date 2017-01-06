using HelloCDUT.Models;
using System;
using System.Collections.Generic;
using Windows.Web.Http;
using System.Threading.Tasks;
using HelloCDUT.RSAEncrypt;
using HelloCDUT.Models.Input;

namespace HelloCDUT.Services
{
    public class ApiService : ApiBaseService , IHelloCDUTService
    {
        private const string API_URL = "http://www.hellocdut.com/api/release/index.php";

        public async void UserRegister(string userName, string userPassword, string userDeviceCode)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("action", "registerUser");
            dic.Add("user_name", RSAEncryptHelper.PublicEncrypt(userName));
            dic.Add("user_password", RSAEncryptHelper.PublicEncrypt(userPassword));
            User response = await PostDictionary<User>(dic);
        }

        public async Task SignInAsync(SignInInput accountPassword)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("action", "userLogin");
            dic.Add("user_name", RSAEncryptHelper.PublicEncrypt(accountPassword.Account));
            dic.Add("user_password", RSAEncryptHelper.PublicEncrypt(accountPassword.Password));
            User user = await PostDictionary<User>(dic);
            AppEnvironment.Instance.CurrentUser = user;
        }

        public Task RestoreSignInStatusAsync()
        {
            throw new NotImplementedException();
        }

        public Task SignOutAsync()
        {
            throw new NotImplementedException();
        }

        public Task UploadAvatar()
        {
            throw new NotImplementedException();
        }

        //public Task<Config> GetConfig()
        //{
        //    return new DefaultConfig();
        //}
    }
}