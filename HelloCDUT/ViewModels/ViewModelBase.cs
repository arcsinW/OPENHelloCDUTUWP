using HelloCDUT.Helper;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;

namespace HelloCDUT.ViewModels
{
    public class ViewModelBase : DependencyObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public ViewModelBase()
        {
            IsDesktop = DeviceInformationHelper.IsDesktop();
        }
        
        ///<Summary>
        /// Indicate wether is in design mode
        /// </Summary> 
        public static bool IsDesignMode
        {
            get
            {
                return Windows.ApplicationModel.DesignMode.DesignModeEnabled;
            }
        }
         

        public bool IsDesktop
        {
            get { return (bool)GetValue(IsDesktopProperty); }
            set { SetValue(IsDesktopProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsDesktop.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsDesktopProperty =
            DependencyProperty.Register("IsDesktop", typeof(bool), typeof(ViewModelBase), new PropertyMetadata(false));

         
        //public static bool IsDesktop
        //{
        //    get
        //    {
        //        return DeviceInformationHelper.IsDesktop();
        //    }
        //} 
    }
}
