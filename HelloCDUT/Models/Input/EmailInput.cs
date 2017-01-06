using HelloCDUT.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCDUT.Models.Input
{
    public class EmailInput : VerifiableBase
    {
        private string _email;
        [Required]
        [EmailAddress(ErrorMessage = "邮箱格式不正确")]
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                Set(ref _email, value);
            }
        }

        private string _verificationCode;
        [Required]
        public string VerificationCode
        {
            get
            {
                return _verificationCode;
            }
            set
            {
                Set(ref _verificationCode, value);
            }
        }

        private string _newPassword;
        [Required]
        public string NewPassword
        {
            get
            {
                return _newPassword;
            }
            set
            {
                Set(ref _newPassword, value);
            }
        }

        private string _newPasswordAgain;
        [Required]
        [Compare("NewPassword", ErrorMessage = "两次输入的密码不一致")]
        public string NewPasswordAgain
        {
            get
            {
                return _newPasswordAgain;
            }
            set
            {
                Set(ref _newPasswordAgain, value);
            }
        }
    }
}
