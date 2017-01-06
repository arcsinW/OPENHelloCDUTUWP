using HelloCDUT.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCDUT.ViewModels
{
    public class SignUpViewModel : ViewModelBase
    {
        public SignUpInput SignUpInput { get; set; }

        public SignUpViewModel()
        {
            SignUpInput = new SignUpInput();
        }
    }
}
