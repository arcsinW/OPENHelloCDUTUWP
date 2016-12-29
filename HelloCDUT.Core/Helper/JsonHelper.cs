using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HelloCDUT.Core.Helper
{
    public static class JsonHelper
    {
        /// <summary>
        /// Serialize T to json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string Serializer<T>(T t)
        {
            var result = string.Empty;
            try
            {
                if (t == null) return result;
                string json = JsonConvert.SerializeObject(t);
                return json;
            }
            catch (Exception e)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine("JsonHelper Serializer<T>" + e.Message);
#endif
                return string.Empty;
            }
        }

        /// <summary>
        /// Deserialize json to T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonText"></param>
        /// <returns></returns>
        public static T Deserlialize<T>(string jsonText) where T : class
        {
            T result = default(T);
            try
            {
                if (!string.IsNullOrEmpty(jsonText))
                {
                    result = JsonConvert.DeserializeObject<T>(jsonText);
                }
            }
            catch (Exception e)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine("JsonHelper Deserlizlize<T>" + e.Message);
#endif 
                return result;
            }
            return result;
        }
    }
}
