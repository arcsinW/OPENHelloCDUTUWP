using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloCDUT.Models;
using HelloCDUT.ComponentModel;
using Windows.System.Profile;
using HelloCDUT.Extensions;

namespace HelloCDUT.Services
{
    public class AppEnvironment : ObserableObjectBase, IAppEnvironment
    {
        private User _currentUser;
        public User CurrentUser
        {
            get { return _currentUser; }

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

        /// <summary>
        /// Gets the device family.
        /// </summary>
        private DeviceFamily DeviceFamily { get; } = AnalyticsInfo.VersionInfo.DeviceFamily.ToDeviceFamily();

        /// <summary>
        /// Determines if app runs on a desktop device.
        /// </summary>
        public bool IsDesktopDeviceFamily
        {
            get { return DeviceFamily == DeviceFamily.Desktop; }
        }

        /// <summary>
        /// Determines if app runs on a mobile device.
        /// </summary>
        public bool IsMobileDeviceFamily
        {
            get { return DeviceFamily == DeviceFamily.Mobile; }
        }

        /// <summary>
        /// Applies the given configuration.
        /// </summary>
        /// <param name="config">The configuration to apply.</param>
        public void SetConfig(Config config)
        {
            if (IsMobileDeviceFamily)
            {
                //CategoryThumbnailsCount = config.CategoryThumbnailsSmallFormFactor;
            }
            else
            {
                //CategoryThumbnailsCount = config.CategoryThumbnailsLargeFormFactor;
            }
        }
    }
}
