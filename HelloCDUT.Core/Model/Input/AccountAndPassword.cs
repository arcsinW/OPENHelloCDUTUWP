using HelloCDUT.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCDUT.Core.Model.Input
{
    public class AccountAndPassword : ModelBase
    { 
        /// <summary>
        /// 账号
        /// </summary>
        [Required(ErrorMessage = "账号不能为空")]
        public string Account { get; set; }
         

        [Required(ErrorMessage = "密码不能为空")]
        public string Password { get; set; }
    }
}
