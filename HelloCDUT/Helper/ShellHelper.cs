using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Media;

namespace HelloCDUT.Helper
{
    /// <summary>
    /// Provide functions to change appearance
    /// </summary>
    public class ShellHelper
    {
        private static ShellHelper _shellHelper = new ShellHelper();
        public static ShellHelper Instance
        {
            get
            {
                return _shellHelper;
            }
        }

        public void ChangeTitleColor()
        {
            var applicationView = ApplicationView.GetForCurrentView();
             
            applicationView.TitleBar.BackgroundColor = Windows.UI.Xaml.Application.Current.Resources["AppThemeColor"] as Color?;
            applicationView.TitleBar.ForegroundColor = Colors.White;
            applicationView.TitleBar.ButtonBackgroundColor = Windows.UI.Xaml.Application.Current.Resources["AppThemeColor"] as Color?; ;
            applicationView.TitleBar.ButtonForegroundColor = Colors.White;

            ApplicationView.GetForCurrentView().ShowStandardSystemOverlays();

        }
    }
}
