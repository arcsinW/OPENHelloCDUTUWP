using HelloCDUT.Core.Model;
using HelloCDUT.Core.RSAEncrypt;
using System;
using System.Collections.Generic;
using Windows.Web.Http;
using System.Threading.Tasks;

namespace HelloCDUT.Core.Http
{
    public class ApiService : ApiBaseService
    {
        private const string API_URL = "http://www.hellocdut.com/api/release/index.php";

        public async void UserRegister(string userName, string userPassword, string userDeviceCode)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("action", "registerUser");
            dic.Add("user_name", RSAEncryptHelper.PublicEncrypt(userName));
            dic.Add("user_password", RSAEncryptHelper.PublicEncrypt(userPassword));
            LoginResponse response = await PostDictionary<LoginResponse>(dic);
        } 

        public async Task<LoginResponse> UserLogin(string userName,string userPassword)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("action", "userLogin");
            dic.Add("user_name", RSAEncryptHelper.PublicEncrypt(userName));
            dic.Add("user_password", RSAEncryptHelper.PublicEncrypt(userPassword));
            return await PostDictionary<LoginResponse>(dic);
        }
    }
}