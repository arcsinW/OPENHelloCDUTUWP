using HelloCDUT.Core.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloCDUT.Core.Model;

namespace HelloCDUT.Core.Service
{
    public class AppEnvironment : ObserableObjectBase, IAppEnvironment
    {
        private User _currentUser;
        public User CurrentUser
        {
            get
            {
                return _currentUser;
            }

            set
            {
                _currentUser = value;
                NotifyPropertyChanged(nameof(CurrentUser));

                CurrentUserChanged?.Invoke(this, CurrentUser);
            }
        }

        private static AppEnvironment _appEnvironment = new AppEnvironment();
        public static AppEnvironment Instance
        {
            get
            {
                return _appEnvironment;
            }
        }

        public event EventHandler<User> CurrentUserChanged;
    }
}
