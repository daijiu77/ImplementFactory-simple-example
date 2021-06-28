using System;
using System.Collections.Generic;
using System.DJ.DJson.Commons;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace WindowsFormsApp1
{
    class HttpHelper
    {
        string httpAddress = "";

        public HttpHelper(string httpAddress)
        {
            this.httpAddress = httpAddress;
        }

        public void SendData(BaseEntity dataInfo)
        {
            string resultData = null;
            string json = dataInfo.ToJsonUnit();
            byte[] dts = Encoding.Default.GetBytes(json);
            HttpContent httpContent = new ByteArrayContent(dts);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponseMessage = null;
            try
            {
                httpResponseMessage = httpClient.PostAsync(httpAddress, httpContent).Result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                resultData = httpResponseMessage.Content.ReadAsStringAsync().Result;
            }
            else
            {
                string err = "";
                object ex = httpResponseMessage.Content.ReadAsStringAsync().Exception;
                if (null != ex)
                {
                    err = ex.ToString();
                    throw new Exception(err);
                }
            }
        }
    }
}
