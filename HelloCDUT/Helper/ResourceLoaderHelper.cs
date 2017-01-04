using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace HelloCDUT.Helper
{
    public class ResourceLoaderHelper
    {
        private static ResourceLoader _resourceLoader = new ResourceLoader();

        public static ResourceLoader Instance
        {
            get
            {
                return _resourceLoader;
            }
        }

        public string GetString(string key)
        {
            string value = _resourceLoader.GetString(key);
            return string.IsNullOrEmpty(value) ? string.Empty : value;
        }
    }

}
