using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCDUT.Core.ViewModels
{
    public class AppShellViewModel : ViewModelBase
    {
        public AppShellViewModel()
        {
            NavigationBarMenuItems = ServiceLocator.Current
                .GetAllInstances<INavigationBarMenuItem>()
                .Where(i => i.Position == NavigationBarItemPosition.Top)
                .ToList();

            BottomNavigationBarMenuItems = ServiceLocator.Current
                .GetAllInstances<INavigationBarMenuItem>()
                .Where(i => i.Position == NavigationBarItemPosition.Bottom)
                .ToList();

#if DEBUG
            //BottomNavigationBarMenuItems.Add(new DebugNavigationBarMenuItem());
#endif
        }

        /// <summary>
        /// The navigation bar items at the bottom.
        /// </summary>
        public List<INavigationBarMenuItem> BottomNavigationBarMenuItems { get; }

        /// <summary>
        /// The navigation bar items at the top.
        /// </summary>
        public List<INavigationBarMenuItem> NavigationBarMenuItems { get; private set; }
    }
}
