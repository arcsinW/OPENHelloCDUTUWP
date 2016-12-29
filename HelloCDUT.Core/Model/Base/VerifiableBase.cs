using HelloCDUT.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HelloCDUT.Core.Helper
{
    public abstract class VerifiableBase : ModelBase
    {
        private VerifiableObjectErrors _errors;

        public VerifiableBase()
        {
            _errors = new VerifiableObjectErrors(this);
        }

        public VerifiableObjectErrors Errors
        {
            get
            {
                return _errors;
            }
        }

        public bool IsValid
        {
            get
            {
                return _errors.Count <= 0;
            }
        }

        public override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            _errors = new VerifiableObjectErrors(this);
            base.OnPropertyChanged(nameof(Errors));
            base.OnPropertyChanged(nameof(IsValid));
        }
    }
}
