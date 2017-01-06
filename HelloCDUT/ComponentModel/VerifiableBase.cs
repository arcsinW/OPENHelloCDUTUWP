 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HelloCDUT.ComponentModel
{
    public abstract class VerifiableBase : ObserableObjectBase
    { 
        public VerifiableBase()
        {
            _errors = new VerifiableObjectErrors(this);
        }

        private VerifiableObjectErrors _errors;
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

        public override void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.NotifyPropertyChanged(propertyName);
            _errors = new VerifiableObjectErrors(this);
            base.NotifyPropertyChanged(nameof(Errors));
            base.NotifyPropertyChanged(nameof(IsValid));
        }
    }
}
