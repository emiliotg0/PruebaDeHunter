using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace HunterMoviesWeb.Common
{
    public class CustomHttpClient : HttpClient
    {
        public async Task<T> GetJsonAsync<T>(string requestUri)
        {
            Debug.WriteLine("QUERY ========");
            Debug.WriteLine(this.BaseAddress+requestUri);
            var httpContent = await this.GetAsync(requestUri);
            string jsonContent = await httpContent.Content.ReadAsStringAsync();

            T obj = JsonConvert.DeserializeObject<T>(jsonContent);
            Debug.WriteLine(obj);
            httpContent.Dispose();
            this.Dispose();
            return obj;
        }

        public async Task<HttpResponseMessage> PostJsonAsync<T>(string requestUri, T content)
        {
            string myContent = JsonConvert.SerializeObject(content);
            StringContent stringContent = new StringContent(myContent, Encoding.UTF8, "application/json");
            var response = await this.PostAsync(requestUri, stringContent);
            this.Dispose();
            return response;
        }

        public async Task<HttpResponseMessage> PutJsonAsync<T>(string requestUri, T content)
        {
            string myContent = JsonConvert.SerializeObject(content);
            StringContent stringContent = new StringContent(myContent, Encoding.UTF8, "application/json");
            var response = await this.PutAsync(requestUri, stringContent);
            this.Dispose();
            return response;
        }
    }
}
