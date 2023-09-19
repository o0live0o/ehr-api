using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Ehr.Core.Utils.Http
{
    public class HttpUtil
    {
        private static HttpWebRequest CreateWebRequest(RequestContent request)
        {
            ServicePointManager.DefaultConnectionLimit = 50;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            HttpWebRequest httpWebRequest = null;

            //拼接HTTP GET参数
            if (request.Params?.Count > 0)
            {
                List<string> list = new List<string>();
                foreach (var item in request.Params.Keys)
                {
                    list.Add($"{item}={request.Params[item]}");
                }
                request.Url = $"{request.Url}?{string.Join("&", list.ToArray())}";
            }

            httpWebRequest = WebRequest.Create(request.Url) as HttpWebRequest;

            //请求头信息
            httpWebRequest.Method = request.Method;
            httpWebRequest.Timeout = request.Timeout;
            httpWebRequest.ContentType = request.ContentType;
            httpWebRequest.AllowAutoRedirect = request.AllowRedirect;
            httpWebRequest.KeepAlive = false;
            if (request.Host != null)
                httpWebRequest.Host = request.Host;
            //head
            if (request.Headers?.Count > 0)
            {
                foreach (var item in request.Headers.Keys)
                {
                    httpWebRequest.Headers.Add(item, request.Headers[item]?.ToString());
                }
            }

            //cookie
            if (request.Cookies?.Count > 0)
            {
                CookieContainer container = new CookieContainer();
                foreach (var item in request.Cookies.Keys)
                {
                    container.Add(new Cookie(item, request.Cookies[item]?.ToString()));
                }
                httpWebRequest.CookieContainer = container;
            }

            return httpWebRequest;
        }

        public static async Task<ResponseContent> SendAsync(RequestContent request)
        {
            if (string.IsNullOrEmpty(request.Url))
                throw new ArgumentNullException("url");

            ResponseContent resp = new ResponseContent();

            try
            {
                var httpWebRequest = CreateWebRequest(request);

                //发送post参数
                if ((request.Method.ToUpper() == "POST" || request.Method.ToUpper() == "PUT") && request.PostData != null)
                {
                    httpWebRequest.ContentLength = request.PostData.Length;
                    Stream writer = null;
                    try
                    {
                        writer = await httpWebRequest.GetRequestStreamAsync();
                    }
                    catch (WebException wex)
                    {
                        throw wex;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    

                    writer.Write(request.PostData, 0, request.PostData.Length);
                    writer.Close();
                }
                else if (request.Method.ToUpper() == "POST" && request.FormData.Count() > 0)
                {
                    httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                    List<string> dataList = new List<string>();
                    foreach (var item in request.FormData.Keys)
                    {
                        dataList.Add($"{item}={HttpUtility.UrlEncode(request.FormData[item]?.ToString())}");
                    }
                    var dataByte = Encoding.GetEncoding("UTF-8").GetBytes(string.Join("&", dataList.ToArray()));
                    httpWebRequest.ContentLength = dataByte.Length;

                    Stream writer;
                    try
                    {
                        writer = await httpWebRequest.GetRequestStreamAsync();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    writer.Write(dataByte, 0, dataByte.Length);
                    writer.Close();
                }

                using (var response = await httpWebRequest.GetResponseAsync() as HttpWebResponse)
                {
                    //获取响应头信息
                    foreach (var item in response.Headers.AllKeys)
                    {
                        response.Headers.Add(item, response.Headers[item]);
                    }

                    //获取服务器返回内容
                    using (var stream = response.GetResponseStream())
                    {
                        using (var os = await StreamToMemoryStream(stream))
                        {
                            os.Seek(0, SeekOrigin.Begin);
                            resp.Data = new byte[(int)os.Length];
                            await os.ReadAsync(resp.Data, 0, (int)os.Length);
                            os.Flush();
                        }
                    }

                    resp.Code = (int)response.StatusCode;
                }
            }
            catch (WebException wex)
            {
                var response = wex.Response as HttpWebResponse;
                resp.Code = response == null ? 5001 : (int)response.StatusCode;
                resp.Data = Encoding.Default.GetBytes(wex?.Message);
            }
            catch (Exception ex)
            {
                resp.Code = 400;
                resp.Data = Encoding.Default.GetBytes(ex.Message);
            }
            return resp;
        }

        /// <summary>
        /// 把响应流读取到内存
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private static async Task<MemoryStream> StreamToMemoryStream(Stream stream)
        {
            MemoryStream os = new MemoryStream();
            const int read = 4096;
            byte[] bytes = new byte[read];
            int len = 0;
            while ((len = await stream.ReadAsync(bytes, 0, read)) > 0)
            {
                await os.WriteAsync(bytes, 0, len);
            }
            return os;
        }
    }
}