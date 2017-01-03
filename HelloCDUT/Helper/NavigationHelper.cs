 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCDUT.Helper
{
    public class NavigationHelper
    {
        public static void MasterFrameNavigate(Type sourcePage,object parameter)
        {
            MasterDetailPage.Current.MasterFrame.Navigate(sourcePage,parameter);
        }

        public static void MasterFrameNavigate(Type sourcePage)
        {
            MasterDetailPage.Current.MasterFrame.Navigate(sourcePage);
        }

        public static void DetailFrameNavigate(Type sourcePage)
        {
            MasterDetailPage.Current.DetailFrame.Navigate(sourcePage);
        }

        public static void DetailFrameNavigate(Type sourcePage,object parameter)
        {
            MasterDetailPage.Current.DetailFrame.Navigate(sourcePage,parameter);
        }
    }
}
