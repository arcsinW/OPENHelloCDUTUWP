using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace HelloCDUT.Core.Helper
{
    public class GlobalStringLoader
    {
        private static ResourceLoader loader ;
         
        static GlobalStringLoader()
        {
            loader = ResourceLoader.GetForCurrentView();
        }

        public static string GetString(string key)
        {
            string value = loader.GetString(key);
            return string.IsNullOrEmpty(value) ? string.Empty : value;
        }
    }

}
