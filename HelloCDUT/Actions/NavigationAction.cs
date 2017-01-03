 
using Microsoft.Xaml.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace BaoZouRiBao.BaoZouAction
{
    public class NavigationAction : DependencyObject, IAction
    {
        public string SourcePage
        {
            get { return (string)GetValue(SourcePageProperty); }
            set { SetValue(SourcePageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SourcePage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SourcePageProperty =
            DependencyProperty.Register("SourcePage", typeof(string), typeof(NavigationAction), new PropertyMetadata(0));

        public PageType NavigationType
        {
            get { return (PageType)GetValue(PageTypeProperty); }
            set { SetValue(PageTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageTypeProperty =
            DependencyProperty.Register("NavigationType", typeof(PageType), typeof(NavigationAction), new PropertyMetadata(0));
        
        public enum PageType
        {
            Master,
            Detail
        }

        public object Execute(object sender, object parameter)
        {
            if (NavigationType == PageType.Master)
            {
                MasterDetailPage.Current.MasterFrame.Navigate(Type.GetType(SourcePage));
            }
            else
            {
                MasterDetailPage.Current.DetailFrame.Navigate(Type.GetType(SourcePage));
            }
            return true;
        }
    }
}
