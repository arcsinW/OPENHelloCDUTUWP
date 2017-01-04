using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.Web.Http;

namespace HelloCDUT.Services
{
    /// <summary>
    /// provide basic http functions
    /// Hide details of handle HttpResponseMessage
    /// </summary>
    public class HttpBaseService
    {
        private static HttpClient httpClient = new HttpClient();

        /// <summary>
        ///  
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async static Task<string> GetStringAsync(string uri)
        {
            try
            {
                return await httpClient.GetStringAsync(new Uri(uri));
            }
            catch(Exception e)
            {
#if DEBUG
                Debug.WriteLine("HttpBaseService GetStringAsync:" + e.Message);
                return null;
#endif
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public async static Task<string> PostAsync(string uri, string body)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri(uri));
                request.Content = new HttpStringContent(body, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json; charset=utf-8");
                HttpResponseMessage response = await httpClient.SendRequestAsync(request);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
#if DEBUG
                Debug.WriteLine("HttpBaseService PostAsync:" + e.Message);
                return null;
#endif
            }
        }

        /// <summary>
        /// Send post request with dictionary
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        public async static Task<string> PostAsync(string uri,Dictionary<string,string> dic)
        {
            try
            {
                HttpFormUrlEncodedContent content = new HttpFormUrlEncodedContent(dic);
                HttpResponseMessage response = await httpClient.PostAsync(new Uri(uri), content);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
#if DEBUG
                Debug.WriteLine("HttpBaseService PostAsync:" + e.Message);
                return null;
#endif 
            }
        }


        /// <summary>
        ///  
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async static Task<IBuffer> GetIBufferAsync(string uri)
        {
            try
            {
                return await httpClient.GetBufferAsync(new Uri(uri)); 
            }
            catch (Exception e)
            {
#if DEBUG
                Debug.WriteLine("HttpBaseService GetBytesAsync:" + e.Message);
                return null;
#endif 
            }
        }
    }
}
