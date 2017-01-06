using HelloCDUT.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCDUT.ViewModels
{
    public class FindBackPwdViewModel : ViewModelBase
    {
        public AAOInput AAOInput { get; set; }

        public EmailInput EmailInput { get; set; }

        public FindBackPwdViewModel()
        {
            AAOInput = new AAOInput();
            EmailInput = new EmailInput();
        }
    }
}
