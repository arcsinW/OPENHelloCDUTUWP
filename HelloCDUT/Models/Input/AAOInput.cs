using HelloCDUT.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCDUT.Models.Input
{
    public class AAOInput : VerifiableBase
    {
        private string _aaoAccount;
        /// <summary>
        /// 教务系统账号 
        /// </summary>
        [Required]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "账号长度为6-15")]
        public string AaoAccount
        {
            get
            {
                return _aaoAccount;
            }
            set
            {
                Set(ref _aaoAccount, value);
            }
        }

        private string _aaoPassword;
        [Required]
        public string AaoPassword
        {
            get
            {
                return _aaoPassword;
            }
            set
            {
                Set(ref _aaoPassword, value);
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
        [Compare("NewPassword")]
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
