using HelloCDUT.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace HelloCDUT.Services
{
    public class ApiBaseService
    {
        private const string ApiUri = "http://www.hellocdut.com/api/release/index.php";

        protected async Task<T> PostDictionary<T>(Dictionary<string,string> dic) where T:class
        {
            try
            {
                string json = await HttpBaseService.PostAsync(ApiUri, dic);
                return JsonHelper.Deserlialize<T>(json);
            }
            catch (Exception e)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine("ApiBaseService.PostDictionary :"+ e.Message);
#endif
                return null;
            } 
        } 

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri"></param>
        /// <returns></returns>
        protected async Task<T> GetJsonByUri<T>(string uri) where T:class
        {
            try
            {
                string json = await HttpBaseService.GetStringAsync(uri);
                if (json != null)
                {
                    return JsonHelper.Deserlialize<T>(json);
                }
                else
                {
                    return null;
                }
            }
            catch(Exception e)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine("ApiBaseService.GetJsonByUri : "+e.Message);
#endif
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        protected async Task<T> PostJson<T>(string body) where T:class
        {
            try
            {
                string json = await HttpBaseService.PostAsync(ApiUri, body);
                if(json!= null)
                {
                    return JsonHelper.Deserlialize<T>(json);
                }
                return null;
            }
            catch (Exception e)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine(e.Message);
#endif
                return null;
            }
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        protected async Task<T>PostJson<T> (T t) where T : class
        {
            string body = JsonHelper.Serializer(t);
            try
            {
                string json = await HttpBaseService.PostAsync(ApiUri, body);
                if (json != null)
                {
                    return JsonHelper.Deserlialize<T>(json);
                }
                return null;
            }
            catch (Exception e)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine(e.Message);
#endif
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="SendT"></typeparam>
        /// <typeparam name="ReturnT"></typeparam>
        /// <param name="uri"></param>
        /// <param name="sendT"></param>
        /// <returns></returns>
        protected async Task<ReturnT> PostJson<SendT,ReturnT>(SendT sendT) where ReturnT : class
        {
            string body = JsonHelper.Serializer(sendT);
            try
            {
                string json = await HttpBaseService.PostAsync(ApiUri, body);
                if (json != null)
                {
                    return JsonHelper.Deserlialize<ReturnT>(json);
                }
                return null;
            }
            catch (Exception e)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine(e.Message);
#endif
                return null;
            }
        }
        
        protected async Task<string> GetHtml(string uri)
        {
            try
            {
                string html = await HttpBaseService.GetStringAsync(uri);
                //byte[] bytes = Encoding.UTF8.GetBytes(html);
                //html = Encoding.GetEncoding("GBK").GetString(bytes);
                return html;
            }
            catch (Exception e)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine(e.Message);
#endif
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        protected async Task<WriteableBitmap> GetImage(string uri)
        {
            try
            {
                IBuffer buffer = await HttpBaseService.GetIBufferAsync(uri);
                if (buffer != null)
                {
                    BitmapImage bi = new BitmapImage();
                    WriteableBitmap wb = null;
                    using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
                    {

                        Stream stream2Write = stream.AsStreamForWrite();

                        await stream2Write.WriteAsync(buffer.ToArray(), 0, (int)buffer.Length);

                        await stream2Write.FlushAsync();
                        stream.Seek(0);

                        await bi.SetSourceAsync(stream);

                        wb = new WriteableBitmap(bi.PixelWidth, bi.PixelHeight);
                        stream.Seek(0);
                        await wb.SetSourceAsync(stream);

                        return wb;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine("ApiBaseService.GetImage"+e.Message);
#endif
                return null;
            }
        }
    }
}
