using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
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
            var titleBar = ApplicationView.GetForCurrentView().TitleBar;

            //active
            titleBar.BackgroundColor = (Color)Application.Current.Resources["AppThemeColor"];
            titleBar.ForegroundColor = Colors.White;

            //inactive
            titleBar.InactiveBackgroundColor = (Color)Application.Current.Resources["AppThemeColor"];
            titleBar.InactiveForegroundColor = Colors.LightGray;

            //buttons
            titleBar.ButtonBackgroundColor = (Color)Application.Current.Resources["AppThemeColor"];
            titleBar.ButtonForegroundColor = Colors.White;

            titleBar.ButtonHoverBackgroundColor = (Color)Application.Current.Resources["AppThemeLightColor"];
            titleBar.ButtonHoverForegroundColor = Colors.White;

            titleBar.ButtonInactiveBackgroundColor = (Color)Application.Current.Resources["AppThemeLightColor"];
            titleBar.ButtonInactiveForegroundColor = Colors.LightGray;

            titleBar.ButtonPressedBackgroundColor = (Color)Application.Current.Resources["AppThemePressColor"];
            titleBar.ButtonPressedForegroundColor = Colors.White;
        }
    }
}
