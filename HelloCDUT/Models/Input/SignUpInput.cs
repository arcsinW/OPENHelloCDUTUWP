using HelloCDUT.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCDUT.Models.Input
{
    public class SignUpInput : VerifiableBase
    {
        private string _account;
        [Required]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "账号长度为6-15")]
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
        [Required]
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

        private string _passwordAgain;
        [Compare("Password", ErrorMessage = "两次输入的密码不一致")]
        public string PasswordAgain
        {
            get
            {
                return _passwordAgain;
            }
            set
            {
                Set(ref _passwordAgain, value);
            }
        }

        private bool _isAccept;
        
        //[MustTrue] 
        [Required]
        public bool IsAccept
        {
            get
            {
                return _isAccept;
            }
            set
            {
                Set(ref _isAccept, value);
            }
        }
    }
}
