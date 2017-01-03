using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HelloCDUT.Core.ComponentModel
{
    public class ObserableObjectBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void NotifyPropertyChanged([CallerMemberName]string propertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void Set<T>(ref T storage, T newValue, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, newValue))
            {
                return;
            }
            storage = newValue;
            NotifyPropertyChanged(propertyName);
        }

    }
}
