using Refit;
using System.Net.Http.Headers;
using System.Text;

namespace Basis.Service.Cashin.Client.ClientGenerator
{
    public class HttpClientGeneratorBuilder
    {
        private readonly string _hostUrl;
        public HttpClientGeneratorBuilder(string url)
        {
            _hostUrl = url;
        }

        /// <summary>
        /// Generate dynamic api client.
        /// </summary>
        /// <typeparam name="TInterface">Use Refit style interface</typeparam>
        /// <returns>TInterface</returns>
        public TInterface Generate<TInterface>()
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri(_hostUrl) };
          
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json") { CharSet = "utf-8" });

            //if (_headers != null)
            //{
            //    for (int i = 0; i < _headers.Count; i++)
            //    {
            //        var key = _headers.GetKey(i);
            //        var value = _headers.GetValues(i);
            //        client.DefaultRequestHeaders.Add(key, value);
            //    }
            //}



            return RestService.For<TInterface>(client);
        }
    }
}
