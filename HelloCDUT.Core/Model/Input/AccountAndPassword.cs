using HelloCDUT.Core.Helper;
using HelloCDUT.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCDUT.Core.Model.Input
{
    public class AccountAndPassword :  VerifiableBase
    {
        private string _account;
        /// <summary>
        /// 账号
        /// 小写字母开头 数字和小写字母组成 6-15
        /// </summary>
        [Required(ErrorMessage = "账号不能为空")]
        [StringLength(15,MinimumLength = 6,ErrorMessage = "账号长度为6-15")]
        
        public string Account
        {
            get
            {
                return _account;
            }
            set
            {
                Set(ref _account, value);
            }
        }

        private string _password;
        [Required(ErrorMessage = "密码不能为空")]
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                Set(ref _password, value);
            }
        }
    }
}
